using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using KSV5.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;

namespace KSV5.Services
{
    public class ScraperService
    {
        public List<SprudgeScrape> Scraper()
        {
            var results = new List<SprudgeScrape>();

            var webClient = new WebClient();
            var html = webClient.DownloadString("https://sprudge.com/category/wire");

            //use CSS selectors to find entry
            var parser = new HtmlParser();
            var document = parser.ParseDocument(html);
            var entries = document.QuerySelectorAll(".blog-entry");
            //.OfType<IHtmlAnchorElement>();

            // loop over article and create an object for each

            foreach (var entry in entries)
            {
                var sprudgeScrape = new SprudgeScrape();

                //var titles = entry.GetAttribute("href");

                sprudgeScrape.Title = entry.InnerHtml;

                results.Add(sprudgeScrape);
            }
            return results;


        }
    }
}