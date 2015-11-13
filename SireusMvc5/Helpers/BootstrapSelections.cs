using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;

namespace SireusMvc5.Helpers
{
    public static class BootstrapSelections
    {
        public static MvcHtmlString BootstrapSelectList(this HtmlHelper helper, string id,
            IEnumerable<SelectListItem> items)
        {
            return BootstrapSelectList(helper, id, null, items, null, false);
        }

        public static MvcHtmlString BootstrapSelectList(this HtmlHelper helper, string id, string firstoption,
            IEnumerable<SelectListItem> items)
        {
            return BootstrapSelectList(helper, id, firstoption, items, null, false);
        }

        public static MvcHtmlString BootstrapSelectList(this HtmlHelper helper, string id, string firstoption,
            IEnumerable<SelectListItem> items, string selected)
        {
            return BootstrapSelectList(helper, id, firstoption, items, selected, false);
        }

        public static MvcHtmlString BootstrapSelectListHidden(this HtmlHelper helper, string id, string firstoption,
            IEnumerable<SelectListItem> items)
        {
            return BootstrapSelectList(helper, id, firstoption, items, null, true);
        }

        public static MvcHtmlString BootstrapSelectListMonths(this HtmlHelper helper, string id, int monthmask)
        {
            string[] MONTHS =
            {
                "Jan",
                "Feb",
                "Mar",
                "Apr",
                "May",
                "Jun",
                "Jul",
                "Aug",
                "Sep",
                "Oct",
                "Nov",
                "Dec"
            };

            var builder = new StringBuilder();

            var select = new TagBuilder("select");
            select.AddCssClass("selectpicker");
            select.Attributes.Add("id", id);
            select.Attributes.Add("name", id);
            select.Attributes.Add("data-width", "100%");
            select.Attributes.Add("multiple", "multiple");
            select.Attributes.Add("title", "Inga månader valda");
            select.Attributes.Add("data-selected-text-format", "count>8");
            select.Attributes.Add("data-count-selected-text", "{0} av {1} valda");
            builder.AppendLine(select.ToString(TagRenderMode.StartTag));

            var mask = 0x0001;
            for (var i = 0; i < 12; i++)
            {
                var option = new TagBuilder("option");
                option.Attributes.Add("value", mask.ToString());
                option.InnerHtml = MONTHS[i];
                if ((mask & monthmask) > 0)
                {
                    option.Attributes.Add("selected", "selected");
                }
                mask <<= 1;
                builder.AppendLine(option.ToString(TagRenderMode.Normal));
            }
            builder.AppendLine(select.ToString(TagRenderMode.EndTag));
            return new MvcHtmlString(builder.ToString());
        }

        private static MvcHtmlString BootstrapSelectList(this HtmlHelper helper, string id, string firstoption,
            IEnumerable<SelectListItem> items, string selected, bool hidden)
        {
            var builder = new StringBuilder();

            var select = new TagBuilder("select");
            select.AddCssClass("selectpicker");
            if (hidden)
            {
                select.Attributes.Add("style", "visibility:hidden;");
            }
            select.Attributes.Add("id", id);
            select.Attributes.Add("name", id);
            select.Attributes.Add("data-width", "100%");
            builder.AppendLine(select.ToString(TagRenderMode.StartTag));

            if (firstoption != null)
            {
                var option = new TagBuilder("option");
                option.Attributes.Add("value", "");
                option.InnerHtml = firstoption;
                builder.AppendLine(option.ToString(TagRenderMode.Normal));
            }

            if (items != null)
            {
                foreach (var item in items)
                {
                    var option = new TagBuilder("option");
                    option.Attributes.Add("value", item.Value);
                    option.InnerHtml = item.Text;
                    if (item.Value == selected)
                    {
                        option.Attributes.Add("selected", "selected");
                    }
                    builder.AppendLine(option.ToString(TagRenderMode.Normal));
                }
            }

            builder.AppendLine(select.ToString(TagRenderMode.EndTag));
            return new MvcHtmlString(builder.ToString());
        }
    }
}