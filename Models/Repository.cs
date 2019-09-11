using System.Collections.Generic;

namespace CourseApp.Models
{
    public static class Repository
    {
        private static List<StudentResponse> _students = new List<StudentResponse>();

        // Repository.Students

        public static List<StudentResponse> Students
        {
            get
            {
                return _students;
            }
        }

        //Repository.AddStudent(student);
        public static void AddStudent(StudentResponse student)
        {
            _students.Add(student);
        }

    }
}