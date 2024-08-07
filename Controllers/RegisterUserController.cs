
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyProjectWithoutDocker.Dtos;
using MyProjectWithoutDocker.Entity;
using MyProjectWithoutDocker.Model;
using System.Security.Principal;

namespace MyProjectWithoutDocker.Controllers
{
    
    // For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

    namespace MyProjectController.Controllers
    {
        [Route("[controller]")]
        [ApiController]
        public class RegisterUserController : ControllerBase
        {

            private readonly ApplicationDbContext _context;
            private readonly UserManager<IdentityUser> _userManager;
            private readonly SignInManager<IdentityUser> _signInManager;

            public RegisterUserController(ApplicationDbContext context, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
            {
                _context = context;
                _userManager = userManager;
                _signInManager = signInManager;
            }

            [HttpPost("/signup")]
            public async Task<IActionResult> Register([FromBody] RegisterUserDto model)
            {
                
                var user = new IdentityUser { UserName = model.userName, Email = model.email };
                var result = await _userManager.CreateAsync(user, model.password);
                
                if (result.Succeeded)
                {
                    var createUser = new UserModel
                    {
                        Id = Guid.Parse(user.Id),
                        Email = model.email
                    };
                    _context.UserModels.Add(createUser);
                    _context.SaveChanges();
                    return Ok("User registered successfully!");
                }
                
                return BadRequest(result.Errors);
            }

        }
    }
}
