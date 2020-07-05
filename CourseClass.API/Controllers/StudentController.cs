﻿using System;
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
    [Authorize]
    [Route("api/student")]
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
        public async Task<IActionResult> GetAllStudents()
        {
            var response = _repo.AllStudents;

            return Ok(response);
        }
        #endregion

        #region Get student by Id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById([FromRoute] int id)
        {
            var response = _repo.GetStudentById(id);

            return Ok(response);
        }
        #endregion

        #region Create a new student
        [HttpPost("create")]
        public async Task<IActionResult> AddNewStudent([FromBody] Student body)
        {
            var response = _repo.AddStudent(body);
            return Ok(response.Result.ToString());
        }
        #endregion

        #region Edit existing student
        [HttpPut("edit")]
        public async Task<IActionResult> EditStudent([FromBody] Student body)
        {
            var response = _repo.UpdateStudent(body);
            return Ok(response);
        }
        #endregion

        #region Delete student by id
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteStudent([FromRoute] int id)
        {
            var response = _repo.DeleteStudent(id);
            return Ok(response.Result.ToString());
        }
        #endregion
    }
}