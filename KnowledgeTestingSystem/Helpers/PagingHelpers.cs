using System;
using System.Text;
using System.Web.Mvc;
using KnowledgeTestingSystem.Models;

namespace KnowledgeTestingSystem.Helpers
{
    public static class PagingHelpers
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html,
            PageViewModel pageViewModel, Func<int, string> pageUrl)
        {
            var result = new StringBuilder();
            for (var i = 1; i <= pageViewModel.TotalPages; i++)
            {
                var tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml = i.ToString();
                if (i == pageViewModel.PageNumber)
                {
                    tag.AddCssClass("selected");
                    tag.AddCssClass("btn-primary");
                }

                tag.AddCssClass("btn btn-default");
                result.Append(tag);
            }

            return MvcHtmlString.Create(result.ToString());
        }
    }
}