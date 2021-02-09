using System.Collections.Generic;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace Bot.Commands.Commands
{
	public class StartCommand : Command
	{
		private const string wannaLOL = "Хочу смеяться 5 минут";
		private const string news = "Новости в России и Удмуртии\n(источник так себе)";
		private const string getCats = "Покажи кота!";
		private const string getWeather = "Погода в Ижевске";
		public override string Name { get; set; } = "/start";

		public override void Execute(Message message, TelegramBotClient client)
		{
			client.SendTextMessageAsync(message.Chat.Id, "Выбирай", replyMarkup: GetButton());
		}

		private IReplyMarkup GetButton()
		{
			return new ReplyKeyboardMarkup
			{
				Keyboard = new List<List<KeyboardButton>>
				{
					new List<KeyboardButton> { new KeyboardButton { Text =  wannaLOL}, new KeyboardButton{ Text = news} },
					new List<KeyboardButton> { new KeyboardButton { Text = getCats }, new KeyboardButton{ Text = getWeather} } 
				} 
			};
		}
	}
}
