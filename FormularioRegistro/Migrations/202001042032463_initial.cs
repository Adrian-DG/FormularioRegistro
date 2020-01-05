namespace FormularioRegistro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ImagePath = c.String(),
                        Nombre = c.String(nullable: false, maxLength: 10),
                        Apellido = c.String(nullable: false, maxLength: 10),
                        Genre = c.Int(nullable: false),
                        FechaNac = c.DateTime(nullable: false),
                        Correo = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Clientes");
        }
    }
}
