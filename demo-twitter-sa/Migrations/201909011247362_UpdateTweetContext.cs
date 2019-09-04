namespace demo_twitter_sa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTweetContext : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TweetResults", "TweetId", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TweetResults", "TweetId");
        }
    }
}
