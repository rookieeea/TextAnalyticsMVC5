namespace demo_twitter_sa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveLanguageFromConstructor : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.TweetResults", "Language_Name");
            DropColumn("dbo.TweetResults", "Language_Iso639Name");
            DropColumn("dbo.TweetResults", "Language_Score");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TweetResults", "Language_Score", c => c.Single(nullable: false));
            AddColumn("dbo.TweetResults", "Language_Iso639Name", c => c.String());
            AddColumn("dbo.TweetResults", "Language_Name", c => c.String());
        }
    }
}
