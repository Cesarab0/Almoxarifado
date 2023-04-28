using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WinForms.Migrations
{
    /// <inheritdoc />
    public partial class Mig_4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Saldos",
                table: "Saldos");

            migrationBuilder.RenameTable(
                name: "Saldos",
                newName: "saldos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_saldos",
                table: "saldos",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_saldos_almoxarifado_id",
                table: "saldos",
                column: "almoxarifado_id");

            migrationBuilder.CreateIndex(
                name: "IX_saldos_produto_id",
                table: "saldos",
                column: "produto_id");

            migrationBuilder.AddForeignKey(
                name: "FK_saldos_almoxarifados_almoxarifado_id",
                table: "saldos",
                column: "almoxarifado_id",
                principalTable: "almoxarifados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_saldos_produtos_produto_id",
                table: "saldos",
                column: "produto_id",
                principalTable: "produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_saldos_almoxarifados_almoxarifado_id",
                table: "saldos");

            migrationBuilder.DropForeignKey(
                name: "FK_saldos_produtos_produto_id",
                table: "saldos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_saldos",
                table: "saldos");

            migrationBuilder.DropIndex(
                name: "IX_saldos_almoxarifado_id",
                table: "saldos");

            migrationBuilder.DropIndex(
                name: "IX_saldos_produto_id",
                table: "saldos");

            migrationBuilder.RenameTable(
                name: "saldos",
                newName: "Saldos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Saldos",
                table: "Saldos",
                column: "Id");
        }
    }
}
