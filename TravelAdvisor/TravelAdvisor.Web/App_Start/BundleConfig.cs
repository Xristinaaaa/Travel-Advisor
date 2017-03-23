﻿using System.Web.Optimization;

namespace TravelAdvisor.Web
{
	public class BundleConfig
	{
		// For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
						"~/Scripts/jquery-{version}.js",
						"~/Scripts/jquery.easing.1.3.js",
						"~/Scripts/jquery.unobtrusive-ajax.min.js"));

			bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
						"~/Scripts/jquery.validate*"));

			// Use the development version of Modernizr to develop with and learn from. Then, when you're
			// ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
			bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
						"~/Scripts/modernizr-*"));

			bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
					  "~/Scripts/bootstrap.js",
					  "~/Scripts/respond.js"));

			bundles.Add(new StyleBundle("~/Content/css").Include(
					  "~/Content/Fonts.css",
					  "~/Content/External/Bootstrap/bootstrap.css",
					  "~/Content/External/FontAwesome/font-awesome.css",
					  "~/Content/Site.css"));

			bundles.Add(new StyleBundle("~/Content/home").Include(
					  "~/Content/Views/Home/destinations.css",
					  "~/Content/Views/Home/header.css",
					  "~/Content/Views/Home/home.css",
					  "~/Content/Views/Home/services.css",
					  "~/Content/Views/Home/testimonials.css"));

			bundles.Add(new StyleBundle("~/Content/register").Include(
					  "~/Content/Views/Account/register.css"));

			bundles.Add(new StyleBundle("~/Content/admin").Include(
					  "~/Content/Admin/Views/Administration/administration.css",
					  "~/Content/Admin/Views/common.css"));
		}
	}
}
