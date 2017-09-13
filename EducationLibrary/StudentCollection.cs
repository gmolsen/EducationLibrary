using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationLibrary {

	public class StudentCollection : List<Student> {

		//static methods can be called without creating an instance
		public static StudentCollection Select() {
			//establishing a connection with SQL database
			string connStr = "Server=STUDENT05;Database=DotNetDatabase;Trusted_Connection=yes";
			SqlConnection connection = new SqlConnection(connStr);
			connection.Open();
			if (connection.State != System.Data.ConnectionState.Open) {
				Console.WriteLine("SQL connection did not open.");
				return null;
			}
			//once connection is established, we give SQL a command
			var sql = "Select * from Student";
			SqlCommand cmd = new SqlCommand(sql, connection);

			//data from SQL is read using SQLDataReader method "ExecuteReader"
			SqlDataReader reader = cmd.ExecuteReader();
			while (reader.Read()) {
				var id = reader.GetInt32(reader.GetOrdinal("Id"));
				var firstName = reader.GetString(reader.GetOrdinal("FirstName"));
				var lastName = reader.GetString(reader.GetOrdinal("LastName"));
				var address = reader.GetString(reader.GetOrdinal("Address"));
				var city = reader.GetString(reader.GetOrdinal("City"));
				var state = reader.GetString(reader.GetOrdinal("State"));
				var zip = reader.GetString(reader.GetOrdinal("Zipcode"));
				var phone = reader.GetString(reader.GetOrdinal("PhoneNumber"));
				var email = reader.GetString(reader.GetOrdinal("Email"));
				var birthday = reader.GetDateTime(reader.GetOrdinal("Birthday"));
			}
				return null;
		}
		public static Student Select(int id) {
			return null;
		}
		public static bool Insert(Student student) {
			return false;
		}
		public static bool Update(Student student) {
			return false;
		}
		public static bool Delete(int id) {
			return false;
		}

	}
}
