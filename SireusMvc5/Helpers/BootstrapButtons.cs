using System.Web.Mvc;

namespace SireusMvc5.Helpers
{
    public static class BootstrapButtons
    {
        public static MvcHtmlString BootstrapButton(this HtmlHelper helper, string caption, Enums.ButtonType type,
            Enums.ButtonStyle style, Enums.ButtonSize size)
        {
            var format = "";
            if (type == Enums.ButtonType.Button)
            {
                format = "<button type=\"button\" class=\"btn btn-{0} {1}\">{2}</button>";
            }
            else if (type == Enums.ButtonType.Submit)
            {
                format = "<input type=\"submit\" class=\"btn btn-{0} {1}\" value=\"{2}\"/>";
            }
            return new MvcHtmlString(string.Format(format, style.ToString().ToLower(), ToBootstrapSize(size), caption));
        }

        public static MvcHtmlString BootstrapButton(this HtmlHelper helper, string id, string caption,
            Enums.ButtonType type, Enums.ButtonStyle style, Enums.ButtonSize size)
        {
            var format = "";
            if (type == Enums.ButtonType.Button)
            {
                format = "<button id=\"{0}\" type=\"button\" class=\"btn btn-{1} {2}\">{3}</button>";
            }
            else if (type == Enums.ButtonType.Submit)
            {
                format = "<input id=\"{0}\" type=\"submit\" class=\"btn btn-{1} {2}\" value=\"{3}\"/>";
            }
            return
                new MvcHtmlString(string.Format(format, id, style.ToString().ToLower(), ToBootstrapSize(size), caption));
        }

        public static MvcHtmlString BootstrapButton(this HtmlHelper helper, string id, string caption,
            Enums.ButtonPosition position, Enums.ButtonType type, Enums.ButtonStyle style, Enums.ButtonSize size)
        {
            var format = "";
            if (type == Enums.ButtonType.Button)
            {
                format = "<button id=\"{0}\" type=\"button\" class=\"btn btn-{1} {2} {3}\">{4}</button>";
            }
            else if (type == Enums.ButtonType.Submit)
            {
                format = "<input id=\"{0}\" type=\"submit\" class=\"btn btn-{1} {2} {3}\" value=\"{4}\"/>";
            }
            return
                new MvcHtmlString(string.Format(format, id, style.ToString().ToLower(), ToBootstrapPosition(position),
                    ToBootstrapSize(size), caption));
        }

        public static MvcHtmlString BootstrapButton(this HtmlHelper helper, string id, string caption,
            Enums.ButtonPosition position, Enums.ButtonType type, Enums.ButtonStyle style, Enums.ButtonSize size,
            string onClick)
        {
            var format = "";
            if (type == Enums.ButtonType.Button)
            {
                format = "<button id=\"{0}\" type=\"button\" class=\"btn btn-{1} {2} {3}\" onclick=\"{5}\">{4}</button>";
            }
            else if (type == Enums.ButtonType.Submit)
            {
                format =
                    "<input id=\"{0}\" type=\"submit\" class=\"btn btn-{1} {2} {3}\" value=\"{4}\" onclick=\"{5}\"/>";
            }
            return
                new MvcHtmlString(string.Format(format, id, style.ToString().ToLower(), ToBootstrapPosition(position),
                    ToBootstrapSize(size), caption, onClick));
        }


        private static string ToBootstrapPosition(Enums.ButtonPosition position)
        {
            switch (position)
            {
                case Enums.ButtonPosition.Left:
                    return "";
                case Enums.ButtonPosition.Center:
                    return "";
                case Enums.ButtonPosition.Right:
                    return "pull-right";
                default:
                    return "";
            }
        }

        private static string ToBootstrapSize(Enums.ButtonSize size)
        {
            switch (size)
            {
                case Enums.ButtonSize.Large:
                    return "btn-lg";
                case Enums.ButtonSize.Small:
                    return "btn-sm";
                case Enums.ButtonSize.ExtraSmall:
                    return "btn-xs";
                default:
                    return "";
            }
        }
    }
}