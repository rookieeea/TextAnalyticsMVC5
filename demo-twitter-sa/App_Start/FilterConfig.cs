﻿using System.Web;
using System.Web.Mvc;

namespace demo_twitter_sa
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
