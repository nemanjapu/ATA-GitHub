using ATAarhitektonskiStudio.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Web.SessionState;
using System.Xml.Linq;
using System.Globalization;
using System.Text;

namespace ATAarhitektonskiStudio.Controllers
{
    [SessionState(SessionStateBehavior.Disabled)]
    public class HomeController : BaseController
    {
        public class SitemapNode
        {
            public SitemapFrequency? Frequency { get; set; }
            public DateTime? LastModified { get; set; }
            public double? Priority { get; set; }
            public string Url { get; set; }
        }

        public enum SitemapFrequency
        {
            Never,
            Yearly,
            Monthly,
            Weekly,
            Daily,
            Hourly,
            Always
        }

        public IReadOnlyCollection<SitemapNode> GetSitemapNodes(UrlHelper urlHelper)
        {
            List<SitemapNode> nodes = new List<SitemapNode>();

            string websiteUrl = "http://www.ata.ba";

            nodes.Add(
                new SitemapNode()
                {
                    Url = websiteUrl,
                    Priority = 1
                });
            nodes.Add(
               new SitemapNode()
               {
                   Url = websiteUrl + "/profile",
                   Priority = 1
               });
            nodes.Add(
               new SitemapNode()
               {
                   Url = websiteUrl + "/contact",
                   Priority = 1
               });
            var items = ctx.Project.AsNoTracking().Select(l => new
            {
                ID = l.Id
            }).ToList();
            foreach (var item in items)
            {
                nodes.Add(
                   new SitemapNode()
                   {
                       Url = websiteUrl + "/projects/project/" + item.ID,
                       Frequency = SitemapFrequency.Weekly,
                       Priority = 1
                   });
            }

            return nodes;
        }

        public string GetSitemapDocument(IEnumerable<SitemapNode> sitemapNodes)
        {
            XNamespace xmlns = "http://www.sitemaps.org/schemas/sitemap/0.9";
            XElement root = new XElement(xmlns + "urlset");

            foreach (SitemapNode sitemapNode in sitemapNodes)
            {
                XElement urlElement = new XElement(
                    xmlns + "url",
                    new XElement(xmlns + "loc", Uri.EscapeUriString(sitemapNode.Url)),
                    sitemapNode.LastModified == null ? null : new XElement(
                        xmlns + "lastmod",
                        sitemapNode.LastModified.Value.ToLocalTime().ToString("yyyy-MM-ddTHH:mm:sszzz")),
                    sitemapNode.Frequency == null ? null : new XElement(
                        xmlns + "changefreq",
                        sitemapNode.Frequency.Value.ToString().ToLowerInvariant()),
                    sitemapNode.Priority == null ? null : new XElement(
                        xmlns + "priority",
                        sitemapNode.Priority.Value.ToString("F1", CultureInfo.InvariantCulture)));
                root.Add(urlElement);
            }

            XDocument document = new XDocument(root);
            return document.ToString();
        }

        public ActionResult SitemapXml()
        {
            var sitemapNodes = GetSitemapNodes(this.Url);
            string xml = GetSitemapDocument(sitemapNodes);
            return this.Content(xml, "xml", Encoding.UTF8);
        }

        public ActionResult Index()
        {
            var model = new HomepageViewModel
            {
                Heading1 = ctx.Global.AsNoTracking().FirstOrDefault().Heading1Homepage,
                Heading1Eng = ctx.Global.AsNoTracking().FirstOrDefault().Heading1HomepageEng,
                Heading2 = ctx.Global.AsNoTracking().FirstOrDefault().Heading2Homepage,
                Heading2Eng = ctx.Global.AsNoTracking().FirstOrDefault().Heading2HomepageEng,
                Text = ctx.Global.AsNoTracking().FirstOrDefault().WritingHomepage,
                TextEng = ctx.Global.AsNoTracking().FirstOrDefault().WritingHomepageEng,
                MetaDescription = ctx.MetaTags.AsNoTracking().FirstOrDefault().HomeMetaDescription,
                MetaKeywords = ctx.MetaTags.AsNoTracking().FirstOrDefault().HomeMetaKeywords
            };

            return View(model);
        }
    }
}