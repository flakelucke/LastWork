using LastWork.Models.Instructions;
using Microsoft.EntityFrameworkCore;

namespace LastWork.Models {
    public class DataContext : DbContext {
        public DataContext(DbContextOptions<DataContext> opts)
            : base(opts) { }
        public DbSet<Instruction> instructions { get; set; }
        public DbSet<InstructionStep> steps { get; set; }
    }
}