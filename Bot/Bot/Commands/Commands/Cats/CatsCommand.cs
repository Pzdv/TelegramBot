using HtmlAgilityPack;
using System.Linq;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Bot.Commands.Commands
{
	class CatsCommand : Command
	{
		public override string Name { get; set; } = "Покажи кота!";

		public override async void Execute(Message message, TelegramBotClient client)
		{
			var source = GetAnyCats();
			await client.SendPhotoAsync(message.Chat.Id, source);
		}


		private string GetAnyCats()
		{
			HtmlWeb hw = new HtmlWeb();
			HtmlDocument docSource = hw.Load("http://theoldreader.com/kittens/600/400/js");

			var linkedPage = docSource.DocumentNode.Descendants("img")
								  .Where(x => x.GetAttributeValue("src", null) != null )
								  .ToList()
								  .First();

			var source = linkedPage.GetAttributeValue("src", null);

			if (source != null)
				return "https://theoldreader.com" + source;

			else return GetAnyCats();
		}
	}
}
