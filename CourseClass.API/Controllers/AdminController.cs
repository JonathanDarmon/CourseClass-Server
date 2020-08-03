using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CourseClass.BL;
using CourseClass.BL.Contracts;
using CourseClass.BL.Domain;
using CourseClass.Data;
using CourseClass.API.Models.Admin;

namespace CourseClass.API.Controllers
{
    [Authorize]
    [Route("api/admin")]
    [Produces("application/json")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminRepository _repo;

        public AdminController(IAdminRepository repo)
        {
            _repo = repo;
        }

        #region Get all admins
        /// <summary>
        /// Get all administrators
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAllAdmins()
        {
            var response = _repo.AllAdmins;

            return Ok(response);
        }
        #endregion

        #region Get admin by Id
        /// <summary>
        /// Get admin by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetAdminById([FromRoute] int id)
        {
            var response = _repo.GetAdminById(id);

            return Ok(response);
        }
        #endregion

        #region Create a new admin
        /// <summary>
        /// Create admin
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPost("create")]
        public IActionResult AddNewAdmin([FromBody] CreateAdminModel body)
        {
            Administrator user = new Administrator
            {
                Name = body.Name,
                Email = body.Email,
                Password = body.Password,
                Phone = body.Phone,
                Role = body.Role
            };

            var response = _repo.AddAdmin(user);
            return Ok(response.Result.ToString());
        }
        #endregion

        #region Edit existing admin
        /// <summary>
        /// Update admin
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPut("edit")]
        public IActionResult EditAdmin([FromBody] Administrator body)
        {
            var response = _repo.UpdateAdmin(body);
            return Ok(response);
        }
        #endregion

        #region Delete admin by id
        /// <summary>
        /// Delete admin by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("delete/{id}")]
        public IActionResult DeleteAdmin([FromRoute] int id)
        {
            var response = _repo.DeleteAdmin(id);
            return Ok(response.Result.ToString());
        }
        #endregion
    }
}