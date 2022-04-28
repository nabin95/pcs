namespace PCS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        EmpName = c.String(),
                        DOB = c.DateTime(nullable: false),
                        Gender = c.String(),
                        Salary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Entry_By = c.String(),
                        EntryDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeId);
            
            CreateTable(
                "dbo.QualificationLists",
                c => new
                    {
                        QualificationId = c.Int(nullable: false, identity: true),
                        QName = c.String(),
                    })
                .PrimaryKey(t => t.QualificationId);
            
            CreateTable(
                "dbo.EmpQualifications",
                c => new
                    {
                        QulId = c.Int(nullable: false, identity: true),
                        Marks = c.Single(nullable: false),
                        Employee_EmployeeId = c.Int(),
                        QualificationList_QualificationId = c.Int(),
                    })
                .PrimaryKey(t => t.QulId)
                .ForeignKey("dbo.Employees", t => t.Employee_EmployeeId)
                .ForeignKey("dbo.QualificationLists", t => t.QualificationList_QualificationId)
                .Index(t => t.Employee_EmployeeId)
                .Index(t => t.QualificationList_QualificationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmpQualifications", "QualificationList_QualificationId", "dbo.QualificationLists");
            DropForeignKey("dbo.EmpQualifications", "Employee_EmployeeId", "dbo.Employees");
            DropIndex("dbo.EmpQualifications", new[] { "QualificationList_QualificationId" });
            DropIndex("dbo.EmpQualifications", new[] { "Employee_EmployeeId" });
            DropTable("dbo.EmpQualifications");
            DropTable("dbo.QualificationLists");
            DropTable("dbo.Employees");
        }
    }
}
