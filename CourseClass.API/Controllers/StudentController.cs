using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CourseClass.BL.Contracts;
using CourseClass.BL.Domain;

namespace CourseClass.API.Controllers
{
    [Authorize(Roles = "Owner,Sales,Manager")]
    [Route("api/student")]
    [Produces("application/json")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _repo;
        public StudentController(IStudentRepository repo)
        {
            _repo = repo;
        }

        #region Get all students
        [HttpGet]
        public IActionResult GetAllStudents()
        {
            var response = _repo.AllStudents;

            return Ok(response);
        }
        #endregion

        #region Get student by Id
        [HttpGet("{id}")]
        public IActionResult GetStudentById([FromRoute] int id)
        {
            var response = _repo.GetStudentById(id);

            return Ok(response);
        }
        #endregion

        #region Create a new student
        [HttpPost("create")]
        public IActionResult AddNewStudent([FromBody] Student body)
        {
            var response = _repo.AddStudent(body);
            if(response.Result == true)
            {
                return Ok("User created");
            }
            else
            {
                return StatusCode(409);
            }
        }
        #endregion

        #region Edit existing student
        [HttpPut("edit")]
        public IActionResult EditStudent([FromBody] Student body)
        {
            var response = _repo.UpdateStudent(body);
            return Ok(response);
        }
        #endregion

        #region Delete student by id
        [HttpDelete("delete/{id}")]
        public IActionResult DeleteStudent([FromRoute] int id)
        {
            var response = _repo.DeleteStudent(id);
            return Ok(response.Result.ToString());
        }
        #endregion
    }
}