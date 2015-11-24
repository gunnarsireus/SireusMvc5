using System.Web.Mvc;

namespace SireusMvc5.Helpers
{
    public static class BootstrapFooters
    {
        public static MvcHtmlString BootstrapFooter(this HtmlHelper helper)
        {
            var url = new UrlHelper(helper.ViewContext.RequestContext);
            var img = url.Content("~/img/progress.gif");

            var html =
                @"<footer style=""margin-top:60px"">
                    <div class=""container"">
                      <hr />
                      <p style=""text-align:center"">" + "Siréus Consulting AB" + @"</p>
                      <div id=""progress-indicator"" hidden>
                        <img class=""center-block"" src=""" + img + @""">
                      </div>
                    </div>
                  </footer>";
            return new MvcHtmlString(html);
        }
    }
}