using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationLibrary {

	//our StudentCollection class is a list of type Student
	public class StudentCollection : List<Student> {

		//connStr is a property to avoid duplication
		private static string connStr = "Server=STUDENT05;Database=DotNetDatabase;Trusted_Connection=yes";

		//static methods can be called without creating an instance
		//this method is a StudentCollection type method, meaning it has the same properties as List<Student>
		public static StudentCollection Select() {
			//establishing a connection with SQL database (connStr)
			SqlConnection connection = new SqlConnection(connStr);
			connection.Open();
			if (connection.State != System.Data.ConnectionState.Open) {
				Console.WriteLine("SQL connection did not open.");
				return null;
			}
			//once connection is established, we give SQL a command
			StudentCollection students = new StudentCollection();
			var sql = "Select * from Student";
			SqlCommand cmd = new SqlCommand(sql, connection);

			//data from SQL is read using SQLDataReader method "ExecuteReader"
			//and then values are assigned to variables
			SqlDataReader reader = cmd.ExecuteReader();
			while (reader.Read()) {
				Student student = new Student();
				student.SetDataFromReader(reader);
				//list is added to students instance of StudentCollection
				students.Add(student);
			}
			reader.Close();
			connection.Close();
			return students;
		}

			public static Student Select(int id) {
				SqlConnection connection = new SqlConnection(connStr);
				connection.Open();
				if (connection.State != System.Data.ConnectionState.Open) {
					Console.WriteLine("SQL connection did not open.");
					return null;
				}
				StudentCollection students = new StudentCollection();
				var sql = $"Select * from Student where Id = {id}";
				SqlCommand cmd = new SqlCommand(sql, connection);
				SqlDataReader reader = cmd.ExecuteReader();
				while (reader.Read()) {
					Student student = new Student();
					student.SetDataFromReader(reader);
					students.Add(student);
				}
				reader.Close();
				connection.Close();
				if(students.Count ==0) {
					return null;
			}
				else {
				return students[0];
			}
		}
		public static bool Insert(Student student) {
			SqlConnection connection = new SqlConnection(connStr);
			connection.Open();
			if (connection.State != System.Data.ConnectionState.Open) {
				Console.WriteLine("SQL connection did not open.");
				return false;
			}
			StudentCollection students = new StudentCollection();
			var sql = $"Insert into Student (FirstName, LastName, Address, City, State, Zipcode," +
				$"PhoneNumber, Email, Birthday, MajorId, SAT, GPA)" +
				$" VALUES " +
				$"('{student.FirstName}', '{student.LastName}', '{student.Address}', '{student.City}'," +
				$" '{student.State}', '{student.Zipcode}', '{student.PhoneNumber}', '{student.Email}', '{student.Birthday}'," +
				$"{student.MajorId}, {student.SAT}, {student.GPA})";
			SqlCommand cmd = new SqlCommand(sql, connection);
			var recsAffected = cmd.ExecuteNonQuery();
			return (recsAffected == 1);
		}
		public static bool Update(Student student) {
			SqlConnection connection = new SqlConnection(connStr);
			connection.Open();
			if (connection.State != System.Data.ConnectionState.Open) {
				Console.WriteLine("SQL connection did not open.");
				return false;
			}
			StudentCollection students = new StudentCollection();
			var sql = $"UPDATE Student Set " +
						$"FirstName = '{student.FirstName}'," +
						$"LastName = '{student.LastName}'," +
						$"Address = '{student.Address}'," +
						$"City = '{student.City}'," +
						$"State = '{student.State}'," +
						$"Zipcode = '{student.Zipcode}'," +
						$"PhoneNumber = '{student.PhoneNumber}'," +
						$"Email = '{student.Email }'," +
						$"Birthday = '{student.Birthday}'," +
						$"MajorId = {student.MajorId}," +
						$"SAT = {student.SAT }," +
						$"GPA = {student.GPA}" +
						$" WHERE ID = {student.Id}";

			SqlCommand cmd = new SqlCommand(sql, connection);
			var recsAffected = cmd.ExecuteNonQuery();
			return (recsAffected == 1);
		}
		public static bool Delete(int id, int id2, int id3, int id4) {
			SqlConnection connection = new SqlConnection(connStr);
			connection.Open();
			if (connection.State != System.Data.ConnectionState.Open) {
				Console.WriteLine("SQL connection did not open.");
				return false;
			}
			StudentCollection students = new StudentCollection();
			var sql = $"Delete from Student " +
						$" WHERE ID = {id} & {id2} & {id3} & {id4}";

			SqlCommand cmd = new SqlCommand(sql, connection);
			var recsAffected = cmd.ExecuteNonQuery();
			return (recsAffected == 1);
		}

	}
}
