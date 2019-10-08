using System;
using System.Collections.Generic;
using System.Text;
using Test1Model;

namespace Test1Services
{
    public interface IStudentService
    {
        List<Student> GetStudentServices();
        void InsertStudentService(Student student);
        void DeleteStudentService(Student student);
    }
}
