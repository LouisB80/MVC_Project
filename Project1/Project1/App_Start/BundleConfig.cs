using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Project1.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Ajout du js
            bundles.Add(new ScriptBundle("~/Scripts").Include("~/Scripts/jquery-3.3.1.js", "~/Scripts/bootstrap.bundle.js"));
            // ajout du css
            bundles.Add(new StyleBundle("~/Content").Include("~/Content/bootstrap.css", "~/Content/font-awesome.css"));
        }
    }
}