using HRMSApp.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HRMSApp.ViewComponents
{
    [ViewComponent(Name = "Menu")]
    public class MenuViewComponent : ViewComponent
    {
        private readonly IDashboardService _dashboardServices;
        public MenuViewComponent(IDashboardService dashboardService)
        {
            _dashboardServices = dashboardService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            //var userId = HttpContext.User.FindFirstValue(ClaimTypes.Sid);
            //var userType = HttpContext.User.FindFirstValue(ClaimTypes.Role);
            var menuList = await _dashboardServices.GetAllMenuItem();
            foreach (var menu in menuList)
            {
                foreach (var subMenu in menuList.Where(x => x.ParentId != 0).ToList())
                {
                    if (subMenu.ParentId == menu.MenuId)
                    {
                        menu.HasChild = true;
                    }
                    foreach(var subSubMenu in menuList.Where(x => x.ParentId != 0).ToList())
                    {
                        if (subSubMenu.ParentId == subMenu.MenuId)
                        {
                            subMenu.HasChild = true;
                        }
                    }
                }
            }
            return View("Menu", menuList);
        }
    }
}
