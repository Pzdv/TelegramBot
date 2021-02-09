using Telegram.Bot;
using Telegram.Bot.Types;


namespace Bot.Commands.Commands
{
	class GetWeather : Command
	{
		public override string Name { get; set; } = "Погода в Ижевске";

		public override async void Execute(Message message, TelegramBotClient client)
		{
			var weatherResponse = Weather.Weather.GettingWeather();
			string text = "";
			var temperature = (int)weatherResponse.Main.Temp;
			if (temperature <= -15 && temperature > -25)
			{
				text = $"В ижевске сейчас относительная пизда. Температура воздуха {temperature}";
			}
			if(temperature <=-25 )
			{
				text = $"В ижевске полный пиздец. Температура воздуха {temperature}. ";
			}
			if(temperature<= 0 && temperature > -15)
			{
				text = $"НУ вот погода уже приближается к адекватной. Температура воздуха {temperature}";
			}
			
			//реализовать остальные температура и др. погодные условия

			await client.SendTextMessageAsync(message.Chat.Id, text);
		}
	}
}
