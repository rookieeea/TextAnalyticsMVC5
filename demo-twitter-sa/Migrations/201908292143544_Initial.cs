namespace demo_twitter_sa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Logs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false),
                        Action = c.String(),
                        Message = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TweetResults",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CreatedAt = c.DateTime(nullable: false),
                        TimeZone = c.String(),
                        Language_Name = c.String(),
                        Language_Iso639Name = c.String(),
                        Language_Score = c.Single(nullable: false),
                        LanguageName = c.String(),
                        LanguageConfidence = c.Single(nullable: false),
                        RawJson = c.String(),
                        Text = c.String(),
                        SentimentScore = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TweetResults");
            DropTable("dbo.Logs");
        }
    }
}
