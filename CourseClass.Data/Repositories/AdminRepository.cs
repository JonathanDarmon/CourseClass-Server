using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseClass.BL.Contracts;
using CourseClass.BL.Domain;

namespace CourseClass.Data.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly ManagmentContext _context;
        public AdminRepository(ManagmentContext context)
        {
            _context = context;
        }

        public IEnumerable<Administrator> AllAdmins
        {
            get
            {
                var query = from a in _context.Admins
                            select a;
                return query;
            }
        }
        public Administrator GetAdminById(int adminId)
        {
            return _context.Admins.FirstOrDefault(a => a.Id == adminId);
        }

        public Task<bool> AddAdmin(Administrator admin)
        {
            if (string.IsNullOrEmpty(admin.Password))
                throw new Exception("Password required");

            if (_context.Admins.Any(a => a.Email == admin.Email))
            {
                throw new Exception("Email already exist");
            }
            else
            {
                _context.Admins.Add(admin);
                Commit();
                return Task.FromResult(true);
            }
        }

        public Task<bool> DeleteAdmin(int adminId)
        {
            var admin = GetAdminById(adminId);
            if (admin != null)
            {
                _context.Admins.Remove(admin);
                Commit();
                return Task.FromResult(true);
            }
            else
            {
                return Task.FromResult(false);
            }
        }

        public Task<bool> UpdateAdmin(Administrator admin)
        {
            if (admin != null)
            {
                _context.Admins.Update(admin);
                Commit();
                return Task.FromResult(true);
            }
            else
            {
                return Task.FromResult(false);
            }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public Administrator FindAdminByEmail(string email)
        {
                Administrator response = _context.Admins.Where(a => a.Email == email).FirstOrDefault();
                return response;
        }
    }
}