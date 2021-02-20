using Bot.Commands.Commands.News;
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
			var text = NewsMessage.TextNews;
			await client.SendTextMessageAsync(message.Chat.Id, text, parseMode: Telegram.Bot.Types.Enums.ParseMode.Html, disableWebPagePreview: true);
		}	
	}
}
