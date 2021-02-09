using System.Collections.Generic;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using Bot.Commands.Commands;

namespace Bot.Commands
{
	public class GetAnecdote : Command
	{

		private int anecdoteId;

		public int AnecdoteId 
		{
			get
			{
				return anecdoteId;
			}
		}


		public override string Name { get; set; } = "Хочу смеяться 5 минут";



		public override async void Execute(Message message, TelegramBotClient bot)
		{ 

			var anecdote = NewAnecdote.GetNewAnecdote();
			await bot.SendTextMessageAsync(message.Chat.Id, "Держи анекдот!");
			await bot.SendTextMessageAsync(message.Chat.Id, anecdote, replyMarkup: Keyboard("Смешно", "Не очень)"));

		}


		private IReplyMarkup Keyboard(string a, string b)
		{
			var buttons = new List<InlineKeyboardButton>() 
			{ 
				new InlineKeyboardButton { Text = "Cмешно", CallbackData = a }, 
				new InlineKeyboardButton { Text = "Не очень)", CallbackData = b } 
			};
			return new InlineKeyboardMarkup(buttons);
		}


	}
}
