using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Features
{
    internal class Anonymous_Demo
    {       
        public object print()
        {
            //  Example: Anonymous Type
            var student = new { ID = 1, FirstName = "Ram", LastName = "Shyam" };

            Console.WriteLine(student.ID);
            //  student.ID = 2;  //Error: cannot chage value

            //  Example: Nested Anonymous Type
            var student1 = new
            {
                ID = 1,
                FirstName = "Ram",
                Address = new { City = "london", Country = "UK" }
            };          
            return student1;
        }
      
        //Example: LINQ Query returns an Anonymous Type
       public void Linq_Demo()
        {
            // Mostly, anonymous types are created using the Select clause of a LINQ queries
            // to return a subset of the properties from each object in the collection.
                        
            IList<Student> studentList = new List<Student>() {
                        new Student() { StudentID = 1, StudentName = "John", age = 18 },
                        new Student() { StudentID = 2, StudentName = "Steve",  age = 21 },
                        new Student() { StudentID = 3, StudentName = "Bill",  age = 18 },
                        new Student() { StudentID = 4, StudentName = "Ram" , age = 20  },
                        new Student() { StudentID = 5, StudentName = "Ron" , age = 21 }
            };

            var localStudents = studentList
                                .Select ( s => new { s.StudentID, s.StudentName });
            // <Student,{ new T { StudentID = 1, StudentName = "" }} > 
        }

        public class Student
        {
            public int StudentID { get; set; }
            public string StudentName { get; set; }
            public int age { get; set; }
        }
    }
}
