using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Portfolio.Models;

namespace Portfolio.ViewModels
{
    public class ManageRole
    {
        public ManageRole()
        {
        }

        public IEnumerable<IdentityRole> BlogRoles { get; set; }
        public string BlogRoleUserName { get; set; }
        public string BlogRoleAssignment { get; set; }
        public IEnumerable<SelectListItem> RolesToSelect { get; set; }

        public void SetSelectList()
        {
            RolesToSelect = BlogRoles.Select(role => new SelectListItem()
            {
                Text = role.Name.ToString(),
                Value = role.Name.ToString()
            });
        }
    }
}
