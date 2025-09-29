using ITP_SEM_2_ASS_1.Models;
using ITP_SEM_2_ASS_1.Models.Entitties;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Net.WebSockets;
using System.Text.RegularExpressions;

namespace ITP_SEM_2_ASS_1.Controllers
{

    [ApiController]
    [Route("api/[Controller]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;

        }

        //  Register a new user
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto newUser)
        {
            try
            {

                var role = DetermineRoleFromEMail(newUser.Email);
                //create new user
                var user = new ApplicationUser
                {
                    UserName = newUser.Email,
                    Email = newUser.Email

                };

                var result = await _userManager.CreateAsync(user, newUser.Password);
                if (!result.Succeeded)
                {
                    return BadRequest(result.Errors); // we need to put  a proper message here that is user friendly
                }

                //Ensure if role exists
                if(!await _roleManager.RoleExistsAsync(role))
                        await _roleManager.CreateAsync(new ApplicationRole { Name = role });

                // Assigns the role
                await _userManager.AddToRoleAsync(user, role);

                return Ok(new { message = "User registered successfully",role});

            }
            catch(ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        private string DetermineRoleFromEMail(string email)
        {

            // Validate email format
            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                throw new ArgumentException("Invalid email format.");

            // Admin = any email ending with @gmail.com
            if (email.EndsWith("@gmail.com", StringComparison.OrdinalIgnoreCase))
                return "Admin";

            // Lecturer = any email ending with @university.edu
            if (email.EndsWith("@university.edu", StringComparison.OrdinalIgnoreCase))
                return "Lecturer";

            // Student = any email ending with @student.university.edu
            if (email.EndsWith("@student.university.edu", StringComparison.OrdinalIgnoreCase))
                return "Student";

            // Unrecognized emails
            throw new ArgumentException("Email domain not recognized for a role.");

        }


        //  Login a user

        [HttpPost("login")]
        public async Task<IActionResult> Login(string email, string password)
        {
            // 1. Validate email format
            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                return BadRequest("Invalid email format.");

            // 2. Find the user in the database
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                return Unauthorized("Invalid login attempt.");

            // 3. Check the password
            var result = await _signInManager.CheckPasswordSignInAsync(user, password, false);
            if (!result.Succeeded)
                return Unauthorized("Invalid login attempt.");

            // 4. Automatically determine role based on email domain
            string role;
            if (email.EndsWith("@gmail.com", StringComparison.OrdinalIgnoreCase))
                role = "Admin";
            else if (email.EndsWith("@university.edu", StringComparison.OrdinalIgnoreCase))
                role = "Lecturer";
            else if (email.EndsWith("@student.university.edu", StringComparison.OrdinalIgnoreCase))
                role = "Student";
            else
                role = "Guest"; // fallback for unknown emails

            // 5. Return success with user info and role
            return Ok(new
            {
                message = "Login successful!",
                email = user.Email,
                role = role
            });
        }
    }
}
