using Telegram.Bot;
using Telegram.Bot.Types;

namespace Bot.Commands.Commands
{
	class GetChatIdCommand : Command
	{
		public override string Name { get; set; } = "/getchatid";

		public override async void Execute(Message message, TelegramBotClient client)
		{
			await client.SendTextMessageAsync(message.Chat.Id, $"Id чата: {message.Chat.Id}");
		}
	}
}
