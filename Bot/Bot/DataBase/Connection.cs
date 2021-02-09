using System;
using System.Collections.Generic;
using System.Text;

namespace Bot.DataBase
{
	static  class Connection
	{
		public static  string get_cs()
		{
			return "Data Source=DESKTOP-1HVKEB0\\SQLEXPRESS; Initial Catalog = Anecs; User ID = sa; Password = 123456";
		}
	}
}
