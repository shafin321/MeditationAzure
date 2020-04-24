using MeiditationActivity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace MeiditationActivity.Data
{
	public class DataSeeder
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;
		private readonly ApplicationDbContext _context;

		public DataSeeder(
			UserManager<ApplicationUser> userManager,
			RoleManager<IdentityRole> roleManager,
			ApplicationDbContext context
		)
		{
			_userManager = userManager;
			_roleManager = roleManager;
			_context = context;
		}

		public async Task MigrateAsync()
		{
			await _context.Database.MigrateAsync();
		}

		public async Task SeedSuperUser()
		{
			var role = new IdentityRole("Administrator");

			if (!_context.Roles.Any(r => r.Name == role.Name))
			{
				await _roleManager.CreateAsync(role);
			}

			var user = new ApplicationUser
			{
				UserName = "admin@test.com",
				Email = "admin@test.com",
				EmailConfirmed = true,
				PhoneNumberConfirmed = true,
				LockoutEnabled = false,
				PhoneNumber = "+880123456789",
				IsActive = true,
				TwoFactorEnabled = false
			};

			if (!_context.Users.Any(u => u.UserName == user.UserName && u.Email == user.Email))
			{
				var result = await _userManager.CreateAsync(user, "Admin123!");
				if (result.Succeeded)
				{
					var isInRole = await _userManager.IsInRoleAsync(user, role.Name);
					if (!isInRole)
						await _userManager.AddToRoleAsync(user, role.Name);
				}
			}
		}
	}
}
