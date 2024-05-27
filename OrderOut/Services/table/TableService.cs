using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using OrderOut.EF.Models;
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

        public List<Table> GetAllTables()
        {
            var tables = _tableRepository.GetAllTables();
            var response = _mapper.Map<List<Table>>(tables);
            return response;
        }

        public Table GetTable(int tableId)
        {
            var table = _tableRepository.GetTable(tableId);
            var response = _mapper.Map<Table>(table);
            return response;
        }

        public async Task<bool> CreateTable(Table request)
        {
            var newTable = _mapper.Map<Table>(request);
            var response = await _tableRepository.CreateTable(newTable);
            return response;
        }

        public async Task<bool> UpdateTable(Table request)
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
