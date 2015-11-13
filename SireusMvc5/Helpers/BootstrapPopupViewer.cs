using System.Web.Mvc;

namespace SireusMvc5.Helpers
{
    public static class BootstrapPopupViewers
    {
        public static MvcHtmlString BootstrapPopupViewer(this HtmlHelper helper, string id, string title)
        {
            const int WIDTH = 800;
            const int HEIGHT = 680;
            const int IMG_SMALL_DIM = 320;
            const int IMG_LARGE_DIM = 640;
            const int MGN_PORT_TOP = (HEIGHT - IMG_LARGE_DIM - 32)/2;
            const int MGN_PORT_LEFT = (WIDTH - IMG_SMALL_DIM - 32)/2;
            const int MGN_LAND_TOP = (HEIGHT - IMG_SMALL_DIM - 32)/2;
            const int MGN_LAND_LEFT = (WIDTH - IMG_LARGE_DIM - 32)/2;

            var url = new UrlHelper(helper.ViewContext.RequestContext);
            var progressimage = url.Content("~/img/progress.gif");

            var html =
                @"<div class=""modal fade"" id=""" + id + @""" tabindex=""-1"" role=""dialog"" aria-labelledby=""" +
                title + @""" aria-hidden=""true"">
                    <div class=""modal-dialog"" style=""width:" + WIDTH + @"px;height:" + HEIGHT + @"px;"">
                      <div class=""modal-content"">
                        <div class=""modal-header"">
                          <button type=""button"" class=""close"" data-dismiss=""modal"">
                            <span aria-hidden=""true"">&times;</span>
                            <span class=""sr-only"">" + "Stäng" + @"</span>
                          </button>
                          <h4 class=""modal-title"" id=""title"">" + title + @"</h4>
                        </div>
                        <div class=""modal-body"" style=""background-color:black;width:" + WIDTH + @"px;height:" +
                HEIGHT + @"px;"">
                          <img src="""" id=""image-portrait""  style=""width:" + IMG_SMALL_DIM + @"px;height:" +
                IMG_LARGE_DIM + @"px;margin-top:" + MGN_PORT_TOP + @"px;margin-left:" + MGN_PORT_LEFT + @"px;"">
                          <img src="""" id=""image-landscape"" style=""width:" + IMG_LARGE_DIM + @"px;height:" +
                IMG_SMALL_DIM + @"px;margin-top:" + MGN_LAND_TOP + @"px;margin-left:" + MGN_LAND_LEFT + @"px;"">
                          <a class=""left carousel-control"" href=""#"" id=""prev-carousel-button"">
                            <span class=""glyphicon glyphicon-chevron-left"" aria-hidden=""true""></span>
                          </a>
                          <a class=""right carousel-control"" href=""#"" id=""next-carousel-button"">
                            <span class=""glyphicon glyphicon-chevron-right"" aria-hidden=""true""></span>
                          </a>
                        </div>
                        <div class=""modal-footer"">
                          <div class=""row"">
                            <div class=""col-md-4"">
                            </div>
                            <div class=""col-md-4"">
                              <div id=""photo-progress-indicator"" hidden>
                                <img class=""center-block"" src=""" + progressimage + @""">
                              </div>
                            </div>
                            <div class=""col-md-4"">
                              <button type=""button"" class=""btn btn-default"" data-dismiss=""modal"">" + "Stäng" +
                @"</button>
                            </div>
                          </div>
                        </div>
                      </div>
                    </div>
                  </div>";
            return new MvcHtmlString(html);
        }
    }
}