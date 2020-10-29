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

namespace BMASoft.Services
{
    public interface ILedgerService
    {
        Task<List<GlAccount>> GetGlAccount();
        GlAccount GetGlAccountId(int id);
        Task<bool> AddGlAccount(GlAccountView glakun);
        Task<bool> EditGlAccount(GlAccountView glakun);
        Task<bool> DelGlAccount(int glakun);
    }

        public class LedgerService : ILedgerService
    {

        private readonly BmaDbContext _context;

        public LedgerService(BmaDbContext context)
        {
            _context = context;
        }

        public async Task<List<GlAccount>> GetGlAccount()
        {
            return await _context.GlAccounts.OrderBy(x => x.GlAcct).ToListAsync();
        }

        public GlAccount GetGlAccountId(int id)
        {
            return  _context.GlAccounts.OrderBy(x => x.GlAccountId == id).FirstOrDefault();
        }

        public async Task<bool> AddGlAccount(GlAccountView glakun)
        {
            string test = glakun.GlAcct.ToUpper();
            var cekFirst = _context.GlAccounts.Where(x => x.GlAcct == test).ToList();
            if (cekFirst.Count == 0)
            {
                GlAccount Akun = new GlAccount()
                {
                    GlAcct = glakun.GlAcct.ToUpper(),
                    GlNama = glakun.GlNama,
                    GlTipe = glakun.GlTipe,
                    NamaLengkap = glakun.NamaLengkap
                   

                };
                _context.GlAccounts.Add(Akun);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {

                return false;
            }

        }

        public async Task<bool> EditGlAccount(GlAccountView glakun)
        {
            try
            {
                var ExistingBank = _context.GlAccounts.Where(x => x.GlAccountId == glakun.GlAccountId).FirstOrDefault();
                if (ExistingBank != null)
                {
                    ExistingBank.GlNama = glakun.GlNama;
                    ExistingBank.GlTipe = glakun.GlTipe;
                    ExistingBank.NamaLengkap = glakun.NamaLengkap;
                   
                    _context.GlAccounts.Update(ExistingBank);
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

        public async Task<bool> DelGlAccount(int banks)
        {
            try
            {
                var ExistingBank = _context.GlAccounts.Where(x => x.GlAccountId == banks).FirstOrDefault();
                if (ExistingBank != null)
                {
                    _context.GlAccounts.Remove(ExistingBank);
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
