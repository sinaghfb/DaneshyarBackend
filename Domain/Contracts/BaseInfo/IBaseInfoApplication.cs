using Domain.DTOs.Base.Response;
using Domain.DTOs.BaseInfo.Request;
using Domain.DTOs.BaseInfo.Response;

namespace Domain.Contracts.BaseInfo
{
    public interface IBaseInfoApplication
    {
        public Task<GetPersonResponse> GetpersonInfo(BasePersonRequest person);
        public Task<BaseResponse> DeletePerson(BasePersonRequest person);
        public Task<BaseResponse> UpdatePerson(UpdateUserRequest person);
        public Task<BaseResponse> IsPersonExists(BasePersonRequest person);
        public Task<BaseResponse> CreatePerson(CreatePersonRequest person);
    }
}
