using System;
using System.Data.SqlClient;

namespace Bot.Commands.Commands
{
	public static class NewAnecdote
	{
		private static int anecdoteID;
		public static int AnecdoteId { get { return anecdoteID; } }
		public static string GetNewAnecdote()
		{
			var anecdote = "";
			var random = new Random().Next(9, 130277);
			anecdoteID = random;
			using (var connection = new SqlConnection(Config.get_cs()))
			{
				connection.Open();

				using (var cmd = new SqlCommand($"SELECT anec FROM [Anecs].[dbo].[Anecs] WHERE id = {anecdoteID}", connection))
				{
					using (var rd = cmd.ExecuteReader())
					{
						if (rd.Read())
						{
							anecdote = rd.GetValue(0).ToString();
						}
					}
				}
				connection.Close();
			}
			anecdote = anecdote.Replace("\\n", "\n");
			anecdote = anecdote.Replace("&quot", "\"");
			return anecdote;
		}
	}
}
