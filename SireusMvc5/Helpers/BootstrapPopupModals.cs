using System;
using System.IO;
using System.Web.Mvc;

namespace SireusMvc5.Helpers
{
    public static class BootstrapPopupModals
    {
        public static PopupModal BootstrapPopupModal(this HtmlHelper html, string id, string title, string action,
            string onBeginCallback, string onCompleteCallback, Enums.PopupModalStyle style)
        {
            return new PopupModal(html, id, title, action, onBeginCallback, onCompleteCallback, style);
        }

        public class PopupModal : IDisposable
        {
            private readonly HtmlHelper _helper;
            private readonly Enums.PopupModalStyle _style;
            private readonly TextWriter _writer;

            public PopupModal(HtmlHelper helper, string id, string title, string action, string onBeginCallback,
                string onCompleteCallback, Enums.PopupModalStyle style)
            {
                _writer = helper.ViewContext.Writer;
                _helper = helper;
                _style = style;

                var div = new TagBuilder("div");
                div.AddCssClass("modal fade");
                div.Attributes.Add("id", id);
                div.Attributes.Add("tabindex", "-1");
                div.Attributes.Add("role", "dialog");
                div.Attributes.Add("aria-hidden", "true");
                _writer.WriteLine(div.ToString(TagRenderMode.StartTag));

                div = new TagBuilder("div");
                if (_style == Enums.PopupModalStyle.WideModal)
                {
                    div.AddCssClass("custom-wide-modal");
                }
                div.AddCssClass("modal-dialog");
                _writer.WriteLine(div.ToString(TagRenderMode.StartTag));

                div = new TagBuilder("div");
                div.AddCssClass("modal-content");
                _writer.WriteLine(div.ToString(TagRenderMode.StartTag));

                _writer.WriteLine("<fieldset>");

                var form = new TagBuilder("form");
                form.Attributes.Add("id", id + "-form");
                if (!string.IsNullOrEmpty(action))
                {
                    form.Attributes.Add("action", action);
                    form.Attributes.Add("method", "post");
                    form.Attributes.Add("data-ajax", "true");
                    form.Attributes.Add("data-ajax-mode", "replace");
                    form.Attributes.Add("data-ajax-update", "#ajax-message");
                }
                if (!string.IsNullOrEmpty(onBeginCallback))
                {
                    form.Attributes.Add("data-ajax-begin", onBeginCallback);
                }
                if (!string.IsNullOrEmpty(onCompleteCallback))
                {
                    form.Attributes.Add("data-ajax-complete", onCompleteCallback);
                }
                _writer.WriteLine(form.ToString(TagRenderMode.StartTag));

                var headerdiv = new TagBuilder("div");
                headerdiv.AddCssClass("modal-header");
                _writer.WriteLine(headerdiv.ToString(TagRenderMode.StartTag));

                var dismiss = new TagBuilder("button");
                dismiss.AddCssClass("close");
                dismiss.Attributes.Add("type", "button");
                dismiss.Attributes.Add("id", "close-button");
                dismiss.Attributes.Add("data-dismiss", "modal");
                dismiss.Attributes.Add("aria-hidden", "true");
                dismiss.SetInnerText("&times;");
                _writer.WriteLine(dismiss.ToString().Replace("&amp;", "&"));

                var heading = new TagBuilder("h4");
                heading.Attributes.Add("id", "popup-modal-title");
                heading.AddCssClass("modal-title");
                heading.InnerHtml = ToBootstrapImage(_style) + title;
                _writer.WriteLine(heading.ToString());

                _writer.WriteLine("</div>");

                div = new TagBuilder("div");
                div.AddCssClass("modal-body");
                _writer.WriteLine(div.ToString(TagRenderMode.StartTag));
            }

            public void Dispose()
            {
                var div = new TagBuilder("div");
                div.AddCssClass("panel-body");
                _writer.WriteLine(div.ToString(TagRenderMode.StartTag));
                _writer.WriteLine(_helper.BootstrapErrorField("ajax-message", Enums.MessageFieldStyle.Danger));
                _writer.WriteLine(div.ToString(TagRenderMode.EndTag));

                _writer.WriteLine("</div>"); // modal-body

                if (_style != Enums.PopupModalStyle.WideModal)
                {
                    div = new TagBuilder("div");
                    div.AddCssClass("modal-footer");
                    _writer.WriteLine(div.ToString(TagRenderMode.StartTag));

                    if (_style == Enums.PopupModalStyle.Info || _style == Enums.PopupModalStyle.View)
                    {
                        var close = new TagBuilder("a");
                        close.AddCssClass("btn btn-info");
                        close.Attributes.Add("href", "#");
                        close.Attributes.Add("data-dismiss", "modal");
                        close.SetInnerText("Stäng");
                        _writer.WriteLine(close.ToString());
                    }
                    else
                    {
                        var cancel = new TagBuilder("a");
                        cancel.AddCssClass("btn btn-info");
                        cancel.Attributes.Add("id", "close-button");
                        cancel.Attributes.Add("href", "#");
                        cancel.Attributes.Add("data-dismiss", "modal");
                        cancel.SetInnerText("Avbryt");
                        _writer.WriteLine(cancel.ToString());

                        _writer.WriteLine(_helper.BootstrapButton(ToBootstrapStyle(_style), Enums.ButtonType.Submit,
                            Enums.ButtonStyle.Success, Enums.ButtonSize.Normal));
                    }

                    _writer.WriteLine("</div>");
                }

                _writer.WriteLine("</form>");
                _writer.WriteLine("</fieldset>");
                _writer.WriteLine("</div>");
                _writer.WriteLine("</div>");
                _writer.WriteLine("</div>");
            }

            private static string ToBootstrapStyle(Enums.PopupModalStyle style)
            {
                switch (style)
                {
                    case Enums.PopupModalStyle.Create:
                        return "Skapa";
                    case Enums.PopupModalStyle.Save:
                        return "Spara";
                    case Enums.PopupModalStyle.Secure:
                        return "Uppdatera";
                    case Enums.PopupModalStyle.Info:
                        return "Stäng";
                    case Enums.PopupModalStyle.View:
                        return "Stäng";
                    case Enums.PopupModalStyle.WideModal:
                        return "";
                    default:
                        return "";
                }
            }

            private static string ToBootstrapImage(Enums.PopupModalStyle style)
            {
                switch (style)
                {
                    case Enums.PopupModalStyle.Create:
                        return "<img src=\"/img/create.png\">&nbsp;&nbsp;";
                    case Enums.PopupModalStyle.Save:
                        return "<img src=\"/img/edit.png\">&nbsp;&nbsp;";
                    case Enums.PopupModalStyle.Secure:
                        return "<img src=\"/img/secure.png\">&nbsp;&nbsp;";
                    case Enums.PopupModalStyle.Info:
                        return "<img src=\"/img/info.png\">&nbsp;&nbsp;";
                    case Enums.PopupModalStyle.View:
                        return "<img src=\"/img/view.png\">&nbsp;&nbsp;";
                    case Enums.PopupModalStyle.WideModal:
                        return "";
                    default:
                        return "";
                }
            }
        }
    }
}