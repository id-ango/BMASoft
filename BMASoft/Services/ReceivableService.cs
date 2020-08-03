using BMASoft.Data;
using BMASoft.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;
using Syncfusion.Drawing;
using BMASoft.Pages.Piutang;

namespace BMASoft.Services
{
    public interface IReceivableService
    {
        Task<List<ArCust>> GetCustomer();
        Task<bool> AddCustomer(CustomerView customers);
        Task<bool> EditCustomer(CustomerView customers);
        Task<bool> DelCustomer(CustomerView customers);
    }

    public class ReceivableService:IReceivableService
    {
        private readonly BmaDbContext _context;

        public ReceivableService(BmaDbContext context)
        {
            _context = context;
        }

        public async Task<List<ArCust>> GetCustomer()
        {
            return await _context.ArCusts.ToListAsync();
        }

        public async Task<bool> AddCustomer(CustomerView customers)
        {
            string test = customers.Customer.ToUpper();
            var cekFirst = _context.ArCusts.Where(x => x.Customer == test).ToList();
            if (cekFirst.Count == 0)
            {
                ArCust Customer = new ArCust()
                {
                    Customer = customers.Customer.ToUpper(),
                    NamaCust = customers.NamaCust,
                    Alamat = customers.Alamat,
                    Kota = customers.Kota,
                    Telpon = customers.Telpon

                };
                _context.ArCusts.Add(Customer);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {

                return false;
            }

        }

        public async Task<bool> EditCustomer(CustomerView customers)
        {
            try
            {
                var ExistingCustomer = _context.ArCusts.Where(x => x.ArCustId == customers.ArCustId).FirstOrDefault();
                if (ExistingCustomer != null)
                {
                    ExistingCustomer.NamaCust = customers.Customer;
                    ExistingCustomer.Alamat = customers.Alamat;
                    ExistingCustomer.Kota = customers.Kota;
                    ExistingCustomer.Telpon = customers.Telpon;
                    

                    await _context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return false;

        }

        public async Task<bool> DelCustomer(CustomerView customers)
        {
            try
            {
                var ExistingCustomer = _context.ArCusts.Where(x => x.ArCustId == customers.ArCustId).FirstOrDefault();
                if (ExistingCustomer != null)
                {
                    _context.ArCusts.Remove(ExistingCustomer);
                    await _context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return false;

        }
    }
}
