using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

using Server.Data;
using Server.Interfaces;
using Server.Models;

namespace Server.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("/api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly DataContext context;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public UserController(DataContext dataContext, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            context = dataContext;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult GetAllUsers() 
        {
            var users = context.Users.ToList();

            if (users == null) 
                return NotFound();

            return Ok(users);
        }

        [HttpPost("Modify/Roles/Add/{email}&{role}")]
        public async Task<IActionResult> AddUserRole(string email, string role)
        {
            User? user = context.Users.FirstOrDefault(u => u.Email == email);

            if (user == null)
                return NotFound("User not found");

            if (await userManager.IsInRoleAsync(user, role))
                return BadRequest("User has role");

            bool valid = false;

            foreach (var sRole in context.Roles.ToList())
                if (sRole.Name == role)
                    valid = true;

            if (!valid)
                return NotFound("Role not found");

            await userManager.AddToRoleAsync(user, role);
            return Ok();
        }

        [HttpPost("Modify/Roles/Remove/{email}&{role}")]
        public async Task<IActionResult> RmvUserRole(string email, string role)
        {
            User? user = context.Users.FirstOrDefault(u => u.Email == email);

            if (user == null)
                return NotFound("User not found");

            if (!await userManager.IsInRoleAsync(user, role))
                return BadRequest("User does not have role");

            bool valid = false;

            foreach (var sRole in context.Roles.ToList())
                if (sRole.Name == role)
                    valid = true;

            if (!valid)
                return NotFound("Role not found");


            await userManager.RemoveFromRoleAsync(user, role);
            return Ok();
        }

        [HttpGet("Roles/{email}")]
        public IActionResult GetUserRoles(string email)
        {
            User? user = context.Users.FirstOrDefault(u => u.Email == email);

            if (user == null)
                return NotFound("User not found");

            var roles = context.Roles.ToList();
            return Ok(roles);
        }

            [Authorize]
        [HttpGet("Current")]
        public async Task<IActionResult> GetCurrUser()
        {
            var user = await userManager.GetUserAsync(this.User);
            if (user == null)
                return NotFound("User not found");

            return Ok(user);
        }
    }
}
