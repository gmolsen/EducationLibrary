using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationLibrary {

	//our StudentCollection class is a list of type Student
	public class StudentCollection : List<Student> {

		//static methods can be called without creating an instance
		//this method is a StudentCollection type method, meaning it has the same properties as List<Student>
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
				string connStr = "Server=STUDENT05;Database=DotNetDatabase;Trusted_Connection=yes";
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
			string connStr = "Server=STUDENT05;Database=DotNetDatabase;Trusted_Connection=yes";
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
			return false;
		}
		public static bool Delete(int id) {
			return false;
		}

	}
}
