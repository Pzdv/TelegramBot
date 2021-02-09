using Telegram.Bot;
using Telegram.Bot.Types;

namespace Bot.Commands
{
	class MyIDCommand : Command
	{
		public override string Name { get; set; } =  "/getmyid";

		public override async void Execute(Message message, TelegramBotClient client)
		{
			await client.SendTextMessageAsync(message.Chat.Id, $"Ваш телеграм Id:{message.From.Id}");
		}
	}
}
