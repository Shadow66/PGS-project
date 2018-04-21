using LetsMeet.DA.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LetsMeet.DA.Interfaces
{
    public interface IAuthorizeRepository
    {
        Task CreateAsync(AccountRegisterLoginDto model);
        Task LogInAsync(AccountRegisterLoginDto model);
    }
}
