using Microsoft.AspNetCore.Authentication;
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


        
        [HttpPost("/register")]
        public async Task<ActionResult> Register(AuthModel payload)
 
        {
            CurrentUser dBaseRecord = new CurrentUser() {
                Email = payload.Email,
                UserName = payload.Username,
                 
            };

            //implement serverside password verification , i.e password must obey set down rules...

            var newUser = await appUserManager.CreateAsync(dBaseRecord, payload.Password);
            if (newUser.Succeeded == false)
            {
                var errors = newUser.Errors.ToList();

                foreach (IdentityError er in errors)
                {
                    Console.WriteLine(er.Description);
                }

                 return Unauthorized(newUser);
                
            }
            // works fine, saves users to the database 

            return Ok("Created Successfully");
        
        }

        [Route("/login")]

        public  async Task<ActionResult> LogIn()

        {

            var contentUserName = "olaitan1234";
            var contentPassword = "sojman007";
            var signin = await appSignInManager.PasswordSignInAsync(contentUserName, contentPassword, true, false);
            
                if (signin.Succeeded)
            {

                return Ok();

            }

           else  return Content($"UserName from payload : {contentUserName} and password From Payload: {contentPassword} . Login Failed");
        }


        [Route("/logout")]
        public async Task<ActionResult> Logout()
        {
            await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);
                
            return Content("Logged Out successfully");
            // returns the response, but really doesnt implement the logging out as the Authorized ToDo controller is still accessible 
            //after logging out



        }

           
    
    }
}
