namespace SysVYC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        IDUSUARIO = c.Int(nullable: false, identity: true),
                        IDTIPOUSUARIO = c.Int(nullable: false),
                        IDEMPLEADO = c.Int(nullable: false),
                        USERNAME = c.String(),
                        PASSWORD = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.IDUSUARIO);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Usuarios");
        }
    }
}
