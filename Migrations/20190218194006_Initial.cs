using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LastWork.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "instructions",
                columns: table => new
                {
                    InstructionId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InstructionName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_instructions", x => x.InstructionId);
                });

            migrationBuilder.CreateTable(
                name: "steps",
                columns: table => new
                {
                    InstructionStepId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StepName = table.Column<string>(nullable: true),
                    StepDescription = table.Column<string>(nullable: true),
                    InstructionId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_steps", x => x.InstructionStepId);
                    table.ForeignKey(
                        name: "FK_steps_instructions_InstructionId",
                        column: x => x.InstructionId,
                        principalTable: "instructions",
                        principalColumn: "InstructionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_steps_InstructionId",
                table: "steps",
                column: "InstructionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "steps");

            migrationBuilder.DropTable(
                name: "instructions");
        }
    }
}
