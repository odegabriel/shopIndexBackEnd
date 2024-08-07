using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyProjectWithoutDocker.Dtos;
using MyProjectWithoutDocker.Entity;
using MyProjectWithoutDocker.ReturnDto;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyProjectWithoutDocker.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserDetailsController : ControllerBase
    {
        private ApplicationDbContext _context;
        public UserDetailsController(ApplicationDbContext context) 
        { 
            _context = context;
        } 
        // get user information
        [HttpGet("/getUserInfo/{id}")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult GetUserInfo ([FromRoute] Guid id)
        {
            try
            {
                var result = new UserUpdateRDto();
                var user = _context.UserModels.FirstOrDefault(e => e.Id == id);
                if (user == null)
                {
                    return BadRequest("user not found");
                }
                result = new()
                {
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    PhoneNumber = user.PhoneNumber
                };
                //var users = _context.UserModels.ToList();
                //foreach (var user in users)
                //{
                //    if (user.Id == id)
                //    {
                //        result = new UserUpdateRDto
                //        {
                //            Email = user.Email,
                //            FirstName = user.FirstName,
                //            LastName = user.LastName,
                //            PhoneNumber = user.PhoneNumber
                //        };
                //    }
                //}
                return Ok(result);

            }

            catch (Exception ex)
            
            {
                return BadRequest(ex.Message);
            }
        }



        // update user information
        [HttpPost("/profile/{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult UpdateUserDeails ([FromRoute] Guid id, [FromBody] UserUpdateDto userDetails)
        {
            try
            {
                
                var user = _context.UserModels.FirstOrDefault(x => x.Id == id);
                if (user == null)
                {
                    return BadRequest("user does not exist");

                }

                user.FirstName = userDetails.firstName;
                user.LastName = userDetails.lastName;
                user.Email = userDetails.email;
                user.PhoneNumber = userDetails.phoneNumber;

                _context.SaveChanges();
                return Ok("updated succesfully ");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }

    }
}
