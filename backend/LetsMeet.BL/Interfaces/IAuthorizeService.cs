using LetsMeet.BL.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace LetsMeet.BL.Interfaces
{
    public interface IAuthorizeService
    {
        void Create(AccountRegisterLoginViewModel model);
        AccountRegisterLoginViewModel Authenticate(AccountRegisterLoginViewModel accountRegisterLoginViewModel);
        string BuildToken(AccountRegisterLoginViewModel accountRegisterLoginDto);
    }
}
