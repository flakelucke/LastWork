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
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using LastWork.Models.Users;

namespace LastWork.Controllers
{
    [Route("api/instructions")]
    [Authorize]
    public class IntructionValuesController : Controller
    {
        private IInstructionRepository repository;
        private DataContext context;
        RoleManager<IdentityRole> role;
        UserManager<User> user;
        public IntructionValuesController(IInstructionRepository repository,
                    DataContext context,
                    RoleManager<IdentityRole> role,
                    UserManager<User> user
                    )
        {
            this.repository = repository;
            this.context = context;
            this.role = role;
            this.user = user;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<Instruction>> GetAllInstruction([FromQuery]string search)
        {
            if (search==null||search.Length==0)
            {
                return await repository.GetAllInstructions();
            }
            else
            {
                return await repository.SearchInstructions(search);
            }
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetInstruction(long id)
        {
            // await role.CreateAsync(new IdentityRole("administrator"));
            // await role.CreateAsync(new IdentityRole("user"));
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

        [HttpGet]
        [Route("search/{search}")]
        [AllowAnonymous]
        public async Task<IEnumerable<Instruction>> SearchInstractionsAsync(string search)
        {
            return await repository.SearchInstructions(search);
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
                        .Include(p => p.User)
                                .FirstOrDefault(p => p.InstructionId == id);
            InstructionData pdata = new InstructionData
            {
                InstructionName = instruction.InstructionName,
                Description = instruction.Description,
                User = instruction.User,
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
                    if (pdataStepCount == 0)
                        instruction.Steps.RemoveRange(0, instrStepCount);
                    else
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