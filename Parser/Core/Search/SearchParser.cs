using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Html.Dom;

namespace Parser.Core.Habra
{
    class HabraParser : IParser<string[]>
    {
        public string[] Parse(IHtmlDocument document)
        {
            var list = new List<string>();
            var item1 = document.QuerySelectorAll("input").Where(item => item.Id != null && item.Id.Contains("lastname"));
            var item2 = document.QuerySelectorAll("input").Where(item => item.Id != null && item.Id.Contains("firstname"));
            var item3 = document.QuerySelectorAll("input").Where(item => item.Id != null && item.Id.Contains("middlename"));
            var item4 = document.QuerySelectorAll("input").Where(item => item.Id != null && item.Id.Contains("birthday"));
            var item5 = document.QuerySelectorAll("input").Where(item => item.Id != null && item.Id.Contains("org"));
            var item6 = document.QuerySelectorAll("input").Where(item => item.Id != null && item.Id.Contains("phone"));

            foreach (var item in item1)
            {
                list.Add(item.TextContent);
            }

            foreach (var item in item2)
            {
                list.Add(item.TextContent);
            }

            foreach (var item in item3)
            {
                list.Add(item.TextContent);
            }

            foreach (var item in item4)
            {
                list.Add(item.TextContent);
            }

            foreach (var item in item5)
            {
                list.Add(item.TextContent);
            }

            foreach (var item in item6)
            {
                list.Add(item.TextContent);
            }

            return list.ToArray();
        }
    }
}