using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace LocacaoFilmes.Data {

	[Obsolete]
	public class DataBase {
		private static MySqlConnection connection = MySqlDbConnection();

		[Obsolete]
		private static MySqlConnection MySqlDbConnection() {
			return new MySqlConnection($@"server = 127.0.0.1; uid = root; pwd = abcd@1234; database = prova2");
		}

		[Obsolete]
		public static bool Execute(string query, int timeout = 30) {
			bool result;
			connection.Open();
			using(MySqlCommand dbc = new MySqlCommand()) {
				dbc.CommandText = query;
				dbc.CommandTimeout = timeout;
				dbc.Connection = connection;
				result = dbc.ExecuteNonQuery() > -1 ? true : false;
			}
			return result;
		}

		[Obsolete]
		public static MySqlDataReader OpenDataReader(string query, int timeout = 30) {
			connection.Open();
			using(MySqlCommand dbc = new MySqlCommand()) {
				dbc.CommandText = query;
				dbc.CommandTimeout = timeout;
				dbc.Connection = connection;
				return dbc.ExecuteReader();
			}

		}
	}
}