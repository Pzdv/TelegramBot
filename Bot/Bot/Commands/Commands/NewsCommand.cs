using HtmlAgilityPack;
using System.Collections.Generic;
using System.Linq;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Bot.Commands.Commands
{
	class NewsCommand : Command
	{
		public override string Name { get; set; } = "Новости в России и Удмуртии\n(источник так себе)";

		public override async void Execute(Message message, TelegramBotClient client)
		{
			foreach (var item in GetTheNews())
			{
				await client.SendTextMessageAsync(message.Chat.Id, item);
			}	
		}

		private IEnumerable<string> GetTheNews()
		{
			HtmlWeb hw = new HtmlWeb();
			HtmlDocument docSource = hw.Load("https://yandex.ru/");

			var linkedPages = docSource.DocumentNode.Descendants("a").Where(x=>x.GetAttributeValue("target", null) == "_blank");
								 

			foreach (var item in linkedPages)
			{
				var text = item.GetAttributeValue("aria-label", null);
				var source = item.GetAttributeValue("href", null);

				if (text != null && source != null)
					yield return source;
			}
		}
	}
}
