using Bot.Commands;
using Bot.Commands.Commands;
using Bot.DataBase;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;

namespace Bot
{
	class Program
	{
		private static TelegramBotClient client;
		private static List<Command> commands;

		static void Main(string[] args)
		{
			client = new TelegramBotClient(Config.Token) { Timeout = TimeSpan.FromSeconds(10) };
			commands = new List<Command>();
			commands.Add(new GetMyIdCommand());
			commands.Add(new GetChatIdCommand());
			commands.Add(new GetCats());
			commands.Add(new GetAnecdote());
			commands.Add(new Start());
			commands.Add(new GetNews());
			commands.Add(new GetWeather());
			client.StartReceiving();
			client.OnCallbackQuery += Client_OnCallbackQuery;
			client.OnMessage += Client_OnMessage1;
			Console.WriteLine("[Log]: бот начал работу");
			Console.ReadKey();
		}

		private async static void Client_OnCallbackQuery(object sender, CallbackQueryEventArgs e)
		{
			
			var id = e.CallbackQuery.Message.Chat.Id;
			var messageData = e.CallbackQuery.Data;
			if (messageData == "Смешно")
			{
				using (var connection = new SqlConnection(Connection.get_cs()))
				{
					connection.Open();
					SqlCommand command = new SqlCommand($"UPDATE [Anecs].[dbo].[Anecs] SET isFunny = isFunny+1 WHERE id = {NewAnecdote.AnecdoteId}", connection);
					command.ExecuteNonQuery();
					command.Dispose();
					connection.Close();
				}
				await client.SendTextMessageAsync(id, "Я знал что тебе понравится");
			}

			if (messageData == "Не очень)")
			{
				using (var connection = new SqlConnection(Connection.get_cs()))
				{
					connection.Open();
					SqlCommand command = new SqlCommand($"UPDATE [Anecs].[dbo].[Anecs] SET isFunny = isFunny-1 WHERE id = {NewAnecdote.AnecdoteId}", connection);
					command.ExecuteNonQuery();
					command.Dispose();
					connection.Close();
				}
				await client.SendTextMessageAsync(id, "Спасибо за твое очень важное мнение");
			}
		}

		private static void Client_OnMessage1(object sender, MessageEventArgs e)
		{

			var message = e.Message;

			if (message.Text != null)
			{
				Console.WriteLine($"пришло сообщение от {message.Chat.FirstName}: {message.Text}");
				foreach (var comm in commands)
				{
					if (comm.isCommand(message.Text))
					{
						comm.Execute(message, client);

						break;
					}
				}
			}
		}



	}
}
