using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewsPortal.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsPortal.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdministrationController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<IdentityUser> userManager;

        public AdministrationController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }
        public IActionResult ListRoles()
        {
            var result = roleManager.Roles;
            return View(result);
        }

        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        async public Task<IActionResult> CreateRole(RoleModel roleModel)
        {
            var identityRole = new IdentityRole(roleModel.RoleName);
            var result = await roleManager.CreateAsync(identityRole);
            if (result.Succeeded)
            {
                return RedirectToAction("ListRoles", "Administration");
            }
            return View(roleModel);
        }

        [Authorize(Roles="Admin")]
        [HttpPost]
        public async Task<IActionResult> DeleteRole(string id) {
            var role = await roleManager.FindByIdAsync(id);
            if (role == null) {
                ViewBag.ErrorMessage = $"Role with ID : {id} cannot be found";
                return View("NotFound");
            }
            else {
                try {
                    var result = await roleManager.DeleteAsync(role);
                    if (result.Succeeded) {
                        return RedirectToAction("ListRoles");
                    }
                    return View("ListRoles");
                }
                catch (DbUpdateException) {
                    ViewBag.ErrorTitle = $"The role {role.Name} is in use";
                    ViewBag.ErrorMessage = $"The role {role.Name} cannot be deleted as there are users" +
                        $"in this role . If you want to delete this role , please remove the users from  " +
                        $"the role and then try to delete";
                    return View("Error");
                }
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> EditRole(string id) {
            var role = await roleManager.FindByIdAsync(id);
            RoleModel model = new RoleModel { Id = role.Id, RoleName = role.Name };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRole(RoleModel model) {
            var role = await roleManager.FindByIdAsync(model.Id);
            if (role == null) {
                ViewBag.ErrorMessage = $"Role with Id = {model.Id} cannot be found";
                return View("NotFound");
            }
            else {
                role.Name = model.RoleName;
                var result = await roleManager.UpdateAsync(role);
                if (result.Succeeded) {
                    return RedirectToAction("ListRoles");
                }
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        async public Task<IActionResult> CreateUser(UserModel model)
        {
            //do kushte
            var user = new IdentityUser { UserName = model.Username, Email = model.Username };
            var result = await userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("ListUsers", "Administration");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult ListUsers()
        {
            return View(userManager.Users);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> ManageUserRoles(string userId)
        {
            ViewBag.userID = userId;
            var user = await userManager.FindByIdAsync(userId);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with ID : {userId} cannot be found";
                return View("NotFound");
            }

            var model = new List<ManageUserRolesModel>();

            var roles = roleManager.Roles;

            foreach (var item in roles)
            {
                var userrolemodel = new ManageUserRolesModel
                {
                    RoleId = item.Id,
                    RoleName = item.Name
                };

                if (await userManager.IsInRoleAsync(user, item.Name))
                {
                    userrolemodel.IsSelected = true;
                }
                else
                {
                    userrolemodel.IsSelected = false;
                }
                model.Add(userrolemodel);
            }
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> ManageUserRoles(List<ManageUserRolesModel> model, string userId)
        {
            var user = await userManager.FindByIdAsync(userId);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with ID : {userId} cannot be found";
                return View("NotFound");
            }
            var roles = await userManager.GetRolesAsync(user);
            var result = await userManager.RemoveFromRolesAsync(user, roles);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot remove user existing role");
                return View(model);
            }

            result = await userManager.AddToRolesAsync(user, model.Where(x => x.IsSelected).Select(y => y.RoleName));

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot add selected role to user");
                return View(model);
            }
            return RedirectToAction("ListUsers");
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult AccessDenied() {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> DeleteUser(string id) {
            var user = await userManager.FindByIdAsync(id);
            if (user == null) {
                ViewBag.ErrorMessage = $"User with ID : {id} cannot be found";
                return View("NotFound");
            }
            else {
                var result = await userManager.DeleteAsync(user);
                if (result.Succeeded) {
                    return RedirectToAction("ListUsers");
                }
                foreach (var item in result.Errors) {
                    ModelState.AddModelError("", item.Description);
                }
                return View("ListUsers");
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> EditUser(string id) {
            var user = await userManager.FindByIdAsync(id);
            if (user == null) {
                ViewBag.ErrorMessage = $"User with ID : {id} cannot be found";
                return View("NotFound");
            }


            var model = new UserModel
            {
                Username = user.UserName
            };

            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> UpdateUser(UserModel model) {
            var user = await userManager.FindByIdAsync(model.Id);
            if (user == null) {
                ViewBag.ErrorMessage = $"User with ID : {model.Id} cannot be found";
                return View("NotFound");
            }
            else {
                user.Id = model.Id;
                user.Email = model.Username;
                user.UserName = model.Username;

                var result = await userManager.UpdateAsync(user);
                if (result.Succeeded) {
                    return RedirectToAction("ListUsers");
                }
                foreach (var item in result.Errors) {
                    ModelState.AddModelError("", item.Description);
                }
                return View(model);
            }
        }
    }
}
