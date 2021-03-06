﻿using BMASoft.Data;
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
        IcItem GetIcItemId(int itemKode);
        IcItem GetIcItemProduk(string produk);
        Task<bool> DelIcItem(int codeview);
        Task<bool> AddIcItem(IcItemView produk);
        Task<bool> EditIcItem(IcItemView produk);
        Task<List<IcDiv>> GetIcDiv();
        IcDiv GetIcDivId(int id);
        Task<bool> AddIcDiv(IcDivView codeview);
        Task<bool> EditIcDiv(IcDivView codeview);
        Task<bool> DelIcDiv(int codeview);
        Task<List<IcLokasi>> GetIcLokasi();
        IcLokasi GetIcLokasiId(int id);
        Task<bool> AddIcLokasi(IcLokasiView codeview);
        Task<bool> EditIcLokasi(IcLokasiView codeview);
        Task<bool> DelIcLokasi(int codeview);
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
        IcTransH GetIcTrans(int id);
        Task<List<IcTransH>> GetTransH();
        Task<List<IcTransH>> Get3TransH();
        Task<List<IcTransD>> GetTransD();
        Task<bool> AddTransH(IcTransHView codeview);
        Task<bool> EditTransH(IcTransHView codeview);
        Task<bool> DelTransH(int codeview);
    }

    public class InventoryService : IInventoryService
    {
        private readonly BmaDbContext _context;

        public InventoryService(BmaDbContext context)
        {
            _context = context;
        }

        #region icItem class

        public async Task<List<IcItem>> GetIcItem()
        {
            return await _context.IcItems.OrderBy(x => x.NamaItem).ToListAsync();
        }
        
        public IcItem GetIcItemId(int itemKode)
        {
            return _context.IcItems.Where(x => x.IcItemId == itemKode).FirstOrDefault();
        }

        public IcItem GetIcItemProduk(string itemKode)
        {
            return _context.IcItems.Where(x => x.ItemCode == itemKode).FirstOrDefault();
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
                    Divisi = produk.Divisi,
                    JnsBrng = produk.JnsBrng,
                    CostMethod = produk.CostMethod,
                    AcctSet = produk.AcctSet,
                    Category = produk.Category,
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
                    ExistingItem.Divisi = produk.Divisi;
                    ExistingItem.JnsBrng = produk.JnsBrng;
                    ExistingItem.CostMethod = produk.CostMethod;
                    ExistingItem.AcctSet = produk.AcctSet;
                    ExistingItem.Category = produk.Category;
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
        #endregion icitem class

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

        #region IcLokasi Class

        public async Task<List<IcLokasi>> GetIcLokasi()
        {
            return await _context.Iclokasis.OrderBy(x => x.Lokasi).ToListAsync();
        }

        public IcLokasi GetIcLokasiId(int id)
        {
            return _context.Iclokasis.Where(x => x.IcLokasiId == id).FirstOrDefault();
        }

        public async Task<bool> AddIcLokasi(IcLokasiView codeview)
        {
            string test = codeview.Lokasi.ToUpper();
            var cekFirst = _context.Iclokasis.Where(x => x.Lokasi == test).ToList();
            if (cekFirst.Count == 0)
            {
                IcLokasi Location = new IcLokasi()
                {
                    Lokasi = codeview.Lokasi.ToUpper(),
                    NamaLokasi = codeview.NamaLokasi

                };
                _context.Iclokasis.Add(Location);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {

                return false;
            }

        }

        public async Task<bool> EditIcLokasi(IcLokasiView codeview)
        {
            try
            {
                var ExistingDiv = _context.Iclokasis.Where(x => x.IcLokasiId == codeview.IcLokasiId).FirstOrDefault();
                if (ExistingDiv != null)
                {
                    ExistingDiv.NamaLokasi = codeview.NamaLokasi;


                    _context.Iclokasis.Update(ExistingDiv);
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

        public async Task<bool> DelIcLokasi(int codeview)
        {
            try
            {
                var ExistingDiv = _context.Iclokasis.Where(x => x.IcLokasiId == codeview).FirstOrDefault();
                if (ExistingDiv != null)
                {
                    _context.Iclokasis.Remove(ExistingDiv);
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

        #endregion IcLokasi Class

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

        #region Transaksi Mutasi Class

       

        public IcTransH GetIcTrans(int id)
        {
            return _context.IcTransHs.Include(p => p.IcTransDs).Where(x => x.IcTransHId == id).FirstOrDefault();
        }


        public async Task<List<IcTransH>> GetTransH()
        {
            List<IcTransH> IcTrans = new List<IcTransH>();
            try
            {
                IcTrans = await _context.IcTransHs.OrderByDescending(x => x.Tanggal).Where(x => x.Kode == "90").ToListAsync();

            }
            catch (Exception e)
            {
                throw e;
            }
            return IcTrans;
            // return  _context.CbTransHs.Include(p =>p.CbTransDs).OrderByDescending(x =>x.Tanggal).ToListAsync();
            //  return await _context.ApTransHs.OrderByDescending(x => x.Tanggal).ToListAsync();
            //  return await _context.ApTransHs.ToListAsync();

        }

        public async Task<List<IcTransH>> Get3TransH()
        {
            List<IcTransH> IcTrans = new List<IcTransH>();

            IcTrans = await _context.IcTransHs.OrderByDescending(x => x.Tanggal).Where(x => x.Tanggal > DateTime.Today.AddMonths(-3) && x.Kode == "90").ToListAsync();


            return IcTrans;

            // return  _context.CbTransHs.Include(p =>p.CbTransDs).OrderByDescending(x =>x.Tanggal).ToListAsync();
            //   return _context.ApTransHs.OrderByDescending(x => x.Tanggal).Where(x => x.Tanggal > DateTime.Today.AddMonths(-3)).ToListAsync();

        }

        public async Task<List<IcTransD>> GetTransD()
        {
            return await _context.IcTransDs.ToListAsync();
        }

        public async Task<bool> AddTransH(IcTransHView trans)
        {
            //string test = codeview.SrcCode.ToUpper();
            //var cekFirst = _context.CbSrcCodes.Where(x => x.SrcCode == test).ToList();

            IcTransH transH = new IcTransH
            {
                NoFaktur = GetNumber(),
                Tanggal = trans.Tanggal,
                Keterangan = trans.Keterangan,
                Lokasi = trans.Lokasi,
                Lokasi2 = trans.Lokasi2,
                Kode = "90",
                IcTransDs = new List<IcTransD>()
            };
            foreach (var item in trans.IcTransDs)
            {
                transH.IcTransDs.Add(new IcTransD()
                {
                    ItemCode = item.ItemCode,
                    NamaItem = item.NamaItem,
                    QtyShp = item.QtyShp,
                    Kode = "90",
                    Lokasi = item.Lokasi,
                    Lokasi2 = item.Lokasi2,
                    NoFaktur = transH.NoFaktur,
                    Tanggal = trans.Tanggal
                });

                IcItem cekItem = _context.IcItems.Where(x => x.ItemCode == item.ItemCode).FirstOrDefault();
                if (cekItem != null)
                {
                    IcAltItem cekLokasi1 = _context.IcAltItems.Where(x => x.ItemCode == item.ItemCode && x.Lokasi == item.Lokasi).FirstOrDefault();
                    if (cekLokasi1 == null)
                    {
                        IcAltItem Produk = new IcAltItem()
                        {
                            ItemCode = cekItem.ItemCode.ToUpper(),
                            NamaItem = cekItem.NamaItem,
                            Satuan = cekItem.Satuan,
                            Lokasi = item.Lokasi,
                            Qty = -1 * item.QtyShp
                        };
                        _context.IcAltItems.Add(Produk);

                    }
                    else
                    {
                        cekLokasi1.Qty -= item.QtyShp;
                        _context.IcAltItems.Update(cekLokasi1);
                    }

                    /** lokasi 2 **/
                    IcAltItem cekLokasi2 = _context.IcAltItems.Where(x => x.ItemCode == item.ItemCode && x.Lokasi == item.Lokasi2).FirstOrDefault();
                    if (cekLokasi2 == null)
                    {
                        IcAltItem Produk = new IcAltItem()
                        {
                            ItemCode = cekItem.ItemCode.ToUpper(),
                            NamaItem = cekItem.NamaItem,
                            Satuan = cekItem.Satuan,
                            Lokasi = item.Lokasi2,
                            Qty = item.QtyShp
                        };
                        _context.IcAltItems.Add(Produk);

                    }
                    else
                    {
                        cekLokasi2.Qty += item.QtyShp;
                        _context.IcAltItems.Update(cekLokasi2);
                    }

                }

            }

            _context.IcTransHs.Add(transH);

            await _context.SaveChangesAsync();
            return true;


        }

        public async Task<bool> EditTransH(IcTransHView trans)
        {
          
            var ExistingTrans = _context.IcTransHs.Where(x => x.IcTransHId == trans.IcTransHId).FirstOrDefault();

            /* transaksi lama dikurangi */

            if (ExistingTrans != null)
            {
                foreach (var item in ExistingTrans.IcTransDs)
                {
                    IcItem cekItem = _context.IcItems.Where(x => x.ItemCode == item.ItemCode).FirstOrDefault();
                    if (cekItem != null)
                    {
                        IcAltItem itemlokasi1 = _context.IcAltItems.Where(x => x.ItemCode == item.ItemCode && x.Lokasi == item.Lokasi).FirstOrDefault();
                        if (itemlokasi1 != null)
                        {
                            itemlokasi1.Qty += item.QtyShp;
                            _context.IcAltItems.Update(itemlokasi1);
                        }


                        IcAltItem itemlokasi2 = _context.IcAltItems.Where(x => x.ItemCode == item.ItemCode && x.Lokasi == item.Lokasi2).FirstOrDefault();
                        if (itemlokasi2 != null)
                        {
                            itemlokasi2.Qty -= item.QtyShp;
                            _context.IcAltItems.Update(itemlokasi2);
                        }



                    }
                    _context.IcTransHs.Remove(ExistingTrans);
                }
            }

            /* transaksi update */

            IcTransH transH = new IcTransH
            {
                NoFaktur = ExistingTrans.NoFaktur,
                Tanggal = trans.Tanggal,
                Keterangan = trans.Keterangan,
                Lokasi = trans.Lokasi,
                Lokasi2 = trans.Lokasi2,
                Kode = "90",
                IcTransDs = new List<IcTransD>()
            };
            foreach (var item in trans.IcTransDs)
            {
                transH.IcTransDs.Add(new IcTransD()
                {
                    ItemCode = item.ItemCode,
                    NamaItem = item.NamaItem,
                    QtyShp = item.QtyShp,
                    Kode = "90",
                    Lokasi = transH.Lokasi,
                    Lokasi2 = transH.Lokasi2,
                    NoFaktur = transH.NoFaktur,
                    Tanggal = trans.Tanggal
                });

                IcItem cekItem = _context.IcItems.Where(x => x.ItemCode == item.ItemCode).FirstOrDefault();
                if (cekItem != null)
                {
                    IcAltItem cekLokasi1 = _context.IcAltItems.Where(x => x.ItemCode == item.ItemCode && x.Lokasi == transH.Lokasi).FirstOrDefault();
                    if (cekLokasi1 == null)
                    {
                        IcAltItem Produk = new IcAltItem()
                        {
                            ItemCode = cekItem.ItemCode.ToUpper(),
                            NamaItem = cekItem.NamaItem,
                            Satuan = cekItem.Satuan,
                            Lokasi = transH.Lokasi,
                            Qty = -1 * item.QtyShp
                        };
                        _context.IcAltItems.Add(Produk);

                    }
                    else
                    {
                        cekLokasi1.Qty -= item.QtyShp;
                        _context.IcAltItems.Update(cekLokasi1);
                    }

                    /** lokasi 2 **/
                    IcAltItem cekLokasi2 = _context.IcAltItems.Where(x => x.ItemCode == item.ItemCode && x.Lokasi == transH.Lokasi2).FirstOrDefault();
                    if (cekLokasi2 == null)
                    {
                        IcAltItem Produk = new IcAltItem()
                        {
                            ItemCode = cekItem.ItemCode.ToUpper(),
                            NamaItem = cekItem.NamaItem,
                            Satuan = cekItem.Satuan,
                            Lokasi = transH.Lokasi2,
                            Qty = item.QtyShp
                        };
                        _context.IcAltItems.Add(Produk);

                    }
                    else
                    {
                        cekLokasi2.Qty += item.QtyShp;
                        _context.IcAltItems.Update(cekLokasi2);
                    }

                }

            }

            _context.IcTransHs.Add(transH);

            await _context.SaveChangesAsync();

            return true;


        }

        public async Task<bool> DelTransH(int id)
        {
            try
            {
                var ExistingTrans = _context.IcTransHs.Where(x => x.IcTransHId == id).FirstOrDefault();

                if (ExistingTrans != null)
                {
                    foreach (var item in ExistingTrans.IcTransDs)
                    {
                        IcAltItem itemlokasi1 = _context.IcAltItems.Where(x => x.ItemCode == item.ItemCode && x.Lokasi == item.Lokasi).FirstOrDefault();
                        itemlokasi1.Qty += item.QtyShp;

                        IcAltItem itemlokasi2 = _context.IcAltItems.Where(x => x.ItemCode == item.ItemCode && x.Lokasi == item.Lokasi2).FirstOrDefault();
                        itemlokasi2.Qty -= item.QtyShp;

                        _context.IcAltItems.Update(itemlokasi1);
                    }
                    _context.IcTransHs.Remove(ExistingTrans);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return false;

        }

        #endregion Transaksi Mutasi Class



        public string GetNumber()
        {
            string kodeno = "MUT";
            string kodeurut = kodeno + '-';
            string thnbln = DateTime.Now.ToString("yyMM");
            string xbukti = kodeurut + thnbln.Substring(0, 2) + '2' + thnbln.Substring(2, 2) + '-';
            var maxvalue = "";
            var maxlist = _context.IcTransHs.Where(x => x.NoFaktur.Substring(0, 10).Equals(xbukti)).ToList();
            if (maxlist != null)
            {
                maxvalue = maxlist.Max(x => x.NoFaktur);

            }

            //            var maxvalue = (from e in db.CbTransHs where  e.Docno.Substring(0, 7) == kodeno + thnbln select e).Max();
            string nourut = "00000";
            if (maxvalue == null)
            {
                nourut = "00000";
            }
            else
            {
                nourut = maxvalue.Substring(10, 5);
            }

            //  nourut =Convert.ToString(Int32.Parse(nourut) + 1);


            string cAngNo = xbukti + (Int32.Parse(nourut) + 1).ToString("00000");
            // var maxvalue = (from e in db.AptTranss where e.NoRef.Substring(0, 7) == "ANG" + cAngNo select e.NoRef.Max()).FirstOrDefault();
            return cAngNo;

        }
    }
}
