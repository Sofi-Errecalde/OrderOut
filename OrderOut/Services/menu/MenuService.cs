using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using OrderOut.EF.Models;
using OrderOut.Repositorys;

namespace OrderOut.Services.menu
{
    public class MenuService : IMenuService
    {
        private readonly IMenuRepository _menuRepository;
        private readonly IMapper _mapper;

        public MenuService(IMenuRepository menuRepository,
                           IMapper mapper)
        {
            _menuRepository = menuRepository;
            _mapper = mapper;
        }

        public async Task<List<Menu>> GetAllMenus()
        {
            var menus = await _menuRepository.GetAllMenus();
            var response = _mapper.Map<List<Menu>>(menus);
            return response;
        }

        public async Task<Menu> GetMenu(int menuId)
        {
            var menu = await _menuRepository.GetMenu(menuId);
            var response = _mapper.Map<Menu>(menu);
            return response;
        }

        public  bool CreateMenu(Menu request)
        {
            var newMenu = _mapper.Map<Menu>(request);
            var response =   _menuRepository.CreateMenu(newMenu);
            return response;
        }

        public  bool UpdateMenu(Menu request)
        {
            var menu = _mapper.Map<Menu>(request);
            var response =   _menuRepository.UpdateMenu(menu);
            return response;
        }

        public  bool DeleteMenu(int menuId)
        {
            var response =   _menuRepository.DeleteMenu(menuId);
            return response;
        }
    }
}
