using MeiditationActivity.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeiditationActivity.Models
{
	public class ApplicationUserService : IApplicationUser
	{
		private readonly ApplicationDbContext _context;
		public ApplicationUserService(ApplicationDbContext context)
		{
			_context = context;
		}
		public IEnumerable<ApplicationUser> GetAll()
		{
			return _context.Users.ToList();
		}

		public ApplicationUser GetById(string id)
		{
			return _context.Users.SingleOrDefault(user => user.Id == id);
		}
	}
}
