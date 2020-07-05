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

namespace CourseClass.API.Controllers
{
    [Authorize]
    [Route("api/admin")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminRepository _repo;

        public AdminController(IAdminRepository repo)
        {
            _repo = repo;
        }

        #region Get all admins
        [HttpGet]
        public async Task<IActionResult> GetAllAdmins()
        {
            var response = _repo.AllAdmins;

            return Ok(response);
        }
        #endregion

        #region Get admin by Id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAdminById([FromRoute] int id)
        {
            var response = _repo.GetAdminById(id);

            return Ok(response);
        }
        #endregion

        #region Create a new admin
        [HttpPost("create")]
        public async Task<IActionResult> AddNewAdmin([FromBody] Administrator body)
        {
            var response = _repo.AddAdmin(body);
            return Ok(response.Result.ToString());
        }
        #endregion

        #region Edit existing admin
        [HttpPut("edit")]
        public async Task<IActionResult> EditAdmin([FromBody] Administrator body)
        {
            var response = _repo.UpdateAdmin(body);
            return Ok(response);
        }
        #endregion

        #region Delete admin by id
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteAdmin([FromRoute] int id)
        {
            var response = _repo.DeleteAdmin(id);
            return Ok(response.Result.ToString());
        }
        #endregion
    }
}