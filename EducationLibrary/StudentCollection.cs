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

				var majorid = -1;
				if (!reader.GetValue(reader.GetOrdinal("Majorid")).Equals(DBNull.Value)) {
					majorid = reader.GetInt32(reader.GetOrdinal("MajorId"));
				}

				var sat = reader.GetInt32(reader.GetOrdinal("SAT"));
				var gpa = reader.GetDouble(reader.GetOrdinal("GPA"));

				//an instance of Student is created and the values previously harvested
				//from the SQL database are assigned to the propertiest in the Stude
				Student student = new Student();
				student.Id = id;
				student.FirstName = firstName;
				student.LastName = lastName;
				student.Address = address;
				student.City = city;
				student.State = state;
				student.Zipcode = zip;
				student.PhoneNumber = phone;
				student.Email = email;
				student.Birthday = birthday;
				student.MajorId = majorid;
				student.SAT = sat;
				student.GPA = gpa;
				//list is added to students instance of StudentCollection
				students.Add(student);
			}
			reader.Close();
			connection.Close();
			
			//collection of Student (list of students w/ properties such as
			// Id, FirstName, LastName, Address, etc.) is returned
			return students;
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
