namespace SlotJS_MVVM_SPAS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class playerDb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "PlayerName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "PlayerName");
        }
    }
}
