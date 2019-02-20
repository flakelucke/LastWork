using System.Threading.Tasks;
using LastWork.Models.Instructions;
using LastWork.Models.InstructionSteps;
using Microsoft.AspNetCore.Mvc;
using LastWork.Models;
using System.Collections.Generic;

namespace LastWork.Controllers
{
    [Route("api/instructions")]
    public class IntructionValuesController : Controller
    {
        private IInstructionRepository repository;
        public IntructionValuesController(IInstructionRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<Instruction>> GetAllInstruction(long id)
        {
            return await repository.GetAllInstructions();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetInstruction(long id)
        {
            return Ok(await repository.FindInstructionByIdAsync(id.ToString()));
        }
    }
}