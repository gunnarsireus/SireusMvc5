using System.Web.Mvc;

namespace SireusMvc5.Helpers
{
    public static class BootstrapMessageFields
    {
        public static MvcHtmlString BootstrapErrorField(this HtmlHelper helper, string id, Enums.MessageFieldStyle style)
        {
            var format = "<div id=\"{0}\" class=\"alert alert-{1}\" hidden />";
            return new MvcHtmlString(string.Format(format, id, style.ToString().ToLower()));
        }
    }
}