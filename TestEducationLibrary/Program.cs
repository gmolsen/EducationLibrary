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

		}
		static void Main(string[] args) {
			new Program().Run();
		}
	}
}
