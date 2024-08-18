using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using OrderOut.DtosOU.Dtos;
using OrderOut.EF.Models;
using OrderOut.Enums;
using OrderOut.Repositorys;

namespace OrderOut.Services.table
{
    public class TableService : ITableService
    {
        private readonly ITableRepository _tableRepository;
        private readonly IMapper _mapper;

        public TableService(ITableRepository tableRepository,
                            IMapper mapper)
        {
            _tableRepository = tableRepository;
            _mapper = mapper;
        }

        public async Task<List<Table>> GetAllTables()
        {
            var tables = await _tableRepository.GetAllTables();
            var response = _mapper.Map<List<Table>>(tables);
            return response;
        }

        public async Task<Table> GetTable(int tableId)
        {
            var table = await _tableRepository.GetTable(tableId);
            var response = _mapper.Map<Table>(table);
            return response;
        }

        public async Task<bool> CreateTable(TableDto request)
        {
            var newTable = _mapper.Map<Table>(request);
            newTable.State = (int)TableState.Libre;
            var response = await _tableRepository.CreateTable(newTable);
            return response;
        }

        //public async Task<bool> AssignTablesToWaiters(TableWaiterDto request)
        //{
        //    var newTableWaiter = _mapper.Map<TableWaiter>(request);
        //    var response = await _tableRepository.CreateTableWaiter(newTableWaiter);
        //    return response;
        //}

        public async Task<bool> UpdateTable(TableDto request)
        {
            var table = _mapper.Map<Table>(request);
            var response = await _tableRepository.UpdateTable(table);
            return response;
        }

        public async Task<bool> DeleteTable(int tableId)
        {
            var response = await _tableRepository.DeleteTable(tableId);
            return response;
        }
    }
}
