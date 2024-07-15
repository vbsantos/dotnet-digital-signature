using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesafioAVMB.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddProviderIdField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ProviderId",
                table: "Signatories",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProviderId",
                table: "Signatories");
        }
    }
}
