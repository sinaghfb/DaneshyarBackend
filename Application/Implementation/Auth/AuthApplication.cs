using Application.Commons;
using Application.Dependencies.Auth;
using Application.Dependencies.BaseInfo;
using Domain.Contracts.Auth;
using Domain.DTOs.Auth.Request;
using Domain.DTOs.Auth.Response;
using Domain.Entites.Auth;
using Domain.Entites.BaseInfo;
using Domain.Enums;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;

namespace Application.Implementation.Auth
{
    internal class AuthApplication : IAuthApplication
    {
        private readonly IUserRepository _userRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IRoleRepository _roleRepository;

        public AuthApplication(IUserRepository userRepository , IPersonRepository personRepository, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _personRepository = personRepository;
            _roleRepository = roleRepository;
        }
        public async Task<BaseUserResponse> AddAnotherUser(AddAnotherUserRequest user)
        {
            BaseUserResponse response = new();
            try
            {
                var foundedPerson = await _personRepository.Get(x => x.Id == user.PersonId || x.NationalNo == user.NationalNo);
                var foundedRole = await _roleRepository.Get(x => x.UserAccessLevel == user.UserAccessLevel);
                if (foundedPerson!=null && foundedRole!=null)
                {
                    User newUser = new();
                    newUser.TheRole= foundedRole;
                    newUser.ThePerson=foundedPerson;
                    newUser.Username = user.Username;
                    newUser.Email=user.Email;
                    newUser.MobileNo=user.MobileNo;
                    newUser.HashedPassword = HashPassword(user.Password);
                    if (await _userRepository.Create(newUser))
                    {
                        response.Status = ResponseState.Success;
                        response.Message = "ثبت کاربر موفقیت آمیز بود";
                        response.Description = "User Registerd Succsessfuly";
                    }
                    else
                    {
                        response.Status = ResponseState.Failed;
                        response.Message = "ثبت کاربر با خطا مواجه شد";
                        response.Description = "User Register Failed";
                    }
                }
                else
                {
                    response.Status = ResponseState.Failed;
                    response.Message = "ثبت کاربر با خطا مواجه شد";
                    response.Description = "User Register Failed";
                }
            }
            catch (Exception ex)
            {
                response.Status = ResponseState.Execption;
                response.Message = "ثبت کاربر با خطا مواجه شد";
                response.Description = ex.HtmlErrorReport();
            }
            return response;
        }
        private static string HashPassword(string password)
        {

            HashAlgorithm hash = SHA256.Create();

            Encoding enc = Encoding.UTF8;
            byte[] result = hash.ComputeHash(enc.GetBytes(password));

            var stringResult = Convert.ToBase64String(result);

            return stringResult;
        }
        private Expression<Func<User, bool>> UserFinder(BaseUserRequest user)
        {
            if (!string.IsNullOrWhiteSpace(user.UserId))
            {
                return a => a.Id == user.UserId;

            }
            else if (!string.IsNullOrWhiteSpace(user.MobileNo))
            {
                return a => a.MobileNo == user.MobileNo;
            }
            else if (!string.IsNullOrWhiteSpace(user.Email))
            {
                return a => a.Email == user.Email;
            }
            else if(!string.IsNullOrWhiteSpace(user.UserName))
            {
                return a=>a.Username == user.UserName;
            }
            else
            {
                return null;
            }
        }
        public async Task<BaseUserResponse> ChangeUserPassword(ChangePasswordRequest user)
        {
            BaseUserResponse response = new();
            try
            {
                var foundedUser = await _userRepository.Get(UserFinder(user));
                if (foundedUser != null)
                {
                    foundedUser.HashedPassword=HashPassword(user.NewPassword);

                    if(await _userRepository.UpdateUser(foundedUser))
                    {
                        response.Status = ResponseState.Success;
                        response.Message = "تغییر کلمه عبور کاربر موفقیت آمیز بود";
                        response.Description = "Change Password Done Succsessfuly";
                    }
                    else
                    {
                        response.Status = ResponseState.Failed;
                        response.Message = "تغییر کلمه عبور کاربر با خطا مواجه شد";
                        response.Description = "Change Password Failed";
                    }
                }
                else
                {
                    response.Status = ResponseState.Failed;
                    response.Message = "تغییر کلمه عبور کاربر با خطا مواجه شد";
                    response.Description = "Change Password Failed";
                }
            }
            catch (Exception ex)
            {
                response.Status = ResponseState.Execption;
                response.Message = "تغییر کلمه عبور کاربر با خطا مواجه شد";
                response.Description = ex.HtmlErrorReport();
            }

            return response;
        }

        public async Task<BaseUserResponse> DeleteUser(BaseUserRequest user)
        {
            BaseUserResponse response = new();

            try
            {
                var foundedUser = await _userRepository.Get(UserFinder(user));
                if (foundedUser!=null)
                {
                    if (await _userRepository.DeleteUser(foundedUser.Id))
                    {
                        response.Status = ResponseState.Success;
                        response.Message = "حذف کاربر موفقیت آمیز بود";
                        response.Description = "User Deleted Succsessfuly";

                    }
                    else
                    {
                        response.Status = ResponseState.Failed;
                        response.Message = "حذف کاربر با خطا مواجه شد";
                        response.Description = "User Delete Failed";
                    }
                }
                else
                {
                    response.Status = ResponseState.Failed;
                    response.Message = "حذف کاربر با خطا مواجه شد";
                    response.Description = "User Delete Failed";
                }
            }
            catch (Exception ex)
            {
                response.Status = ResponseState.Execption;
                response.Message = "حذف کاربر با خطا مواجه شد";
                response.Description = ex.HtmlErrorReport();
            }
            return response;
        }

