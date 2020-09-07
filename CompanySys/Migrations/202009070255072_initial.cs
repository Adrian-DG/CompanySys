namespace CompanySys.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Image = c.String(nullable: false),
                        Name = c.String(nullable: false, maxLength: 20),
                        LastName = c.String(nullable: false, maxLength: 20),
                        Birthday = c.DateTime(nullable: false),
                        Genre = c.Int(nullable: false),
                        Phone = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        PositionID = c.Int(nullable: false),
                        DepartmentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Departments", t => t.DepartmentID, cascadeDelete: false)
                .ForeignKey("dbo.Positions", t => t.PositionID, cascadeDelete: false)
                .Index(t => t.PositionID)
                .Index(t => t.DepartmentID);
            
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Salary = c.Int(nullable: false),
                        DepartmentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Departments", t => t.DepartmentID, cascadeDelete: true)
                .Index(t => t.DepartmentID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Positions", "DepartmentID", "dbo.Departments");
            DropForeignKey("dbo.Employees", "PositionID", "dbo.Positions");
            DropForeignKey("dbo.Employees", "DepartmentID", "dbo.Departments");
            DropIndex("dbo.Positions", new[] { "DepartmentID" });
            DropIndex("dbo.Employees", new[] { "DepartmentID" });
            DropIndex("dbo.Employees", new[] { "PositionID" });
            DropTable("dbo.Positions");
            DropTable("dbo.Employees");
            DropTable("dbo.Departments");
        }
    }
}
