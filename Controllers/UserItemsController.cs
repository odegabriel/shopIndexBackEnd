using Microsoft.AspNetCore.Authentication.JwtBearer;
using MyProjectWithoutDocker.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using MyProjectWithoutDocker.Dtos;
using MyProjectWithoutDocker.Entity;
using System.Diagnostics.Eventing.Reader;

namespace MyProjectWithoutDocker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserItemsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<UserItemsController> _logger;

        public UserItemsController(ILogger<UserItemsController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        // add items to users cart
        [HttpGet("/{userId}/{itemsId}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> AddToCart ([FromRoute] Guid userId, [FromRoute] Guid itemsId)
        {
            try
            {
                var item = _context.Items.Find(itemsId);
                if (item == null)
                {
                    return BadRequest("can not send an empty request");
                }
                
                var newItem = new UserItemsModel
                {
                    Id = Guid.NewGuid(),
                    Brand = item.Brand,
                    Title = item.Title,
                    Price = item.Price,
                    DiscountPrice = item.DiscountPrice,
                    PhotoUrl = item.PhotoUrl,
                    UserId = userId
                };
                await _context.UserItemsModels.AddAsync(newItem);
                await _context.SaveChangesAsync();
                return Ok("item added succesfully");

            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
            
        }

        //delete items from user cart
        [HttpDelete("/user/delete/{ItemsId}")]

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> DeleteItem([FromRoute] Guid itemsId)
        {
            try
            {
                var item = await _context.UserItemsModels.FindAsync(itemsId);
                if (item == null)
                {
                    return BadRequest("item not foound");
                }
                _context.Remove(item);
                await _context.SaveChangesAsync();
                return Ok("item has been deleted");


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //get all users items
        [HttpGet("/{userId}/item")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult GetUserItem(Guid userId)
        {
            try
            {
                var userItems = _context.UserItemsModels.Where(e => e.UserId == userId).ToList();

                if (userItems == null)
                {
                    return BadRequest("items not found");
                }
                return Ok(userItems);

            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }

                //var result = new List<UserItemsModel>();

                //if (userItems == null)
                //{
                //    return BadRequest("no item found");
                //}
                //foreach (var item in userItems)
                //{
                //    if (item.UserId.Equals(userItems))
                //    {
                //        result.Add(item);
                //    }
                //}
                //return Ok(result);

            }

        //get items details
        [HttpGet("/")]
        public IActionResult GetAllItems ()
        {
            try
            {
                var items = _context.Items.ToList();
                if (items == null)
                {
                    return BadRequest("no item found");
                }
                return Ok(items);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/user/{itemId}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetItemsDetails(Guid itemId)
        {
            try
            {
                var item = await _context.Items.FirstOrDefaultAsync(e => e.Id == itemId);
                return Ok(item);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

    }
    }
