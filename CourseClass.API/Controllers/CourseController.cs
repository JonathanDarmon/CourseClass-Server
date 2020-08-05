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
    [Route("api/course")]
    [Produces("application/json")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepository _repo;
        public CourseController(ICourseRepository repo)
        {
            _repo = repo;
        }
        #region Get all courses
        [HttpGet]
        public IActionResult GetAllCourses()
        {
            var response = _repo.AllCourses;

            return Ok(response);
        }
        #endregion

        #region Get course by Id
        [HttpGet("{id}")]
        public IActionResult GetCourseById([FromRoute] int id)
        {
            var response = _repo.GetCourseById(id);

            return Ok(response);
        }
        #endregion

        #region Create a new course
        [HttpPost("create")]
        public IActionResult AddNewCourse([FromBody] Course body)
        {
            var response = _repo.AddCourse(body);
            return Ok(response.Result.ToString());
        }
        #endregion

        #region Edit existing course
        [HttpPut("edit")]
        public IActionResult EditStudent([FromBody] Course body)
        {
            var response = _repo.UpdateCourse(body);
            return Ok(response);
        }
        #endregion

        #region Delete course by id
        [HttpDelete("delete/{id}")]
        public IActionResult DeleteCourse([FromRoute] int id)
        {
            var response = _repo.DeleteCourse(id);
            return Ok(response.Result.ToString());
        }
        #endregion
    }
}