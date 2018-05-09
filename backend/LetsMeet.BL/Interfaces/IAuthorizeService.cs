using LetsMeet.BL.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LetsMeet.BL.Interfaces
{
    public interface IAuthorizeService
    {
        Task Create(AccountRegisterLoginViewModel model);
        Task<string> CreateToken(AccountRegisterLoginViewModel accountRegisterLoginViewModel);
    }
}
