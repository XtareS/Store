﻿using Microsoft.AspNetCore.Identity;
using Store_Web.Data.Enteties;
using Store_Web.Models;
using System.Threading.Tasks;

namespace Store_Web.Helpers
{
    public interface IUserHelper
    {

        Task<User> GetUserByEmailAsync(string email);



        Task<IdentityResult> AddUserAsync(User user, string password);


        Task<SignInResult> LoginAsync(LoginViewModel model);


        Task LogoutAsync();



    }
}
