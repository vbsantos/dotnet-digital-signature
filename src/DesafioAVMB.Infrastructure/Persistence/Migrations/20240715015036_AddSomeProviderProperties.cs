using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesafioAVMB.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddSomeProviderProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ProviderId",
                table: "Envelopes",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProviderId",
                table: "Envelopes");
        }
    }
}
