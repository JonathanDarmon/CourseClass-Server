using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseClass.BL.Domain;

namespace CourseClass.BL.Contracts
{
    public interface IAdminRepository
    {
        IEnumerable<Administrator> AllAdmins { get; }
        Administrator GetAdminById(int adminId);
        Administrator FindAdminByEmail(string email);
        Task<bool> AddAdmin(Administrator admin);
        Task<bool> UpdateAdmin(Administrator admin);
        Task<bool> DeleteAdmin(int adminId);
        void Commit();
    }
}