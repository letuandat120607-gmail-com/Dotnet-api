using BusinessObject;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.AspNetCore.Mvc;
using Services.DTOs.RequestDTO;
using Services.DTOs.ResponseDTO;
using Services.InterfaceServcies;

namespace billx.Controllers
{

    [Route("Api/Account")]

    public class AccountController : Controller
    {


        private readonly IAccountServices _accountservices;

        public AccountController(IAccountServices accountservices)
        {
            _accountservices = accountservices;
        }

        [AllowAnonymous]
        [HttpPost("signup")]
        public ActionResult<SignUpResponse> SignUp([FromBody] SignUpRequest request)
        {
            SignUpResponse response = _accountservices.SignUp(request);
            return Ok(response);
        }

        [HttpPost("login")]
        public ActionResult<LogInResponse> LogIn([FromBody] LogInRequest request)
        {
            LogInResponse response = _accountservices.LogIn(request);
            return Ok(response);
        }

        //[Authorize(Roles = "Manager")]
        [HttpDelete("DeleteAccount/{id}")]
        public ActionResult<Account> DeleteAccount(string id)
        {
            Account response = _accountservices.DeleteAccount(id);
            return Ok(response);

        }
    }
}
