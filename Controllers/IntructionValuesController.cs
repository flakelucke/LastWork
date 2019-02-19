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

        // [HttpGet]
        // public async Task<IEnumerable<Instruction>> GetAllInstruction(long id)
        // {
        //     var n = await repository.GetAllInstructions();
        //     return n;
        // }

        [HttpGet("{id}")]
        public async Task<Instruction> GetInstruction(long id)
        {

            var k = await repository.FindInstructionByIdAsync(id.ToString());
            return k;
        }
    }
}