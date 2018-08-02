namespace Arthur.ORM.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Modificado_mapeador : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.TBFuncionario", name: "TBFuncionario", newName: "CargoId");
            RenameColumn(table: "dbo.TBFuncionario", name: "TBDepartamento", newName: "DepartamentoId");
            RenameIndex(table: "dbo.TBFuncionario", name: "IX_TBFuncionario", newName: "IX_CargoId");
            RenameIndex(table: "dbo.TBFuncionario", name: "IX_TBDepartamento", newName: "IX_DepartamentoId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.TBFuncionario", name: "IX_DepartamentoId", newName: "IX_TBDepartamento");
            RenameIndex(table: "dbo.TBFuncionario", name: "IX_CargoId", newName: "IX_TBFuncionario");
            RenameColumn(table: "dbo.TBFuncionario", name: "DepartamentoId", newName: "TBDepartamento");
            RenameColumn(table: "dbo.TBFuncionario", name: "CargoId", newName: "TBFuncionario");
        }
    }
}
