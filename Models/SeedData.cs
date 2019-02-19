using System.Collections.Generic;
using System.Linq;
using LastWork.Models.Instructions;
using LastWork.Models.InstructionSteps;
using Microsoft.EntityFrameworkCore;

namespace LastWork.Models
{
    public class SeedData
    {
        public static void SeedDatabase(DataContext context)
        {
            context.Database.Migrate();
            if (context.Instructions.Count() == 0)
            {
                
                // var s1 = new InstructionStep
                // {
                //     StepName = "Splash Dudes",
                //     StepDescription = "San Jose"
                // };
                // var s2 = new InstructionStep
                // {
                //     StepName = "Splash Dasdsadudes",
                //     StepDescription = "San Josasdasde"
                // };
                // var s3 = new InstructionStep
                // {
                //     StepName = "Splash Dudeasdasds",
                //     StepDescription = "San Joasdasdse"
                // };
                // context.AddRange(
                //     new Instruction {
                //         InstructionName = "asdas",
                //         Description = "asdsadasd",
                //         Steps = new List<InstructionStep> {s1,s2}
                //     },
                //     new Instruction {
                //         InstructionName = "asdafgfdsdas",
                //         Description = "fgjl;gkhj",
                //         Steps = new List<InstructionStep> {s1,s3}
                //     }
                // );
                // context.SaveChanges();
            }
        }
    }
}