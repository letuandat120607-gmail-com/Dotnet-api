using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.DTOs.RequestDTO;
using Services.DTOs.ResponseDTO;
using Services.InterfaceServcies;
using Services.InterfaceServices;

namespace billx.Controllers
{


    [Route("Api/Store")]

    public class StoreController : Controller
    {

        private readonly IStoreServices _storetservices;

        public StoreController(IStoreServices storetservices)
        {
            _storetservices = storetservices;
        }

        [AllowAnonymous]
        [HttpGet("GetAll")]
        public ActionResult<List<StoreResponse>> GetAll()
        {
            List<StoreResponse> response = _storetservices.GetAll();
            return Ok(response);
        }

        [HttpGet("GetById")]
        public ActionResult<StoreResponse> GetById([FromBody] string id)
        {
            StoreResponse response = _storetservices.GetById(id);
            return Ok(response);
        }

        [HttpPost("CreateStore")]
        public ActionResult<StoreResponse> CreateStore([FromBody] StoreRequest request)
        {
            StoreResponse response = _storetservices.CreateStore(request);
            return Ok(response);
        }

        [HttpPut("UpdateStore")]
        public ActionResult<StoreResponse> UpdateStore([FromBody] StoreRequest request)
        {
            StoreResponse response = _storetservices.UpdateStore(request);
            return Ok(response);
        }
    }
}
