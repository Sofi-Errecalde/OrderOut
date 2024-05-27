using Microsoft.AspNetCore.Mvc;
using OrderOut.EF.Models;
using OrderOut.Services.menu;

namespace OrderOut.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MenuController : Controller
    {
        private readonly IMenuService _menuService;

        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        [HttpGet]
        [Route("GetMenu")]
        public Menu GetMenu(int menuId)
        {
            return _menuService.GetMenu(menuId);
        }

        [HttpGet]
        [Route("AllMenus")]
        public  List<Menu> AllMenus()
        {
            return   _menuService.GetAllMenus();
        }

        [HttpPost]
        [Route("CreateMenu")]
        public  bool CreateMenu(Menu menu)
        {
            return   _menuService.CreateMenu(menu);
        }

        [HttpPut]
        [Route("UpdateMenu")]
        public  bool UpdateMenu(Menu menu)
        {
            return   _menuService.UpdateMenu(menu);
        }

        [HttpDelete]
        [Route("DeleteMenu")]
        public  bool DeleteMenu(int menuId)
        {
            return   _menuService.DeleteMenu(menuId);
        }
    }
}
