using Microsoft.AspNetCore.Razor.TagHelpers;

namespace WebApplication4.Web.TagHelpers
{
    public class ItalicTaghelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.PreContent.SetHtmlContent("<i>");
            output.PostContent.SetHtmlContent("</li>");



        }
    }
}
