using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test1Model;
using Test1Services;

namespace TestProject.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Student")]
    public class StudentController : Controller
    {


        //StudentService _StudentService =new StudentService();

        //[HttpGet("GetStudent")]
        //public ActionResult GetStudent()
        //{
        //    List<Student> student = new List<Student>();
        //    student = _StudentService.GetStudentServices();
        //    return Ok(student);
        //}

        IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            this._studentService = studentService;
        }
       [HttpGet("GetStudent")]
        public ActionResult GetStudent()
        {
            List<Student> student = new List<Student>();
            student = _studentService.GetStudentServices();
            return Ok(student);
        }

        [HttpPost("PostStudent")]
        public ActionResult PostStudent(Student student)
        {
            _studentService.InsertStudentService(student);
            return Ok("aa");
        }

        [HttpDelete("DeleteStudent")]
        public ActionResult DeleteStudent(Student student)
        {
            _studentService.DeleteStudentService(student);
            return Ok("dd");
        }
    }
}