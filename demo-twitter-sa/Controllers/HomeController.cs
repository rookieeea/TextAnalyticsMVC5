using System.Web.Mvc;
using DemoTwitterSA.Models;
using TwitterHelper;
using System.Reactive.Linq;
using demo_twitter_sa;
using System.Net.Http;
using System.Web;
using System.Text;
using System.Net.Http.Headers;
using Microsoft.ProjectOxford.Text.Language;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.Text.Core;
using System;

namespace DemoTwitterSA.Controllers
{
    public class HomeController : Controller
    {
        private readonly TweetContext context = new TweetContext();

        public ActionResult Index()
        {
            return View("ListTweets", context.TweetResults);
        }

        public ActionResult GetNewTweets()
        {
            var twitterObserver = new TwitterObserver();
            var twitterConfig = new TwitterConfig(Constants.TWITTER_CONSUMER_KEY, Constants.TWITTER_CONSUMER_SECRET, Constants.TWITTER_ACCESS_TOKEN, Constants.TWITTER_TOKEN_SECRET);
            Services.StreamStatuses(twitterConfig, "Microsoft").ToObservable().Subscribe(twitterObserver);

            return RedirectToAction("ListTweets");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}