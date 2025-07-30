using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.InterfaceServices;

namespace billx.Controllers
{

    [Route("Api/RewardCard")]
    public class RewardCardController : Controller
    {
        private readonly IRewardCardServices _rewardcardservices;

        public RewardCardController(IRewardCardServices rewardcardservices)
        {
            _rewardcardservices = rewardcardservices;
        }

        [AllowAnonymous]
        [HttpGet("GetAll")]
        public ActionResult<List<Services.DTOs.ResponseDTO.RewardCardResponse>> GetAll()
        {
            List<Services.DTOs.ResponseDTO.RewardCardResponse> response = _rewardcardservices.GetAll();
            return Ok(response);
        }

        [HttpGet("GetById/{id}")]
        public ActionResult<Services.DTOs.ResponseDTO.RewardCardResponse> GetById(string id)
        {
            Services.DTOs.ResponseDTO.RewardCardResponse response = _rewardcardservices.GetById(id);
            return Ok(response);
        }

        [HttpPost("CreateRewardCard")]
        public ActionResult<Services.DTOs.ResponseDTO.RewardCardResponse> CreateCard([FromBody] Services.DTOs.RequestDTO.RewardCardRequest request)
        {
            Services.DTOs.ResponseDTO.RewardCardResponse response = _rewardcardservices.CreateCard(request);
            return Ok(response);
        }

        [HttpPut("UpdateRewardCard")]
        public ActionResult<Services.DTOs.ResponseDTO.RewardCardResponse> UpdateCard([FromBody] Services.DTOs.RequestDTO.RewardCardRequest request)
        {
            Services.DTOs.ResponseDTO.RewardCardResponse response = _rewardcardservices.UpdateCard(request);
            return Ok(response);
        }
    }
}
