﻿using BMASoft.Data;
using BMASoft.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMASoft.Services
{
    public interface IKasBankService
    {
        Task<List<CbBank>> GetBank();
        Task<bool> AddBank(BankView banks);
        Task<bool> EditBank(BankView banks);
        Task<bool> DelBank(BankView banks);
        Task<List<CbSrcCode>> GetSrcCode();
        Task<bool> AddSrcCode(SrcCodeView codeview);
        Task<bool> EditSrcCode(SrcCodeView codeview);
        Task<bool> DelSrcCode(SrcCodeView codeview);
        Task<List<CbTransH>> GetTransH();
        Task<bool> AddTransH(TranshView transH);
    }

    public class KasBankService : IKasBankService
    {
        private readonly BmaDbContext _context;

        public KasBankService(BmaDbContext context)
        {
            _context = context;
        }

        #region Bank Class

        public async Task<List<CbBank>> GetBank()
        {
            return await _context.Banks.ToListAsync();
        }

        public async Task<bool> AddBank(BankView banks)
        {
            string test = banks.kdbank.ToUpper();
            var cekFirst = _context.Banks.Where(x => x.KodeBank == test).ToList();
            if (cekFirst.Count == 0)
            {
                CbBank Bank = new CbBank()
                {
                    KodeBank = banks.kdbank.ToUpper(),
                    NmBank = banks.namabank,
                    Kurs = banks.kurs,
                    ClrDate = DateTime.Today
                };
                _context.Banks.Add(Bank);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                
                return false;
            }
           
        }

        public async Task<bool> EditBank(BankView banks)
        {
            try
            {
                var ExistingBank = _context.Banks.Where(x => x.CbBankId == banks.bankId).FirstOrDefault();
                if (ExistingBank != null)
                {
                    ExistingBank.NmBank = banks.namabank;
                    ExistingBank.Kurs = banks.kurs;
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

        public async Task<bool> DelBank(BankView banks)
        {
            try
            {
                var ExistingBank = _context.Banks.Where(x => x.CbBankId == banks.bankId).FirstOrDefault();
                if (ExistingBank != null)
                {
                    _context.Banks.Remove(ExistingBank);
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
        #endregion Bank Class

        #region SrcCode Class

        public async Task<List<CbSrcCode>> GetSrcCode()
        {
            return await _context.CbSrcCodes.ToListAsync();
        }

        public async Task<bool> AddSrcCode(SrcCodeView codeview)
        {
            string test = codeview.SrcCode.ToUpper();
            var cekFirst = _context.CbSrcCodes.Where(x => x.SrcCode == test).ToList();
            if (cekFirst.Count == 0)
            {
                CbSrcCode BankCode = new CbSrcCode()
                {
                    SrcCode = codeview.SrcCode.ToUpper(),
                    NamaSrc = codeview.NamaSrc,
                    GlAcct = codeview.GlAcct
                   
                };
                _context.CbSrcCodes.Add(BankCode);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {

                return false;
            }


        }

        public async Task<bool> EditSrcCode(SrcCodeView codeview)
        {
            try
            {
                var ExistingSrcCode = _context.CbSrcCodes.Where(x => x.CbSrcCodeId == codeview.SrcCodeId).FirstOrDefault();
                if (ExistingSrcCode != null)
                {
                    ExistingSrcCode.NamaSrc = codeview.NamaSrc;
                    ExistingSrcCode.GlAcct = codeview.GlAcct;
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

        public async Task<bool> DelSrcCode(SrcCodeView codeview)
        {
            try
            {
                var ExistingSrcCode = _context.CbSrcCodes.Where(x => x.CbSrcCodeId == codeview.SrcCodeId).FirstOrDefault();
                if (ExistingSrcCode != null)
                {
                    _context.CbSrcCodes.Remove(ExistingSrcCode);
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
        #endregion srcode Class

        #region Transaksi Bank Class

        public async Task<List<CbTransH>> GetTransH()
        {
            return await _context.CbTransHs.Include(p =>p.CbTransDs).ToListAsync();
        }

        public async Task<bool> AddTransH(TranshView trans)
        {
            //string test = codeview.SrcCode.ToUpper();
            //var cekFirst = _context.CbSrcCodes.Where(x => x.SrcCode == test).ToList();
           
            CbTransH transH = new CbTransH
            {
                DocNo = "Test200101",
                KodeBank = trans.KodeBank.ToUpper(),
                Tanggal = trans.Tanggal,
                Keterangan = trans.Keterangan,
                Kurs = trans.Kurs,
                CbTransDs = new List<CbTransD>()
            };
            foreach (var item in trans.TransDs)
            {
                transH.CbTransDs.Add(new CbTransD()
                {
                    SrcCode = item.SrcCode,
                    Keterangan = item.Keterangan,
                    Terima = item.Terima,
                    Bayar = item.Bayar,
                    KTerima = item.KTerima,
                    KBayar = item.KBayar,
                    KValue = item.KValue,
                    Kurs = item.Kurs
                });
            }


            _context.CbTransHs.Add(transH);
            await _context.SaveChangesAsync();
            return true;


        }

        public async Task<bool> EditTransH(SrcCodeView codeview)
        {
            try
            {
                var ExistingSrcCode = _context.CbSrcCodes.Where(x => x.CbSrcCodeId == codeview.SrcCodeId).FirstOrDefault();
                if (ExistingSrcCode != null)
                {
                    ExistingSrcCode.NamaSrc = codeview.NamaSrc;
                    ExistingSrcCode.GlAcct = codeview.GlAcct;
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

        public async Task<bool> DelTransH(SrcCodeView codeview)
        {
            try
            {
                var ExistingSrcCode = _context.CbSrcCodes.Where(x => x.CbSrcCodeId == codeview.SrcCodeId).FirstOrDefault();
                if (ExistingSrcCode != null)
                {
                    _context.CbSrcCodes.Remove(ExistingSrcCode);
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

        #endregion Transaksi Bank Class
    }

}
