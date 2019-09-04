using System;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using demo_twitter_sa;
using DemoTwitterSA.Models;
using Microsoft.ProjectOxford.Text.Language;
using TwitterHelper.Models;

namespace DemoTwitterSA
{
    public class TwitterObserver : IObserver<Tweet>
    {
        public void OnCompleted()
        {
            //Console.WriteLine("Done!");
        }

        public void OnError(Exception error)
        {
            //Console.WriteLine(String.Format("Error: ", error.ToString()));
        }

        public void OnNext(Tweet tweet)
        {
            var value = new TweetResult(tweet);

            //LanguageAnalysis.AnalyzeLanguageAsync(tweet.Id.ToString(), tweet.Text).Wait();

            //value.TweetId = tweet.Id;
            //value.Text = tweet.Text;
            //value.CreatedAt = ParseTwitterDateTime(tweet.CreatedAt);
            //value.TimeZone = tweet.User != null ? (tweet.User.TimeZone != null ? tweet.User.TimeZone : "(unknown)") : "(unknown)";
            //value.Language = SentimentService.AnalyzeLanguageAsync(value.TweetId.ToString(), value.Text).Wait();
            var language = SentimentService.AnalyzeLanguage(value.TweetId.ToString(), value.Text);
            value.LanguageName = String.Format("{0}({1})", language.Name, language.Iso639Name);
            value.LanguageConfidence = language.Score * 100;
            //value.RawJson = tweet.RawJson;
            value.SentimentScore = SentimentService.AnalyzeSentiment(value.TweetId.ToString(), value.Text, language.Iso639Name);
            value.KeyPhrases = SentimentService.AnalyzeKeyPhrases(value.TweetId.ToString(), value.Text, language.Iso639Name);

            using (TweetContext context = new TweetContext())
            {
                context.TweetResults.Add(value);
                context.SaveChanges();
            }

            //Console.WriteLine();
            //Console.WriteLine("---------------------------------------------");
            //Console.WriteLine(String.Format("   Tweet From {0} at {1}", value.ScreenName, value.CreatedAt.ToString()));
            //Console.WriteLine("---------------------------------------------");
            //Console.WriteLine(String.Format("   Name: {0}", value.Name));
            //Console.WriteLine(String.Format("   Screen Name: {0}", value.ScreenName));
            //Console.WriteLine(String.Format("   Text: {0}", value.Text));
            //Console.WriteLine(String.Format("   Language: {0}", value.LanguageName));
            //Console.WriteLine(String.Format("   Language Confidence: {0}%", value.LanguageConfidence));
            //Console.WriteLine(String.Format("   Sentiment Score: {0}%", value.SentimentScore));
            //Console.WriteLine("   Key Phrases:");
            //foreach (var keyPhrase in value.KeyPhrases)
            //{
            //    Console.WriteLine(String.Format("      {0}", keyPhrase));
            //}
            //Console.WriteLine(String.Format("   TimeZone: {0}", value.TimeZone));
            //Console.WriteLine();
            //Console.ReadLine();
        }

        private async Task CallTextAnalyticsAPI(Tweet tweet)
        {
            var client = new HttpClient();
            var queryString =
                HttpUtility.ParseQueryString(string.Empty);
            // Request headers
            client.DefaultRequestHeaders.Add("2d882e79-b33c-4365-8068- 62f32c95db95", Constants.API_KEY);

            var uri = Constants.API_URI + queryString;

            HttpResponseMessage response;

            // Request body
            byte[] byteData = Encoding.UTF8.GetBytes("{body}");

            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue
                    ("{'documents':[{'id':'1','text':'{tweet.Text}'}}");
                response = await client.PostAsync(uri, content);
            }

            var result = response;
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
