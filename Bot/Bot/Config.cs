
namespace Bot
{
	public static class Config
	{
		public static string Token { get; set; } = "";

		public static string get_cs()
		{
			return "Data Source=DESKTOP-1HVKEB0\\SQLEXPRESS; Initial Catalog = Anecs; User ID = sa; Password = 123456";
		}
	}
}
