using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using OrderOut.DtosOU.Dtos;
using OrderOut.EF.Models;
using OrderOut.Repositorys;

namespace OrderOut.Services.waiter
{
    public class WaiterService : IWaiterService
    {
        private readonly IWaiterRepository _waiterRepository;
        private readonly IMapper _mapper;

        public WaiterService(IWaiterRepository waiterRepository,
                             IMapper mapper)
        {
            _waiterRepository = waiterRepository;
            _mapper = mapper;
        }

        public async Task<List<Waiter>> GetAllWaiters()
        {
            var waiters = await _waiterRepository.GetAllWaiters();
            var response = _mapper.Map<List<Waiter>>(waiters);
            return response;
        }

        public async Task<Waiter> GetWaiter(int waiterId)
        {
            var waiter = await _waiterRepository.GetWaiter(waiterId);
            var response = _mapper.Map<Waiter>(waiter);
            return response;
        }

        public async Task<bool> CreateWaiter(WaiterDto request)
        {
            var newWaiter = _mapper.Map<Waiter>(request);
            var response = await _waiterRepository.CreateWaiter(newWaiter);
            return response;
        }

        public async Task<bool> UpdateWaiter(WaiterDto request)
        {
            var waiter = _mapper.Map<Waiter>(request);
            var response = await _waiterRepository.UpdateWaiter(waiter);
            return response;
        }

        public async Task<bool> DeleteWaiter(int waiterId)
        {
            var response = await _waiterRepository.DeleteWaiter(waiterId);
            return response;
        }
    }
}
