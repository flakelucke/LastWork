using System.Threading.Tasks;
using LastWork.Models.Instructions;
using LastWork.Models.InstructionSteps;
using Microsoft.AspNetCore.Mvc;
using LastWork.Models;
using System.Collections.Generic;
using LastWork.Models.BindingTargets;
using Microsoft.AspNetCore.JsonPatch;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace LastWork.Controllers
{
    [Route("api/instructions")]
    [Authorize(Roles = "Administrator")]
    public class IntructionValuesController : Controller
    {
        private IInstructionRepository repository;
        private DataContext context;
        // private readonly IdentityDataContext ctx;

        // public UserManager<IdentityUser> UserManager { get; }
        // public RoleManager<IdentityRole> RoleManager { get; }
        public IntructionValuesController(IInstructionRepository repository,
                    DataContext context
                    // UserManager<IdentityUser> userManager,
                    // RoleManager<IdentityRole> roleManager,
                    // IdentityDataContext ctx
                    )
        {
            this.repository = repository;
            this.context = context;
            // UserManager = userManager;
            // RoleManager = roleManager;
            // this.ctx = ctx;
        }

        [Authorize]
        public string Protected() {
            return "You have been authenticated";
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<Instruction>> GetAllInstruction()
        {
            // IdentitySeedData.SeedDatabase(UserManager,RoleManager,ctx);
            return await repository.GetAllInstructions();
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetInstruction(long id)
        {
            return Ok(await repository.FindInstructionByIdAsync(id.ToString()));
        }
        [HttpPost]
        public async Task<IActionResult> CreateInstruction([FromBody] InstructionData idata)
        {
            if (ModelState.IsValid)
            {
                var idInst = await repository.CreateInstruction(idata);
                return Ok(idInst);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInstruction(long id)
        {
            await repository.DeleteInstruction(id);
            return Ok();
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateInstruction(long id,
                [FromBody]JsonPatchDocument<InstructionData> patch)
        {
            Instruction instruction = context.Instructions
                        .Include(p => p.Steps)
                                .FirstOrDefault(p => p.InstructionId == id);
            InstructionData pdata = new InstructionData
            {
                InstructionName = instruction.InstructionName,
                Description = instruction.Description,
                Steps = instruction.Steps.Select(p => new InstructionStepData
                { InstructionStepId = p.InstructionStepId, StepName = p.StepName, StepDescription = p.StepDescription }).ToList()
            };
            patch.ApplyTo(pdata, ModelState);
            if (ModelState.IsValid && TryValidateModel(pdata))
            {
                int pdataStepCount = pdata.Steps.Count;
                int instrStepCount = instruction.Steps.Count;

                instruction.Description = pdata.Description;
                instruction.InstructionName = pdata.InstructionName;
                if (pdataStepCount < instrStepCount)
                    instruction.Steps.RemoveRange(pdataStepCount - 1, instrStepCount - pdataStepCount);

                for (int i = 0; i < pdataStepCount; i++)
                {
                    if (i > instrStepCount - 1)
                        instruction.Steps.Add(
                            new InstructionStep
                            {
                                StepName = pdata.Steps[i].StepName,
                                StepDescription = pdata.Steps[i].StepDescription
                            });
                    else
                    {
                        instruction.Steps[i].StepDescription = pdata.Steps[i].StepDescription;
                        instruction.Steps[i].StepName = pdata.Steps[i].StepName;
                    }
                }
                context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}