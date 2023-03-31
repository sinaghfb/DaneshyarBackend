using Application.Commons;
using Application.Dependencies.BaseInfo;
using Domain.Contracts.BaseInfo;
using Domain.DTOs.Base.Response;
using Domain.DTOs.BaseInfo.Request;
using Domain.DTOs.BaseInfo.Response;
using Domain.Entites.BaseInfo;
using Domain.Enums;

namespace Application.Implementation.BaseInfo
{
    internal class BaseInfoApplication : IBaseInfoApplication
    {
        private readonly IPersonRepository _baseInfoRepository;
        public BaseInfoApplication(IPersonRepository baseInfoRepository)
        {
            _baseInfoRepository = baseInfoRepository;
        }
        public async Task<BaseResponse> CreatePerson(CreatePersonRequest person)
        {
            BaseResponse response = new();

            try
            {
                if (!await _baseInfoRepository.Exists(x => x.NationalNo == person.NationalNo))
                {
                    Person newPerson = new();
                    newPerson.Name = person.Name;
                    newPerson.Family = person.Family;
                    newPerson.FatherName = person.FatherName;
                    newPerson.NationalNo = person.NationalNo;
                    if (await _baseInfoRepository.Create(newPerson))
                    {
                        response.Status = ResponseState.Success;
                        response.Message = "ثبت شخص موفقیت آمیز بود";
                        response.Description = "User Registerd Succsessfuly";
                    }
                    else
                    {
                        response.Status = ResponseState.Failed;
                        response.Message = "ثبت شخص با خطا مواجه شد";
                        response.Description = "User Register Failed";
                    }
                }
                else
                {
                    response.Status = ResponseState.Failed;
                    response.Message = "شخص قبلا ثبت شده است";
                    response.Description = "User Already Exists";
                }
            }
            catch (Exception ex)
            {

                response.Status = ResponseState.Execption;
                response.Message = "ثبت شخص با خطا مواجه شد";
                response.Description = ex.HtmlErrorReport();
            }
            return response;
        }
        public async Task<BaseResponse> DeletePerson(BasePersonRequest person)
        {
            BaseResponse response = new();
            try
            {
                if (!string.IsNullOrWhiteSpace(person.PersonId))
                {
                    if (await _baseInfoRepository.DeletePerson(person.PersonId))
                    {
                        response.Status = ResponseState.Success;
                        response.Message = "حذف شخص موفقیت آمیز بود";
                        response.Description = "User Deleted Succsessfuly";
                    }
                    else
                    {
                        response.Status = ResponseState.Failed;
                        response.Message = "حذف شخص با خطا مواجه شد";
                        response.Description = "User ِDelete Failed";
                    }
                }
                else if (!string.IsNullOrWhiteSpace(person.NationalNo))
                {
                    var foundedPerson = await _baseInfoRepository.Get(x => x.NationalNo == person.NationalNo);
                    if (foundedPerson != null)
                    {
                        if (await _baseInfoRepository.DeletePerson(foundedPerson.Id))
                        {
                            response.Status = ResponseState.Success;
                            response.Message = "حذف شخص موفقیت آمیز بود";
                            response.Description = "User Deleted Succsessfuly";
                        }
                        else
                        {
                            response.Status = ResponseState.Failed;
                            response.Message = "حذف شخص با خطا مواجه شد";
                            response.Description = "User ِDelete Failed";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                response.Status = ResponseState.Execption;
                response.Message = "حذف شخص با خطا مواجه شد";
                response.Description = ex.HtmlErrorReport();
            }
            return response;
        }    
        public async Task<GetPersonResponse> GetpersonInfo(BasePersonRequest person)
        {
            GetPersonResponse response = new();

            try
            {
                if (!string.IsNullOrWhiteSpace(person.PersonId))
                {
                    var foundedPerson = await _baseInfoRepository.Get(x => x.Id == person.PersonId);
                    if (foundedPerson!=null)
                    {
                        response.NationalNo = foundedPerson.NationalNo;
                        response.Family = foundedPerson.Family;
                        response.FatherName = foundedPerson.FatherName;
                        response.Name = foundedPerson.Name;
                        response.Status = ResponseState.Success;
                        response.Message = "شخص با موفقیت یافت شد";
                        response.Description = "Person Found Succsessfuly";
                    }
                    else
                    {
                        response.Status = ResponseState.Failed;
                        response.Message = "شخص یافت نشد";
                        response.Description = "Person Not Found";
                    }


                }
                else if (!string.IsNullOrWhiteSpace(person.NationalNo))
                {
                    var foundedPerson = await _baseInfoRepository.Get(x => x.NationalNo == person.NationalNo);
                    if (foundedPerson != null)
                    {
                        response.NationalNo = foundedPerson.NationalNo;
                        response.Family = foundedPerson.Family;
                        response.FatherName = foundedPerson.FatherName;
                        response.Name = foundedPerson.Name;
                        response.Status = ResponseState.Success;
                        response.Message = "شخص با موفقیت یافت شد";
                        response.Description = "Person Found Succsessfuly";
                    }
                    else
                    {
                        response.Status = ResponseState.Failed;
                        response.Message = "شخص یافت نشد";
                        response.Description = "Person Not Found";
                    }
                }
                else
                {
                    response.Status = ResponseState.Failed;
                    response.Message = "کد ملی یا شناسه وجود ندارد";
                    response.Description = "Null Input";
                }
            }
            catch (Exception ex)
            {

                response.Status = ResponseState.Execption;
                response.Message = "پیدا کردن شخص با خطا مواجه شد";
                response.Description = ex.HtmlErrorReport();
            }
            return response;
        }
        public async Task<BaseResponse> IsPersonExists(BasePersonRequest person)
        {
            BaseResponse response = new();
            try
            {
                if (!string.IsNullOrWhiteSpace(person.PersonId))
                {
                    if (await _baseInfoRepository.Exists(x => x.Id == person.PersonId))
                    {
                        response.Status = ResponseState.Success;
                        response.Message = "شخص با موفقیت یافت شد";
                        response.Description = "Person Found Succsessfuly";
                    }
                    else
                    {
                        response.Status = ResponseState.Failed;
                        response.Message = "شخص یافت نشد";
                        response.Description = "Person Not Found";
                    }
                }
                else if (!string.IsNullOrWhiteSpace(person.NationalNo))
                {
                    if (await _baseInfoRepository.Exists(x => x.NationalNo == person.NationalNo))
                    {
                        response.Status = ResponseState.Success;
                        response.Message = "شخص با موفقیت یافت شد";
                        response.Description = "Person Found Succsessfuly";
                    }
                    else
                    {
                        response.Status = ResponseState.Failed;
                        response.Message = "شخص یافت نشد";
                        response.Description = "Person Not Found";
                    }
                }
                else
                {
                    response.Status = ResponseState.Failed;
                    response.Message = "کد ملی یا شناسه وجود ندارد";
                    response.Description = "Null Input";
                }
            }
            catch (Exception ex)
            {


                response.Status = ResponseState.Execption;
                response.Message = "پیدا کردن شخص با خطا مواجه شد";
                response.Description = ex.HtmlErrorReport();
            }
            return response;
        }
        public async Task<BaseResponse> UpdatePerson(UpdateUserRequest person)
        {
            BaseResponse response = new();
            try
            {
                if (!string.IsNullOrWhiteSpace(person.PersonId))
                {
                    var foundedPerson = await _baseInfoRepository.Get(x => x.Id == person.PersonId);
                    if (foundedPerson!=null)
                    {
                        if (!await _baseInfoRepository.Exists(x=>x.NationalNo==person.NationalNo))
                        {
                            foundedPerson.NationalNo = person.NationalNo;
                            foundedPerson.Family=person.Family;
                            foundedPerson.Name=person.Name;
                            foundedPerson.FatherName=person.FatherName;
                            if (await _baseInfoRepository.UpdatePerson(foundedPerson))
                            {
                                response.Status = ResponseState.Success;
                                response.Message = "شخص با موفقیت به روزسانی شد";
                                response.Description = "Person Found Succsessfuly";
                            }
                            else
                            {
                                response.Status = ResponseState.Failed;
                                response.Message = "به روزرسانی شخص با خطا مواجه شد";
                                response.Description = "Update Person Failed";
                            }
                        }
                    }
                }
                else
                {
                    response.Status = ResponseState.Failed;
                    response.Message = "شخص یافت نشد";
                    response.Description = "Person Not Found";
                }
            }
            catch (Exception ex)
            {

                response.Status = ResponseState.Execption;
                response.Message = "به روزرسانی شخص با خطا مواجه شد";
                response.Description = ex.HtmlErrorReport();
            }   
            
            return response;
        }
    }
}
