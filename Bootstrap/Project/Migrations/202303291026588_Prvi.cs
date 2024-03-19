namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Prvi : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ispit",
                c => new
                    {
                        IspitID = c.Int(nullable: false, identity: true),
                        SifraIspita = c.String(nullable: false, maxLength: 15),
                        Naziv = c.String(nullable: false, maxLength: 15),
                    })
                .PrimaryKey(t => t.IspitID);
            
            CreateTable(
                "dbo.PrijavaIspita",
                c => new
                    {
                        IspitID = c.Int(nullable: false),
                        StudentID = c.Int(nullable: false),
                        PredmetID = c.Int(nullable: false),
                        BrojPrethodnihPolaganja = c.String(),
                    })
                .PrimaryKey(t => new { t.IspitID, t.StudentID, t.PredmetID })
                .ForeignKey("dbo.Ispit", t => t.IspitID, cascadeDelete: true)
                .ForeignKey("dbo.Predmet", t => t.PredmetID, cascadeDelete: true)
                .ForeignKey("dbo.Student", t => t.StudentID, cascadeDelete: true)
                .Index(t => t.IspitID)
                .Index(t => t.StudentID)
                .Index(t => t.PredmetID);
            
            CreateTable(
                "dbo.Predmet",
                c => new
                    {
                        PredmetID = c.Int(nullable: false, identity: true),
                        Sifra = c.String(nullable: false, maxLength: 1),
                        Naziv = c.String(maxLength: 15),
                    })
                .PrimaryKey(t => t.PredmetID);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        StudentID = c.Int(nullable: false, identity: true),
                        Ime = c.String(nullable: false, maxLength: 25),
                        Prezime = c.String(nullable: false, maxLength: 25),
                        JMBG = c.String(nullable: false, maxLength: 13),
                        BrojIndeksa = c.String(nullable: false, maxLength: 15),
                        PostanskiBrojGrada = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudentID);
            
            CreateTable(
                "dbo.Primer",
                c => new
                    {
                        StudentID = c.Int(nullable: false, identity: true),
                        Ime = c.String(nullable: false, maxLength: 25),
                        Prezime = c.String(nullable: false, maxLength: 25),
                        JMBG = c.String(nullable: false, maxLength: 13),
                        BrojIndeksa = c.String(nullable: false, maxLength: 15),
                        PostanskiBrojGrada = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudentID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PrijavaIspita", "StudentID", "dbo.Student");
            DropForeignKey("dbo.PrijavaIspita", "PredmetID", "dbo.Predmet");
            DropForeignKey("dbo.PrijavaIspita", "IspitID", "dbo.Ispit");
            DropIndex("dbo.PrijavaIspita", new[] { "PredmetID" });
            DropIndex("dbo.PrijavaIspita", new[] { "StudentID" });
            DropIndex("dbo.PrijavaIspita", new[] { "IspitID" });
            DropTable("dbo.Primer");
            DropTable("dbo.Student");
            DropTable("dbo.Predmet");
            DropTable("dbo.PrijavaIspita");
            DropTable("dbo.Ispit");
        }
    }
}
