namespace LIS.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ok : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LotteryShopProfile",
                c => new
                    {
                        LotteryShopProfileID = c.String(nullable: false, maxLength: 128),
                        LotteryShopProfileName = c.String(),
                        LotteryShopProfileLogo = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        FbPageUrl = c.String(),
                        WebSiteUrl = c.String(),
                        Address = c.String(),
                        CreatedUserID = c.String(maxLength: 128),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedUserID = c.String(maxLength: 128),
                        UpdatedDate = c.DateTime(),
                        Active = c.Boolean(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.LotteryShopProfileID)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedUserID)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedUserID)
                .Index(t => t.CreatedUserID)
                .Index(t => t.UpdatedUserID);
            
            AddColumn("dbo.ContactUs", "CreatedUserID", c => c.String(maxLength: 128));
            AddColumn("dbo.ContactUs", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.ContactUs", "UpdatedUserID", c => c.String(maxLength: 128));
            AddColumn("dbo.ContactUs", "UpdatedDate", c => c.DateTime());
            AddColumn("dbo.ContactUs", "Active", c => c.Boolean(nullable: false));
            AddColumn("dbo.ContactUs", "RowVersion", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            CreateIndex("dbo.ContactUs", "CreatedUserID");
            CreateIndex("dbo.ContactUs", "UpdatedUserID");
            AddForeignKey("dbo.ContactUs", "CreatedUserID", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.ContactUs", "UpdatedUserID", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LotteryShopProfile", "UpdatedUserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.LotteryShopProfile", "CreatedUserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.ContactUs", "UpdatedUserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.ContactUs", "CreatedUserID", "dbo.AspNetUsers");
            DropIndex("dbo.LotteryShopProfile", new[] { "UpdatedUserID" });
            DropIndex("dbo.LotteryShopProfile", new[] { "CreatedUserID" });
            DropIndex("dbo.ContactUs", new[] { "UpdatedUserID" });
            DropIndex("dbo.ContactUs", new[] { "CreatedUserID" });
            DropColumn("dbo.ContactUs", "RowVersion");
            DropColumn("dbo.ContactUs", "Active");
            DropColumn("dbo.ContactUs", "UpdatedDate");
            DropColumn("dbo.ContactUs", "UpdatedUserID");
            DropColumn("dbo.ContactUs", "CreatedDate");
            DropColumn("dbo.ContactUs", "CreatedUserID");
            DropTable("dbo.LotteryShopProfile");
        }
    }
}
