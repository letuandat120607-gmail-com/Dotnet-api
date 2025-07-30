using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using Services.DTOs.RequestDTO;
using Services.DTOs.ResponseDTO;

namespace Services.InterfaceServcies
{
    public interface IAccountServices
    {

        SignUpResponse SignUp(SignUpRequest request);

        LogInResponse LogIn(LogInRequest request);

        Account DeleteAccount(string id);

    }

    
}
