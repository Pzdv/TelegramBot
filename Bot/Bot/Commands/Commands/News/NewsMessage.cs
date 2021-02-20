using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Bot.Commands.Commands.News
{
	class NewsMessage
	{
		private static string textNews;
		private static List<Tuple<string, string>> DataNews { get; set; }

		public static string TextNews
		{
			get
			{
				GetTheNews();
				DraftingTheText(DataNews);
				return textNews;
			}
		}
		private static void GetTheNews()
		{
			DataNews = new List<Tuple<string, string>>();

			HtmlWeb hw = new HtmlWeb();
			HtmlDocument docSource = hw.Load("https://yandex.ru/");

			var linkedPages = docSource.DocumentNode.Descendants("a").Where(x => x.GetAttributeValue("target", null) == "_blank");


			foreach (var item in linkedPages)
			{
				var title = item.GetAttributeValue("aria-label", null);
				var source = item.GetAttributeValue("href", null);

				if (title != null && source != null)
					DataNews.Add(Tuple.Create(title, source));
			}
		}

		private static void DraftingTheText(List<Tuple<string,string>> dataNews)
		{
			textNews = "";
			var list = dataNews.Select(x => string.Format($"<a href=\"{x.Item2}\">{x.Item1}</a>")).ToList();
			textNews = string.Join("\n\n\n", list);		
		}


	}
}
