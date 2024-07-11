using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
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
        private readonly DataContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        private readonly IMemoryCache _cache;

        public UserController(DataContext dataContext, UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IMemoryCache cache)
        {
            _context = dataContext;
            _userManager = userManager;
            _roleManager = roleManager;

            _cache = cache;
        }

        [HttpGet]
        public IActionResult GetAllUsers() 
        {
            var users = _context.Users.ToList();

            if (users == null) 
                return NotFound();

            return Ok(users);
        }

        [HttpPost("Modify/Roles/Add/{email}&{role}")]
        public async Task<IActionResult> AddUserRole(string email, string role)
        {
            User? user = _context.Users.FirstOrDefault(u => u.Email == email);

            if (user == null)
                return NotFound("User not found");

            if (await _userManager.IsInRoleAsync(user, role))
                return BadRequest("User has role");

            bool valid = false;

            foreach (var sRole in _context.Roles.ToList())
                if (sRole.Name == role)
                    valid = true;

            if (!valid)
                return NotFound("Role not found");

            await _userManager.AddToRoleAsync(user, role);
            return Ok();
        }

        [HttpPost("Modify/Roles/Remove/{email}&{role}")]
        public async Task<IActionResult> RmvUserRole(string email, string role)
        {
            User? user = _context.Users.FirstOrDefault(u => u.Email == email);

            if (user == null)
                return NotFound("User not found");

            if (!await _userManager.IsInRoleAsync(user, role))
                return BadRequest("User does not have role");

            bool valid = false;

            foreach (var sRole in _context.Roles.ToList())
                if (sRole.Name == role)
                    valid = true;

            if (!valid)
                return NotFound("Role not found");


            await _userManager.RemoveFromRoleAsync(user, role);
            return Ok();
        }

        [HttpGet("Roles/{email}")]
        public async Task<IActionResult> GetUserRoles(string email)
        {
            User? user = _context.Users.FirstOrDefault(u => u.Email == email);

            if (user == null)
                return NotFound("User not found");

            var roles = await _userManager.GetRolesAsync(user);
            return Ok(roles);
        }

        [Authorize(Roles = "Admin, Manager")]
        [HttpGet("Roles/Current/")]
        public async Task<IActionResult> GetCurrUserRoles()
        {
            var user = await _userManager.GetUserAsync(this.User);

            if (user == null)
                return NotFound("User not found");

            var roles = await _userManager.GetRolesAsync(user);
            return Ok(roles);
        }

        [Authorize]
        [HttpGet("Current")]
        public async Task<IActionResult> GetCurrUser()
        {
            var user = await _userManager.GetUserAsync(this.User);
            if (user == null)
                return NotFound("User not found");

            return Ok(user);
        }
    }
}
