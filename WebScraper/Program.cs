using HtmlAgilityPack;
using System;
using System.Net.Http;


namespace WebScraper
{
    class Program
    {
        static void Main(String[] args)
        {
            // iタウンページにリクエストを送る
            string url = "https://itp.ne.jp/genre?genre=%E3%82%B0%E3%83%AB%E3%83%A1%E3%83%BB%E9%A3%B2%E9%A3%9F&sbmap=false&sort=01&subgenre=31";
            var httpClient = new HttpClient();
            var html = httpClient.GetStringAsync(url).Result;
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            // 名前を得る
//            var nameElement= htmlDocument.DocumentNode.SelectSingleNode("//div[@class='HcOXKn SxM0TO QxJLC3 ONIxfn comp-lgurqbw5 wixui-rich-text wixui-dev-only-searchResultsTop-title dev-only-searchResultsTop-title']");
//            var name = nameElement.InnerText.Trim();
//            Console.WriteLine("なまえは、" + name);



            // 住所を得る
            var addressElement = htmlDocument.DocumentNode.SelectSingleNode("//div[@class='HcOXKn SxM0TO QxJLC3 comp-lgurqbwe5 wixui-rich-text wixui-dev-only-searchResultsTop-address dev-only-searchResultsTop-address']");
            var address = addressElement.InnerText.Trim();
            Console.WriteLine("住所は、" + address);
            

            // 電話番号を得る
            var numTELElement = htmlDocument.DocumentNode.SelectSingleNode("//div[@class='HcOXKn SxM0TO QxJLC3 comp-lgurqbwy5 wixui-rich-text wixui-dev-only-searchResultsTop-phone dev-only-searchResultsTop-phone']");
            var numTEL = numTELElement.InnerText.Trim();
            Console.WriteLine("電話番号は、" + numTEL);
        }
    }
}
