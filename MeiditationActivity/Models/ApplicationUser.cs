﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeiditationActivity.Models
{
	public class ApplicationUser : IdentityUser
	{
		public string ProfileImageurl { get; set; }
		public DateTime MemberSince { get; set; }
		public bool IsActive { get; set; }

	}
}
