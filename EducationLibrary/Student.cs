using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationLibrary {
	public class Student {
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Address { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string Zipcode { get; set; }
		public string PhoneNumber { get; set; }
		public string Email { get; set; }
		public DateTime Birthday { get; set; }
		public int MajorId { get; set; }
		public int SAT { get; set; }
		public double GPA { get; set; }

		public void SetDataFromReader (SqlDataReader reader) {
			Id = reader.GetInt32(reader.GetOrdinal("Id"));
			FirstName = reader.GetString(reader.GetOrdinal("FirstName"));
			LastName = reader.GetString(reader.GetOrdinal("LastName"));
			Address = reader.GetString(reader.GetOrdinal("Address"));
			City = reader.GetString(reader.GetOrdinal("City"));
			State = reader.GetString(reader.GetOrdinal("State"));
			Zipcode = reader.GetString(reader.GetOrdinal("Zipcode"));
			PhoneNumber = reader.GetString(reader.GetOrdinal("PhoneNumber"));
			Email = reader.GetString(reader.GetOrdinal("Email"));
			Birthday = reader.GetDateTime(reader.GetOrdinal("Birthday"));
			SAT = reader.GetInt32(reader.GetOrdinal("SAT"));
			GPA = reader.GetDouble(reader.GetOrdinal("GPA"));
			MajorId = -1;
			if (!reader.GetValue(reader.GetOrdinal("Majorid")).Equals(DBNull.Value)) {
				MajorId = reader.GetInt32(reader.GetOrdinal("MajorId"));
			}
		}
	}
}
