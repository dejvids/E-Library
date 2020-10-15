using E_Library.DAL.Enitities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace E_Library.Application.Services
{
    public interface IUserService
    {
        Task<User> GetTestUserAsync();
    }
}
