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

    public interface IInventoryService
    {
        Task<List<IcItem>> GetIcItem();
        Task<bool> DelIcItem(int codeview);
        Task<bool> AddIcItem(IcItemView produk);
        Task<bool> EditIcItem(IcItemView produk);
        Task<List<IcDiv>> GetIcDiv();
        IcDiv GetIcDivId(int id);
        Task<bool> AddIcDiv(IcDivView codeview);
        Task<bool> EditIcDiv(IcDivView codeview);
        Task<bool> DelIcDiv(int codeview);
        Task<List<IcCat>> GetIcCat();
        IcCat GetIcCatId(int id);
        Task<bool> AddIcCat(IcCatView codeview);
        Task<bool> EditIcCat(IcCatView codeview);
        Task<bool> DelIcCat(int codeview);
        Task<List<IcAcct>> GetIcAcct();
        IcAcct GetIcAcctId(int id);
        Task<bool> AddIcAcct(IcAcctView codeview);
        Task<bool> EditIcAcct(IcAcctView codeview);
        Task<bool> DelIcAcct(int codeview);
    }

    public class InventoryService : IInventoryService
    {
        private readonly BmaDbContext _context;

        public InventoryService(BmaDbContext context)
        {
            _context = context;
        }

        public async Task<List<IcItem>> GetIcItem()
        {
            return await _context.IcItems.OrderBy(x => x.NamaItem).ToListAsync();
        }

        public async Task<bool> DelIcItem(int codeview)
        {
            try
            {
                var ExistingDist = _context.IcItems.Where(x => x.IcItemId == codeview).FirstOrDefault();
                if (ExistingDist != null)
                {
                    _context.IcItems.Remove(ExistingDist);
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

        public async Task<bool> AddIcItem(IcItemView produk)
        {
            string test = produk.ItemCode.ToUpper();
            var cekFirst = _context.IcItems.Where(x => x.ItemCode == test).ToList();
            if (cekFirst.Count == 0)
            {
                IcItem Produk = new IcItem()
                {
                    ItemCode = produk.ItemCode.ToUpper(),
                    NamaItem = produk.NamaItem,
                    Satuan = produk.Satuan,
                    NamaLengkap = produk.NamaLengkap

                };
                _context.IcItems.Add(Produk);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {

                return false;
            }

        }

        public async Task<bool> EditIcItem(IcItemView produk)
        {
            try
            {
                var ExistingItem = _context.IcItems.Where(x => x.IcItemId == produk.IcItemId).FirstOrDefault();
                if (ExistingItem != null)
                {
                    ExistingItem.NamaItem = produk.NamaItem;
                    ExistingItem.Satuan = produk.Satuan;
                    ExistingItem.NamaLengkap = produk.NamaLengkap;
                    _context.IcItems.Update(ExistingItem);
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

        #region IcDiv Class

        public async Task<List<IcDiv>> GetIcDiv()
        {
            return await _context.IcDivs.OrderBy(x => x.Divisi).ToListAsync();
        }

        public IcDiv GetIcDivId(int id)
        {
            return _context.IcDivs.Where(x => x.IcDivId == id).FirstOrDefault();
        }

        public async Task<bool> AddIcDiv(IcDivView codeview)
        {
            string test = codeview.Divisi.ToUpper();
            var cekFirst = _context.IcDivs.Where(x => x.Divisi == test).ToList();
            if (cekFirst.Count == 0)
            {
                IcDiv Division = new IcDiv()
                {
                    Divisi = codeview.Divisi.ToUpper(),
                    NamaDiv = codeview.NamaDiv

                };
                _context.IcDivs.Add(Division);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {

                return false;
            }

        }

        public async Task<bool> EditIcDiv(IcDivView codeview)
        {
            try
            {
                var ExistingDiv = _context.IcDivs.Where(x => x.IcDivId == codeview.IcDivId).FirstOrDefault();
                if (ExistingDiv != null)
                {
                    ExistingDiv.NamaDiv = codeview.NamaDiv;
                  

                    _context.IcDivs.Update(ExistingDiv);
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

        public async Task<bool> DelIcDiv(int codeview)
        {
            try
            {
                var ExistingDiv = _context.IcDivs.Where(x => x.IcDivId == codeview).FirstOrDefault();
                if (ExistingDiv != null)
                {
                    _context.IcDivs.Remove(ExistingDiv);
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

        #endregion IcDiv Class

        #region IcCat Class

        public async Task<List<IcCat>> GetIcCat()
        {
            return await _context.IcCats.ToListAsync();
        }

        public IcCat GetIcCatId(int id)
        {
            return _context.IcCats.Where(x => x.IcCatId == id).FirstOrDefault();
        }

        public async Task<bool> AddIcCat(IcCatView codeview)
        {
            string test = codeview.CatCode.ToUpper();
            var cekFirst = _context.IcCats.Where(x => x.CatCode == test).ToList();
            if (cekFirst.Count == 0)
            {
                IcCat AcctCode = new IcCat()
                {
                    CatCode = codeview.CatCode.ToUpper(),
                    Description = codeview.Description,
                    Cat1 = codeview.Cat1,
                    Cat2 = codeview.Cat2,
                    Cat3 = codeview.Cat3,
                    Cat4 = codeview.Cat4

                };
                _context.IcCats.Add(AcctCode);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {

                return false;
            }


        }

        public async Task<bool> EditIcCat(IcCatView codeview)
        {
            try
            {
                var ExistingIcCat = _context.IcCats.Where(x => x.IcCatId == codeview.IcCatId).FirstOrDefault();
                if (ExistingIcCat != null)
                {
                    ExistingIcCat.Description = codeview.Description;
                    ExistingIcCat.Cat1 = codeview.Cat1;
                    ExistingIcCat.Cat2 = codeview.Cat2;
                    ExistingIcCat.Cat3 = codeview.Cat3;
                    ExistingIcCat.Cat4 = codeview.Cat4;
                    ExistingIcCat.Cat5 = codeview.Cat5;

                    _context.IcCats.Update(ExistingIcCat);
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

        public async Task<bool> DelIcCat(int codeview)
        {
            try
            {
                var ExistingIcCat = _context.IcCats.Where(x => x.IcCatId == codeview).FirstOrDefault();
                if (ExistingIcCat != null)
                {
                    _context.IcCats.Remove(ExistingIcCat);
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
        #endregion IcCat Class

        #region IcAcct Class

        public async Task<List<IcAcct>> GetIcAcct()
        {
            return await _context.IcAccts.ToListAsync();
        }

        public IcAcct GetIcAcctId(int id)
        {
            return _context.IcAccts.Where(x => x.IcAcctId == id).FirstOrDefault();
        }

        public async Task<bool> AddIcAcct(IcAcctView codeview)
        {
            string test = codeview.AcctSet.ToUpper();
            var cekFirst = _context.IcAccts.Where(x => x.AcctSet == test).ToList();
            if (cekFirst.Count == 0)
            {
                IcAcct AcctCode = new IcAcct()
                {
                    AcctSet = codeview.AcctSet.ToUpper(),
                    Description = codeview.Description,
                    Acct1 = codeview.Acct1,
                    Acct2 = codeview.Acct2,
                    Acct3 = codeview.Acct3,
                    Acct4 = codeview.Acct4

                };
                _context.IcAccts.Add(AcctCode);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {

                return false;
            }


        }

        public async Task<bool> EditIcAcct(IcAcctView codeview)
        {
            try
            {
                var ExistingIcAcct = _context.IcAccts.Where(x => x.IcAcctId == codeview.IcAcctId).FirstOrDefault();
                if (ExistingIcAcct != null)
                {
                    ExistingIcAcct.Description = codeview.Description;
                    ExistingIcAcct.Acct1 = codeview.Acct1;
                    ExistingIcAcct.Acct2 = codeview.Acct2;
                    ExistingIcAcct.Acct3 = codeview.Acct3;
                    ExistingIcAcct.Acct4 = codeview.Acct4;
                    ExistingIcAcct.Acct5 = codeview.Acct5;

                    _context.IcAccts.Update(ExistingIcAcct);
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

        public async Task<bool> DelIcAcct(int codeview)
        {
            try
            {
                var ExistingIcAcct = _context.IcAccts.Where(x => x.IcAcctId == codeview).FirstOrDefault();
                if (ExistingIcAcct != null)
                {
                    _context.IcAccts.Remove(ExistingIcAcct);
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
        #endregion IcAcct Class
    }
}
