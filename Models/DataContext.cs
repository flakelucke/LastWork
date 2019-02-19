using LastWork.Models.Instructions;
using LastWork.Models.InstructionSteps;
using Microsoft.EntityFrameworkCore;

namespace LastWork.Models {
    public class DataContext : DbContext {

        public DataContext(DbContextOptions<DataContext> opts)
            : base(opts) { }
        
        public DbSet<Instruction> Instructions { get; set; }
        public DbSet<InstructionStep> Steps { get; set; }
    }
}