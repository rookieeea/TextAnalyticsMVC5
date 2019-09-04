namespace demo_twitter_sa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDbNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TweetResults", "LanguageConfidence", c => c.Single());
            AlterColumn("dbo.TweetResults", "SentimentScore", c => c.Single());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TweetResults", "SentimentScore", c => c.Single(nullable: false));
            AlterColumn("dbo.TweetResults", "LanguageConfidence", c => c.Single(nullable: false));
        }
    }
}
