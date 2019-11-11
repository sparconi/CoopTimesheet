using System;
using System.Web;
using System.Web.UI;

namespace CoopTimesheet.Common
{
	public static class ResponseHelper
	{
		public static void Redirect(this HttpResponse response, string url, string target, string windowFeatures)
		{
			if ((String.IsNullOrEmpty(target) || target.Equals("_self", StringComparison.OrdinalIgnoreCase)) && String.IsNullOrEmpty(windowFeatures))
			{
				response.Redirect(url);
			}
			else
			{
				Page page = (Page)HttpContext.Current.Handler;
				if (page == null)
				{
					throw new InvalidOperationException("Cannot redirect to new window outside Page context.");
				}
				url = page.ResolveClientUrl(url);
				string script;
				if (!String.IsNullOrEmpty(windowFeatures))
				{
					script = @"window.open(""{0}"", ""{1}"", ""{2}"");";
				}
				else
				{
					script = @"window.open(""{0}"", ""{1}"");";
				}
				script = String.Format(script, url, target, windowFeatures);
				ScriptManager.RegisterStartupScript(page, typeof(Page), "Redirect", script, true);
			}
			
		}
		public static string CreateTestLink(string url)
		{
			string testLink = "window.open('" + url +
			                  "','','toolbar=no,location=no,directories=yes,status=no,menubar=no,scrollbars=yes,resizable=yes,copyhistory=yes, width=700, height=500,left=30,top=30');return false;";

			return testLink;
		}
	}
}
