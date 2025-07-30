using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.DTOs.RequestDTO;
using Services.DTOs.ResponseDTO;

namespace Services.InterfaceServices
{
    public interface IRewardCardServices 
    {
        List<RewardCardResponse> GetAll();

        RewardCardResponse GetById(string id);

        RewardCardResponse CreateCard(RewardCardRequest card);

        RewardCardResponse UpdateCard(RewardCardRequest card);

        RewardCardResponse DeleteCard(string id);
    }
}
