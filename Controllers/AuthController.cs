using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyTodoListApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTodoListApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController:ControllerBase
    {
        protected UserManager<CurrentUser> appUserManager;
        protected SignInManager<CurrentUser> appSignInManager;
        public AuthController(UserManager<CurrentUser> injectedUM , SignInManager<CurrentUser> injectedSM )
        {
            appUserManager = injectedUM;
            appSignInManager = injectedSM;
        }


        
        [HttpPost]
        public async Task<ActionResult> Register(CurrentUser user)
        {


            var newUser = await appUserManager.CreateAsync(user , user.Password);
            if (newUser.Succeeded == false)
            {
                var errors = newUser.Errors.ToList();

                foreach (IdentityError er in errors)
                {
                    Console.WriteLine(er.Description);
                }

                 return Unauthorized(newUser);
                
            }
            return Ok("Created Successfully");
        
        }

    }
}
