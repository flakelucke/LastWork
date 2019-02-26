using System.Threading.Tasks;
using LastWork.Models.Instructions;
using LastWork.Models.InstructionSteps;
using Microsoft.AspNetCore.Mvc;
using LastWork.Models;
using System.Collections.Generic;
using LastWork.Models.BindingTargets;

namespace LastWork.Controllers
{
    [Route("api/instructions")]
    public class IntructionValuesController : Controller
    {
        private IInstructionRepository repository;
        private DataContext context;
        public IntructionValuesController(IInstructionRepository repository,DataContext context)
        {
            this.repository = repository;
            this.context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Instruction>> GetAllInstruction()
        {
            return await repository.GetAllInstructions();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetInstruction(long id)
        {
            return Ok(await repository.FindInstructionByIdAsync(id.ToString()));
        }
        [HttpPost]
        public async Task<IActionResult> CreateInstruction([FromBody] InstructionData idata)
        {
            if (ModelState.IsValid)
            {
                var idInst =await  repository.CreateInstruction(idata);
                return Ok(idInst);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(long id) {
            await repository.DeleteInstruction(id);
            return Ok();
        }
    }
}