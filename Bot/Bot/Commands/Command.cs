using Telegram.Bot;
using Telegram.Bot.Types;

namespace Bot.Commands
{
	public abstract class Command
	{
		public abstract string Name { get; set; }
		public abstract void Execute(Message message, TelegramBotClient client);


		public bool isCommand(string message)
		{
			if (Name == message)
				return true;
			return false;
		}
	}
}
