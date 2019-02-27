using LastWork.Models.Instructions;
using LastWork.Models.InstructionSteps;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LastWork.Models {
    public class DataContext : DbContext {

        public DataContext(DbContextOptions<DataContext> opts)
            : base(opts) { }
        
        public DbSet<Instruction> Instructions { get; set; }
        public DbSet<InstructionStep> Steps { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Instruction>().HasMany<InstructionStep>(x=>x.Steps)
                .WithOne().OnDelete(DeleteBehavior.Cascade);
        }
    }
}