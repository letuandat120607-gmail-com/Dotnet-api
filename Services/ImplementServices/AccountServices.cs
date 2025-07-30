using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.AccessControl;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using BusinessObject;
using DataAccessObject;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.IdentityModel.Tokens;
using Services.DTOs.RequestDTO;
using Services.DTOs.ResponseDTO;
using Services.Exceptions;
using Services.InterfaceServcies;

namespace Services.ImplementServcies
{
    public class AccountServices : IAccountServices
    {
        
        private static string GenerateJwtToken(string username, string role)
        {
            try
            {

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("billxhdsbfjhsavdfhjbvasfdgdhddgfddgndxgxgn"));
                var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256); //credentials: chứng chỉ
                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.Role, role) // Gán role
                };

                var token = new JwtSecurityToken(
                    "https://long.com",
                    "https://long.com",
                    claims,
                    expires: DateTime.UtcNow.AddMinutes(5),
                    signingCredentials: credentials
                );
                return new JwtSecurityTokenHandler().WriteToken(token);

            }
            catch (CrudException cex)
            {
                throw cex;
            }
            catch (Exception ex)
            {
                throw new CrudException(HttpStatusCode.InternalServerError, "Lỗi hệ thống!", ex?.Message);
            }
        }
        public AccountResponse GetAccountById(string accountId)
        {
            using var db = new FinalProjectGreaterContext();

            var account = db.Accounts
                .Where(a => a.AccountId == accountId)
                .Select(a => new AccountResponse
                {
                    AccountId = a.AccountId,
                    FullName = a.FullName,
                    UserName = a.UserName,
                    Gender = a.Gender,
                    DateOfBirth = a.DateOfBirth,
                    Email = a.Email,
                    PhoneNumber = a.PhoneNumber,
                    AvatarLink = a.AvatarLink,
                    GoogleId = a.GoogleId,
                    CreateDate = a.CreateDate,
                    IsWorking = a.IsWorking,
                    Status = a.Status,
                    RoleName = a.Role.RoleName,
                    StoreName = a.Store.StoreName,
                    CardCode = a.CardId
                })
                .FirstOrDefault();

            return account!;
        }
        public Account DeleteAccount(string id)
        {
            try
            {
                AccountDAO accountDAO = AccountDAO.Instance;
                Account rs = accountDAO.getById(id);
                if (rs == null)
                {
                    return null;
                }

                Account delete = accountDAO.Delete(id);
                if (delete == null)
                {
                    return null;
                }

                return delete;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public LogInResponse LogIn(LogInRequest request)
        {
            try
            {

                Account account = AccountDAO.Instance.getByUsername(request.UserName);
                if (account == null)
                {
                    throw new CrudException(HttpStatusCode.BadRequest, "Sai tài khoản hoặc mặt khẩu", "");
                }
                byte[] hash = KeyDerivation.Pbkdf2(request.Password, account.PasswordSalt, KeyDerivationPrf.HMACSHA256, 10000, 32);
                if (hash.SequenceEqual(account.PasswordHash))
                {
                    string token = GenerateJwtToken(account.UserName, account.Role.RoleName);
                    LogInResponse logInResponse = new LogInResponse();
                    logInResponse.AccessToken = token;
                    logInResponse.StoreId = account.StoreId;
                    logInResponse.AvatarLink = account.AvatarLink;
                    logInResponse.UserName = account.UserName;
                    logInResponse.AccountId = account.AccountId;
                    logInResponse.RoleId = account.RoleId;
                    logInResponse.FullName = account.FullName;
                    return logInResponse;
                }
                else {
                    throw new CrudException(HttpStatusCode.BadRequest, "Sai tài khoản hoặc mặt khẩu", "");
                }

            }
            catch (CrudException cex)
            {
                throw cex;
            }
            catch (Exception ex)
            {
                throw new CrudException(HttpStatusCode.InternalServerError, "Lỗi hệ thống!", ex?.Message);
            }
        }

        public SignUpResponse SignUp(SignUpRequest request)
        {
            try
            {
                byte[] salt = new byte[16];
                var random = RandomNumberGenerator.Create();

                random.GetBytes(salt);

                byte[] hash = KeyDerivation.Pbkdf2(request.Password, salt, KeyDerivationPrf.HMACSHA256, 10000, 32);

                Account acc = new Account();
                acc.UserName = request.UserName;
                acc.PasswordHash = hash;
                acc.PasswordSalt = salt;
                acc.FullName = request.FullName;
                acc.Email = request.Email;
                acc.PhoneNumber = request.PhoneNumber;
                acc.Status = true;
                acc.Gender = request.Gender;
                acc.RoleId = request.RoleId;



                Account rs = AccountDAO.Instance.Add(acc);
                SignUpResponse signUpResponse = new SignUpResponse();
                signUpResponse.Email = rs.Email;
                signUpResponse.PhoneNumber = rs.PhoneNumber;
                signUpResponse.Status = rs.Status;
                signUpResponse.UserName = rs.UserName;
                signUpResponse.FullName = rs.FullName;
                signUpResponse.Gender = rs.Gender;
                signUpResponse.RoleId = rs.RoleId;
                signUpResponse.AccountId = rs.AccountId;
                return signUpResponse;

            }
            catch (CrudException cex)
            {
                throw cex;
            }
            catch (Exception ex)
            {
                throw new CrudException(HttpStatusCode.InternalServerError, "Lỗi hệ thống!", ex?.Message);
            }
        }
    }
}
