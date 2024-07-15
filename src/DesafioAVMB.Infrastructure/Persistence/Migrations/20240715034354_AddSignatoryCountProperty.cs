using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesafioAVMB.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddSignatoryCountProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SignatoryCount",
                table: "Envelopes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SignatoryCount",
                table: "Envelopes");
        }
    }
}
