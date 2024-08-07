﻿using System.Collections.Generic;
using System.Threading.Tasks;
using OrderOut.DtosOU.Dtos;
using OrderOut.EF.Models;

namespace OrderOut.Repositorys
{
    public interface IBillRepository
    {
        //Task<List<Bill>> GetAllBills();
        Task<Bill> GetBill(long billId);
        Task<Bill> CreateBill(Bill bill);
        Task<Bill> UpdateBill(Bill request);
        //Task<bool> DeleteBill(int billId);
    }
}
