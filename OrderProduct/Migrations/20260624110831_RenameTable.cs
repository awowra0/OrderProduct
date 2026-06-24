using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderProduct.Migrations
{
    /// <inheritdoc />
    public partial class RenameTable : Migration
    {
            /// <inheritdoc />
            protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.RenameTable(
            name: "Table",
            newName: "OPTable");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.RenameTable(
            name: "OPTable",
            newName: "Table");
    }
        }
}
