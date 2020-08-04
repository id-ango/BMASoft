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
        Task<List<ArAcct>> GetArAkunSet();
        Task<bool> AddAkunSet(ArAcctView codeview);
        Task<bool> EditAkunSet(ArAcctView codeview);
        Task<bool> DelAkunSet(ArAcctView codeview);
        Task<List<ArDist>> GetDist();
        Task<bool> AddDist(ArDistView codeview);
        Task<bool> EditDist(ArDistView codeview);
        Task<bool> DelDist(ArDistView codeview);
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

        #region ArAcct Class

        public async Task<List<ArAcct>> GetArAkunSet()
        {
            return await _context.ArAccts.ToListAsync();
        }

       

        public async Task<bool> AddAkunSet(ArAcctView codeview)
        {
            string test = codeview.AcctSet.ToUpper();
            var cekFirst = _context.ArAccts.Where(x => x.AcctSet == test).ToList();
            if (cekFirst.Count == 0)
            {
                ArAcct AcctCode = new ArAcct()
                {
                    AcctSet = codeview.AcctSet.ToUpper(),
                    Description = codeview.Description,
                    Acct1 = codeview.Acct1

                };
                _context.ArAccts.Add(AcctCode);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {

                return false;
            }


        }

        public async Task<bool> EditAkunSet(ArAcctView codeview)
        {
            try
            {
                var ExistingAkunSet = _context.ArAccts.Where(x => x.ArAcctId == codeview.ArAcctId).FirstOrDefault();
                if (ExistingAkunSet != null)
                {
                    ExistingAkunSet.Description = codeview.Description;
                    ExistingAkunSet.Acct1 = codeview.Acct1;
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

        public async Task<bool> DelAkunSet(ArAcctView codeview)
        {
            try
            {
                var ExistingAkunSet = _context.ArAccts.Where(x => x.ArAcctId == codeview.ArAcctId).FirstOrDefault();
                if (ExistingAkunSet != null)
                {
                    _context.ArAccts.Remove(ExistingAkunSet);
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
        #endregion ArAcct Class

        #region ArDist Class

        public async Task<List<ArDist>> GetDist()
        {
            return await _context.ArDists.ToListAsync();
        }



        public async Task<bool> AddDist(ArDistView codeview)
        {
            string test = codeview.DistCode.ToUpper();
            var cekFirst = _context.ArDists.Where(x => x.DistCode == test).ToList();
            if (cekFirst.Count == 0)
            {
                ArDist AcctCode = new ArDist()
                {
                    DistCode = codeview.DistCode.ToUpper(),
                    Description = codeview.Description,
                    Dist1 = codeview.Dist1

                };
                _context.ArDists.Add(AcctCode);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {

                return false;
            }


        }

        public async Task<bool> EditDist(ArDistView codeview)
        {
            try
            {
                var ExistingDist = _context.ArDists.Where(x => x.ArDistId == codeview.ArDistId).FirstOrDefault();
                if (ExistingDist != null)
                {           
                    ExistingDist.Description = codeview.Description;
                    ExistingDist.Dist1 = codeview.Dist1;
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

        public async Task<bool> DelDist(ArDistView codeview)
        {
            try
            {
                var ExistingDist = _context.ArDists.Where(x => x.ArDistId == codeview.ArDistId).FirstOrDefault();
                if (ExistingDist != null)
                {
                    _context.ArDists.Remove(ExistingDist);
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
        #endregion ArDist Class
    }
}
