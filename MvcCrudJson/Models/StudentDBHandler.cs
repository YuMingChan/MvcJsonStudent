using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Newtonsoft.Json;
using System.IO;

namespace MvcCrudJson.Models
{
    public class StudentDBHandler
    {
        public static string StudentFile = HttpContext.Current.Server.MapPath("~/App_Data/Student.json");

        public List<StudentModel> GetStudentDetails()
        {
            List<StudentModel> people = new List<StudentModel>();
            if (File.Exists(StudentFile))
            {
                string content = File.ReadAllText(StudentFile);
                people = JsonConvert.DeserializeObject<List<StudentModel>>(content);
                return people;
            }
            else
            {
                File.Create(StudentFile).Close();
                File.WriteAllText(StudentFile, "[]");
                GetStudentDetails();
            }

            return people;
        }

        public bool InsertStudent(StudentModel iList)
        {
            var StudentFile = StudentDBHandler.StudentFile;
            var StudentData = System.IO.File.ReadAllText(StudentFile);
            List<StudentModel> StudentList = new List<StudentModel>();

            StudentList = JsonConvert.DeserializeObject<List<StudentModel>>(StudentData);

            if (StudentList == null)
            {
                StudentList = new List<StudentModel>();
            }

            StudentList.Add(iList);

            System.IO.File.WriteAllText(StudentFile, JsonConvert.SerializeObject(StudentList));

            return true;
        }

        public bool UpdateStudent(StudentModel iList)
        {
            // Get all of the clients
            StudentDBHandler StudentHandler = new StudentDBHandler();
            var students = StudentHandler.GetStudentDetails();

            foreach (StudentModel student in students)
            {
                if (student.ID == iList.ID)
                {
                    student.Name = iList.Name;
                    student.DateOfBirth = iList.DateOfBirth;
                    student.Grade = iList.Grade;


                    break;
                }
            }

            System.IO.File.WriteAllText(StudentDBHandler.StudentFile, JsonConvert.SerializeObject(students));

            return true;
        }

        public bool DeleteStudent(int id)
        {
            StudentDBHandler StudentHandler = new StudentDBHandler();
            var students = StudentHandler.GetStudentDetails();

            foreach (StudentModel student in students)
            {
                if (student.ID == id)
                {
                    var index = students.IndexOf(student);
                    students.RemoveAt(index);
                    System.IO.File.WriteAllText(StudentDBHandler.StudentFile, JsonConvert.SerializeObject(students));
                    break;
                }
            }

            return true;
        }
    }
}