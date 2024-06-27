using AutoMapper;
using OrderOut.DtosOU.Dtos;
using OrderOut.EF.Models;
using OrderOut.Repositorys;

namespace OrderOut.Services.tableWaiter
{
    public class TableWaiterService : ITableWaiterService
    {
        private readonly ITableWaiterRepository _tableWaiterRepository;
        private readonly IMapper _mapper;

        public TableWaiterService(ITableWaiterRepository tableWaiterRepository,
                            IMapper mapper)
        {
            _tableWaiterRepository = tableWaiterRepository;
            _mapper = mapper;
        }

        public async Task<List<TableWaiter>> GetAllTablesWaiters()
        {
            var tables = await _tableWaiterRepository.GetAllTablesWaiters();
            var response = _mapper.Map<List<TableWaiter>>(tables);
            return response;
        }

        public async Task<TableWaiter> GetTableWaiter(int tableWaiterId)
        {
            var table = await _tableWaiterRepository.GetTableWaiter(tableWaiterId);
            var response = _mapper.Map<TableWaiter>(table);
            return response;
        }

        public async Task<bool> AssignTablesToWaiters(TableWaiterDto request)
        {
            var newTableWaiter = _mapper.Map<TableWaiter>(request);
            var response = await _tableWaiterRepository.AssignTablesToWaiters(newTableWaiter);
            return response;
        }

        public async Task<bool> UpdateTableWaiter(TableWaiterDto request)
        {
            var tableWaiter = _mapper.Map<TableWaiter>(request);
            var response = await _tableWaiterRepository.UpdateTableWaiter(tableWaiter);
            return response;
        }

        public async Task<bool> DeleteTableWaiter(int tableWaiterId)
        {
            var response = await _tableWaiterRepository.DeleteTableWaiter(tableWaiterId);
            return response;
        }
    }
}
