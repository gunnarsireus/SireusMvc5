using System;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace SireusMvc5.Helpers
{
    public static class BootstrapSpans
    {
        public static MvcHtmlString BootstrapSpan(this HtmlHelper helper, Enums.SpanType type, Enums.SpanStyle style)
        {
            var format = "<span class=\"{0}\">\n<span class=\"{1}\"></span>\n</span>";
            return new MvcHtmlString(string.Format(format, ToBootstrapType(type), ToBootstrapStyle(style)));
        }

        public static MvcHtmlString BootstrapSpan(this HtmlHelper helper, Enums.SpanType type, string label)
        {
            var format = "<span class=\"{0}\">{1}</span>";
            return new MvcHtmlString(string.Format(format, ToBootstrapType(type), label));
        }

        public static MvcHtmlString BootstrapSpan<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
            Enums.SpanType type, Expression<Func<TModel, TProperty>> expression)
        {
            var metaData = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            var value = metaData.DisplayName ??
                        (metaData.PropertyName ?? ExpressionHelper.GetExpressionText(expression));
            var format = "<span class=\"{0}\">{1}</span>";
            return new MvcHtmlString(string.Format(format, ToBootstrapType(type), MvcHtmlString.Create(value)));
        }

        private static string ToBootstrapType(Enums.SpanType type)
        {
            switch (type)
            {
                case Enums.SpanType.InputGroupAddon:
                    return "input-group-addon";
                default:
                    return "";
            }
        }

        // http://getbootstrap.com/components/
        private static string ToBootstrapStyle(Enums.SpanStyle style)
        {
            switch (style)
            {
                case Enums.SpanStyle.User:
                    return "glyphicon glyphicon-user";
                case Enums.SpanStyle.Customer:
                case Enums.SpanStyle.Organization:
                    return "glyphicon glyphicon-th-list";
                case Enums.SpanStyle.Email:
                    return "glyphicon glyphicon-envelope";
                case Enums.SpanStyle.Phone:
                    return "glyphicon glyphicon-phone-alt";
                case Enums.SpanStyle.Avatar:
                    return "glyphicon glyphicon-film";
                case Enums.SpanStyle.Password:
                case Enums.SpanStyle.DeviceKey:
                    return "glyphicon glyphicon-lock";
                case Enums.SpanStyle.Active:
                    return "glyphicon glyphicon-off";
                case Enums.SpanStyle.Authorization:
                    return "glyphicon glyphicon-ban-circle";
                case Enums.SpanStyle.ID:
                case Enums.SpanStyle.Code:
                case Enums.SpanStyle.Category:
                    return "glyphicon glyphicon-tag";
                case Enums.SpanStyle.Comment:
                    return "glyphicon glyphicon-comment";
                case Enums.SpanStyle.Name:
                    return "glyphicon glyphicon-credit-card";
                case Enums.SpanStyle.Location:
                    return "glyphicon glyphicon-map-marker";
                case Enums.SpanStyle.Task:
                    return "glyphicon glyphicon-search";
                case Enums.SpanStyle.Description:
                    return "glyphicon glyphicon-list-alt";
                case Enums.SpanStyle.Notes:
                    return "glyphicon glyphicon-pencil";
                case Enums.SpanStyle.Firstday:
                    return "glyphicon glyphicon-step-backward";
                case Enums.SpanStyle.Lastday:
                    return "glyphicon glyphicon-step-forward";
                case Enums.SpanStyle.Doneday:
                    return "glyphicon glyphicon-pause";
                case Enums.SpanStyle.Calendar:
                    return "glyphicon glyphicon-calendar";
                case Enums.SpanStyle.Time:
                    return "glyphicon glyphicon-time";
                case Enums.SpanStyle.Amount:
                    return "glyphicon glyphicon-shopping-cart";
                case Enums.SpanStyle.ProblemArea:
                case Enums.SpanStyle.ProblemType:
                    return "glyphicon glyphicon-warning-sign";
                case Enums.SpanStyle.State:
                    return "glyphicon glyphicon-cog";
                case Enums.SpanStyle.Coordinate:
                    return "glyphicon glyphicon-record";
                default:
                    return "";
            }
        }
    }
}