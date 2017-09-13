using EducationLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEducationLibrary {
	class Program {
		void Run() {
			StudentCollection students = StudentCollection.Select();
			Student greg = StudentCollection.Select(106);
			Student doesNotExist = StudentCollection.Select(0); //null test
			Student std = new Student();
			std.FirstName = "Test";
			std.LastName = "Test";
			std.Address = "Test";
			std.City = "Test";
			std.State = "OH";
			std.Zipcode = "Test";
			std.Birthday = new DateTime(2017, 9, 13);
			std.PhoneNumber = "5555555555";
			std.Email = "666@666.org";
			std.MajorId = 2;
			std.SAT = 1600;
			std.GPA = 4.0;
			bool rc = StudentCollection.Insert(std);
		}
		static void Main(string[] args) {
			new Program().Run();
		}
	}
}
