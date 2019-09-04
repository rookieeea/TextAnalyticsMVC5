using Microsoft.ProjectOxford.Text.Language;
using System;
using System.Collections.Generic;
using System.Globalization;
using TwitterHelper.Models;

namespace DemoTwitterSA
{
    public class TweetResult
    {
        public Int64 Id { get; set; }

        public Int64 TweetId { get; set; }
        //public string Name { get; set; }
        //public string ScreenName { get; set; }
        public DateTime CreatedAt { get; set; }
        public string TimeZone { get; set; }
        //public DetectedLanguage Language { get; set; }
        public string LanguageName { get; set; }
        public float? LanguageConfidence { get; set; }
        public string RawJson { get; set; }
        public string Text { get; set; }
        public float? SentimentScore { get; set; }
        public IList<string> KeyPhrases { get; set; }

        public TweetResult()
        {

        }

        public TweetResult(Tweet tweet)
        {
            this.TweetId = tweet.Id;
            this.Text = tweet.Text;
            ////this.Name = tweet.User != null ? tweet.User.Name : null;
            ////this.ScreenName = tweet.User != null ? tweet.User.ScreenName : null;
            this.CreatedAt = ParseTwitterDateTime(tweet.CreatedAt);
            this.TimeZone = tweet.User != null ? (tweet.User.TimeZone != null ? tweet.User.TimeZone : "(unknown)") : "(unknown)";
            //var language = SentimentService.AnalyzeLanguage(this.TweetId.ToString(), this.Text);
            //this.Language = SentimentService.AnalyzeLanguage(this.TweetId.ToString(), this.Text);
            //this.LanguageName = String.Format("{0}({1})", language.Name, language.Iso639Name);
            //this.LanguageConfidence = language.Score * 100;
            ////this.RawJson = tweet.RawJson;
            //this.SentimentScore = SentimentService.AnalyzeSentiment(this.TweetId.ToString(), this.Text, language.Iso639Name);
            //this.KeyPhrases = SentimentService.AnalyzeKeyPhrases(this.TweetId.ToString(), this.Text, language.Iso639Name);
        }

        private DateTime ParseTwitterDateTime(string p)
        {
            if (p == null)
                return DateTime.Now;
            p = p.Replace("+0000 ", "");
            DateTimeOffset result;

            if (DateTimeOffset.TryParseExact(p, "ddd MMM dd HH:mm:ss yyyy", CultureInfo.GetCultureInfo("en-us").DateTimeFormat, DateTimeStyles.AssumeUniversal, out result))
                return result.DateTime;
            else
                return DateTime.Now;
        }
    }
}
