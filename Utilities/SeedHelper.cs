//using BlogMVC.Data;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace BlogMVC.Utilities
//{
//    public class SeedHelper
//    {
//        private ApplicationDbContext _context;
//        public SeedHelper(ApplicationDbContext context)
//        {
//            _context = context;
//        }
//        public async void SeedRoles()
//        {
//            var roleStore = new RoleStore<IdentityRole>(_context);
//            var roles = new List<string> { "Admin", "Moderator" };
//            foreach (var role in roles)
//            {
//                if (!_context.Roles.Any(r => r.Name == role))
//                {
//                    await roleStore.CreateAsync(new IdentityRole { Name = role, NormalizedName = role.ToLower() });
//                }
//            }
//        }
//    }
//}
