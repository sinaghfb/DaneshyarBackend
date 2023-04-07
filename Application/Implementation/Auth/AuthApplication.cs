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
    public class AuthApplication : IAuthApplication
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
                    _userRepository.Create(newUser);
                    if (await _userRepository.SaveChanges())
                    {
                        response.UserId = newUser.Id;
                        response.PersonId = newUser.ThePerson.Id;
                        response.UserName = newUser.Username;
                        response.UserAccessLevel = newUser.TheRole.UserAccessLevel;
                        response.FullName = newUser.ThePerson.Name + " " + newUser.ThePerson.Family;
                        response.NationalNo = newUser.ThePerson.NationalNo;
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
        private static Expression<Func<User, bool>> UserFinder(BaseUserRequest user)
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
                    _userRepository.UpdateUser(foundedUser);
                    if (await _userRepository.SaveChanges())
                    {
                        response.UserId = foundedUser.Id;
                        response.PersonId = foundedUser.ThePerson.Id;
                        response.UserName = foundedUser.Username;
                        response.UserAccessLevel = foundedUser.TheRole.UserAccessLevel;
                        response.Status = ResponseState.Success;
                        response.FullName = foundedUser.ThePerson.Name + " " + foundedUser.ThePerson.Family;
                        response.NationalNo = foundedUser.ThePerson.NationalNo;
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
                    response.FullName = foundedUser.ThePerson.Name + " " + foundedUser.ThePerson.Family;
                    response.UserId = foundedUser.Id;
                    response.PersonId=foundedUser.ThePerson.Id;
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
            return response;
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
                    _personRepository.Create(newPerson);
                    if (await _personRepository.SaveChanges())
                    {
                        User newUser = new();
                        newUser.RoleId = foundedRole.Id;
                        newUser.PersonId = newPerson.Id;
                        //newUser.ThePerson = newPerson;
                        //newUser.TheRole = foundedRole;
                        newUser.Username = user.Username;
                        newUser.Email = user.Email;
                        newUser.MobileNo = user.MobileNo;
                        newUser.HashedPassword = HashPassword(user.Password);
                        response.FullName = newUser.ThePerson.Name + " " + newUser.ThePerson.Family;
                        response.NationalNo = newUser.ThePerson.NationalNo;
                        _userRepository.Create(newUser);
                        if (await _userRepository.SaveChanges())
                        {
                            response.UserId = newUser.Id;
                            response.PersonId= newUser.ThePerson.Id;
                            response.UserName = newUser.Username;
                            response.Status = ResponseState.Success;
                            response.UserAccessLevel =newUser.TheRole.UserAccessLevel;
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
                else
                {
                    response.Status = ResponseState.Failed;
                    response.Message = "اطلاعات کاربر موجود است";
                    response.Description = "user Exists";
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
                    if (foundedUser.ThePerson.NationalNo != user.NationalNo)
                    {
                        if (!await _personRepository.Exists(x => x.NationalNo == user.NationalNo))
                        {
                            var role = await _roleRepository.Get(x => x.UserAccessLevel == user.UserAccessLevel);
                            foundedUser.Email = user.Email;
                            foundedUser.MobileNo = user.MobileNo;
                            foundedUser.ThePerson.NationalNo = user.NationalNo;
                            foundedUser.ThePerson.Name = user.Name;
                            foundedUser.ThePerson.Family = user.Family;
                            foundedUser.ThePerson.FatherName = user.FatherName;
                            foundedUser.TheRole = role;
                            _userRepository.UpdateUser(foundedUser);
                            if (await _userRepository.SaveChanges())
                            {
                                response.UserId = foundedUser.Id;
                                response.PersonId = foundedUser.ThePerson.Id;
                                response.UserName = foundedUser.Username;
                                response.UserAccessLevel = foundedUser.TheRole.UserAccessLevel;
                                response.Status = ResponseState.Success;
                                response.FullName = foundedUser.ThePerson.Name + " " + foundedUser.ThePerson.Family;
                                response.NationalNo = foundedUser.ThePerson.NationalNo;
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
                        else
                        {
                            response.Status = ResponseState.Failed;
                            response.Message = "کد ملی تکراری است";
                            response.Description = "Duplicate National No";
                        }
                    }
                    else
                    {
                        var role = await _roleRepository.Get(x => x.UserAccessLevel == user.UserAccessLevel);
                        foundedUser.Email = user.Email;
                        foundedUser.MobileNo = user.MobileNo;
                        foundedUser.ThePerson.NationalNo = user.NationalNo;
                        foundedUser.ThePerson.Name = user.Name;
                        foundedUser.ThePerson.Family = user.Family;
                        foundedUser.ThePerson.FatherName = user.FatherName;
                        foundedUser.RoleId = role.Id;
                        _userRepository.UpdateUser(foundedUser);
                        if (await _userRepository.SaveChanges())
                        {
                            response.UserId = foundedUser.Id;
                            response.PersonId = foundedUser.ThePerson.Id;
                            response.UserName = foundedUser.Username;
                            response.UserAccessLevel = foundedUser.TheRole.UserAccessLevel;
                            response.Status = ResponseState.Success;
                            response.FullName = foundedUser.ThePerson.Name + " " + foundedUser.ThePerson.Family;
                            response.NationalNo = foundedUser.ThePerson.NationalNo;
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
            return response;
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
                        response.UserId = foundedUser.Id;
                        response.PersonId = foundedUser.ThePerson.Id;
                        response.UserName = foundedUser.Username;
                        response.UserAccessLevel = foundedUser.TheRole.UserAccessLevel;
                        response.Status = ResponseState.Success;
                        response.FullName = foundedUser.ThePerson.Name + " " + foundedUser.ThePerson.Family;
                        response.NationalNo = foundedUser.ThePerson.NationalNo;
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
