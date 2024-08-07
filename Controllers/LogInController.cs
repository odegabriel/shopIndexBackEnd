using MyProjectWithoutDocker.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using MyProjectWithoutDocker.Entity;
using MyProjectWithoutDocker.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyProjectController.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LogInController : ControllerBase
    {
        private IEnumerable<ItemsModel> Items = new List<ItemsModel>()
     {
         new(){
                 Id = Guid.NewGuid(),
                 Brand = "Lenovo | Similar product from lenovo",
                 Title = "Lenovo ThinkPad X1 Carbon G9 Touchscreen 11th Gen",
                 Price = "1,658,000",
                 DiscountPrice = "1,780,00",
                 PhotoUrl = "https://res.cloudinary.com/dvxfph8qu/image/upload/w_1000,ar_1:1,c_fill,g_auto,e_art:hokusai/v1721692982/1_10_dow87w.jpg"
             },
             new(){
                     Id = Guid.NewGuid(),
                     Brand =  "La Roche Posay | Similar products from La Roche Posay",
                     Title = "La Roche Posay La Roche-Posay Anthelios Shaka Fluid SPF 50+",
                     Price = "8,000",
                     DiscountPrice = "7,200" ,
                     PhotoUrl = "https://res.cloudinary.com/dvxfph8qu/image/upload/w_1000,ar_1:1,c_fill,g_auto,e_art:hokusai/v1721691080/1_ixg2vw.jpg"
                 },
                 new(){
                     Id = Guid.NewGuid(),
                     Brand = "",
                     Title = "Men's Sandals Casual Breathable PU Leather Shoes - Black",
                     Price = "11,500",
                     DiscountPrice = "10,400",
                     PhotoUrl = "https://res.cloudinary.com/dvxfph8qu/image/upload/w_1000,ar_1:1,c_fill,g_auto,e_art:hokusai/v1721691341/1_1_ozzjy9.jpg"
                     },

                 new(){
                     Id = Guid.NewGuid(),
                     Brand = "",
                     Title = "X52 Mobile Phone Cooler Rechargeable Fast Cooling",
                     Price = "5,500",
                     DiscountPrice = "4,300",
                     PhotoUrl = "https://res.cloudinary.com/dvxfph8qu/image/upload/w_1000,ar_1:1,c_fill,g_auto,e_art:hokusai/v1721687853/gyrpbib5ioijzjxhyhtv.jpg"
                     },
                 new(){
                     Id = Guid.NewGuid(),
                     Brand = "",
                     Title = "Men's Sandals Casual Breathable PU Leather Shoes - Black",
                     Price = "11,500",
                     DiscountPrice = "10,400",
                     PhotoUrl = "https://res.cloudinary.com/dvxfph8qu/image/upload/w_1000,ar_1:1,c_fill,g_auto,e_art:hokusai/v1721691341/1_1_ozzjy9.jpg"
                     },

                 new(){
                     Id = Guid.NewGuid(),
                     Brand = "",
                     Title = "X52 Mobile Phone Cooler Rechargeable Fast Cooling",
                     Price = "5,500",
                     DiscountPrice = "4,300",
                     PhotoUrl = "https://res.cloudinary.com/dvxfph8qu/image/upload/w_1000,ar_1:1,c_fill,g_auto,e_art:hokusai/v1721687853/gyrpbib5ioijzjxhyhtv.jpg"
                     },

                 new(){
                     Id = Guid.NewGuid(),
                     Brand =  "XIAOMI | Similar products from XIAOMI",
                     Title = $"XIAOMI Redmi A3x 6.71\" 3GB RAM/64GB ROM Android 14 - Green\\",
                     Price = "120,000",
                     DiscountPrice = "96,000",
                     PhotoUrl = "https://res.cloudinary.com/dvxfph8qu/image/upload/w_1000,ar_1:1,c_fill,g_auto,e_art:hokusai/v1721691528/1_2_bo28up.jpg"
                     },
                 new(){
                     Id = Guid.NewGuid(),
                     Brand =  "Hp | Similar products from Hp",
                     Title = "Hp Refurbished EliteBook 840 G5 Intel Core I5-16GB RAM-1TB SSD WIN 11",
                     Price = "410,999",
                     DiscountPrice = "390,999",
                     PhotoUrl = "https://res.cloudinary.com/dvxfph8qu/image/upload/w_1000,ar_1:1,c_fill,g_auto,e_art:hokusai/v1721691746/1_3_mkuvtg.jpg"
                     },

                 new(){
                     Id = Guid.NewGuid(),
                     Brand = "Aeon | Similar products from Aeon",
                     Title = "Aeon 200L Chest Freezer (ACF200GK) - Grey- 1 YEAR WARRANTY",
                     Price = "240,000",
                     DiscountPrice = "230,000",
                     PhotoUrl = "https://res.cloudinary.com/dvxfph8qu/image/upload/w_1000,ar_1:1,c_fill,g_auto,e_art:hokusai/v1721691996/1_4_wafrcp.jpg"
                     },

                 new(){
                     Id = Guid.NewGuid(),
                     Brand = "",
                     Title = "Gaming Desk, 55 Inch Gaming Table With LED RGB Lights,1.4MTR",
                     Price = "220,000",
                     DiscountPrice = "",
                     PhotoUrl = "https://res.cloudinary.com/dvxfph8qu/image/upload/w_1000,ar_1:1,c_fill,g_auto,e_art:hokusai/v1721692143/1_5_dpkyoz.jpg"
                     },

                 new(){
                     Id = Guid.NewGuid(),
                     Brand = "",
                     Title = "Executive Gaming Chair With Foot Rest",
                     Price = "260,000",
                     DiscountPrice = "240,000",
                     PhotoUrl = "https://res.cloudinary.com/dvxfph8qu/image/upload/w_1000,ar_1:1,c_fill,g_auto,e_art:hokusai/v1721692255/1_6_eroktu.jpg"
                     },

                 new(){
                     Id = Guid.NewGuid(),
                     Brand =  "Hp | Similar products from Hp",
                     Title = "Hp M24fwa (23.8\" ) FHD IPS Monitor (White) With Audio",
                     Price = "279,000",
                     DiscountPrice = "",
                     PhotoUrl = "https://res.cloudinary.com/dvxfph8qu/image/upload/w_1000,ar_1:1,c_fill,g_auto,e_art:hokusai/v1721692419/1_7_warbip.jpg"
                     },

                 new(){
                     Id = Guid.NewGuid(),
                     Brand = "",
                     Title = "Wired Luminescent Gaming Mouse",
                     Price = "6,500",
                     DiscountPrice = "",
                     PhotoUrl = "https://res.cloudinary.com/dvxfph8qu/image/upload/w_1000,ar_1:1,c_fill,g_auto,e_art:hokusai/v1721692521/1_8_qkftkq.jpg"
                     },

                 new(){
                     Id = Guid.NewGuid(),
                     Brand = "",
                     Title = "PS4 Controller Wireless PlayStation 4 PS4 Game Pad",
                     Price = "36,958",
                     DiscountPrice = "24,906",
                     PhotoUrl = "https://res.cloudinary.com/dvxfph8qu/image/upload/w_1000,ar_1:1,c_fill,g_auto,e_art:hokusai/v1721692682/1_9_eg6jno.jpg"

                 } };


        private ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private IConfiguration _config;
        public LogInController(IConfiguration config, ApplicationDbContext context, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _config = config;
            _context = context;
        }
        [HttpPost("/login")]
        public async Task<IActionResult> Login([FromBody] LogInDto model)
        {
            //foreach (var item in Items)
            //{
            //    _context.Items.Add(new ItemsModel 
            //    { 
            //        Brand = item.Brand,
            //        Title = item.Title, 
            //        Price = item.Price,
            //        DiscountPrice = item.DiscountPrice,
            //        PhotoUrl = item.PhotoUrl,
            //    });
            //    _context.SaveChanges();
            //}


            var result = await _signInManager.PasswordSignInAsync(model.userName, model.password, false, false);
       
            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(model.userName);
                var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_config["Jwt:key"]);

                if (user == null)
                {
                    return NotFound();
                }
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);

                return Ok(new { token = tokenString,
                                User = user.Id
                              });
            }

            return Unauthorized("Invalid login attempt.");
        }

    }
}