        public async Task<UserInfoResponse> GetUserInfo(BaseUserRequest user)
        {
            UserInfoResponse response = new();
            try
            {
                var foundedUser = await _userRepository.Get(UserFinder(user));
                if (foundedUser != null)
                {
                    response.FatherName = foundedUser.ThePerson.FatherName;
                    response.Name = foundedUser.ThePerson.Name;
                    response.Email = foundedUser.Email;
                    response.MobileNo = foundedUser.MobileNo;
                    response.UserName = foundedUser.Username;
                    response.Family = foundedUser.ThePerson.Family;
                    response.NationalNo = foundedUser.ThePerson.NationalNo;
                    response.UserAccessLevel = foundedUser.TheRole.UserAccessLevel;
                    response.Status = ResponseState.Success;
                    response.Message = "اطلاعات کاربر یافت شد";
                    response.Description = "User Find Succsessfuly";
                }
                else
                {
                    response.Status = ResponseState.Failed;
                    response.Message = "اطلاعات کاربر یافت نشد";
                    response.Description = "User Find Failed";

                }
            }
            catch (Exception ex)
            {

                response.Status = ResponseState.Execption;
                response.Message = "بازیابی اطلاعات کاربر با خطا مواجه شد";
                response.Description = ex.HtmlErrorReport();
            }
            throw new NotImplementedException();
        }

        public async Task<BaseUserResponse> NewUserRegister(NewUserRegisterRequest user)
        {
            BaseUserResponse response = new();
            try
            {
                var foundedRole = await _roleRepository.Get(x => x.UserAccessLevel == user.UserAccessLevel);

                if (!await _personRepository.Exists(x=>x.NationalNo==user.NationalNo))
                {
                    Person newPerson = new();
                    newPerson.NationalNo = user.NationalNo;
                    newPerson.FatherName = user.FatherName;
                    newPerson.Name = user.Name;
                    newPerson.Family = user.Family;
                    if (await _personRepository.Create(newPerson))
                    {
                        User newUser = new();
                        newUser.TheRole = foundedRole;
                        newUser.ThePerson = newPerson;
                        newUser.Username = user.Username;
                        newUser.Email = user.Email;
                        newUser.MobileNo = user.MobileNo;
                        newUser.HashedPassword = HashPassword(user.Password);
                        if (await _userRepository.Create(newUser))
                        {
                            response.Status = ResponseState.Success;
                            response.Message = "ثبت کاربر موفقیت آمیز بود";
                            response.Description = "User Registerd Succsessfuly";
                        }
                        else
                        {
                            response.Status = ResponseState.Failed;
                            response.Message = "ثبت کاربر با خطا مواجه شد";
                            response.Description = "User Register Failed";
                        }
                    }
                    else
                    {
                        response.Status = ResponseState.NotFound;
                        response.Message = "ثبت کاربر با خطا مواجه شد";
                        response.Description = "User Not Found";
                    }
                }
            }
            catch (Exception ex)
            {
                response.Status = ResponseState.Execption;
                response.Message = "ثبت کاربر با خطا مواجه شد";
                response.Description = ex.HtmlErrorReport();
            }
            return response;
        }

        public async Task<BaseUserResponse> UpdateUser(UpdateUserRequest user)
        {
            BaseUserResponse response = new();

            try
            {
                var foundedUser = await _userRepository.Get(x => x.Id == user.UserId);
                if (foundedUser!=null)
                {
                    

                    response.Status = ResponseState.Success;
                    response.Message = "به روزرسانی کاربر موفقیت آمیز بود";
                    response.Description = "User Registerd Succsessfuly";
                }
                else
                {
                    response.Status = ResponseState.Failed;
                    response.Message = "به روزرسانی کاربر با خطا مواجه شد";
                    response.Description = "User Register Failed";
                }
            }
            catch (Exception ex)
            {
                response.Status = ResponseState.Execption;
                response.Message = "به روزرسانی کاربر با خطا مواجه شد";
                response.Description = ex.HtmlErrorReport();
            }
            throw new NotImplementedException();
        }

        public async Task<BaseUserResponse> UserLogin(UserLoginRequest user)
        {
            BaseUserResponse response = new();
            try
            {
                var foundedUser = await _userRepository.Get(UserFinder(user));
                if (foundedUser != null)
                {
                    if (foundedUser.HashedPassword==HashPassword(user.password))
                    {
                        response.Status = ResponseState.Success;
                        response.Message = "ورود کاربر  موفقیت آمیز بود";
                        response.Description = "User Registerd Succsessfuly";
                    }
                    else
                    {
                        response.Status = ResponseState.Failed;
                        response.Message = "ورود کاربر با خطا مواجه شد";
                        response.Description = "User Register Failed";
                    }
                }
                else
                {
                    response.Status = ResponseState.NotFound;
                    response.Message = "کاربر یافت نشد";
                    response.Description = "User Not Found ";
                }
            }
            catch (Exception ex)
            {

                response.Status = ResponseState.Execption;
                response.Message = "ورود کاربر با خطا مواجه شد";
                response.Description = ex.HtmlErrorReport();
            }
            return response;
        }
    }
}
