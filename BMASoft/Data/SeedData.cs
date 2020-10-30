using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace BMASoft.Data
{
    public class TipeGl
    {
        public string NamaTipe { get; set; }
    }
    public class StatusTax
    {
        public string TaxStatus { get; set; }
    }

    public class JnsBrng
    {
        public string NamaJenis { get; set; }
    }

    public class SatuanBarang
    {
        public string NamaSatuan { get; set; }
    }

    public class CostingMethod
    {
        public string NamaMethod { get; set; }
    }

    public class SeedDataService
    {
        public Task<StatusTax[]> GetTax()
        {
            StatusTax[] pajak = new StatusTax[]
            {
                new StatusTax()
                {

                    TaxStatus = "Tax"
                },
                 new StatusTax()
                {

                    TaxStatus = "Non"
                },
                
            };

            return Task.FromResult(pajak);
        }


        public Task<JnsBrng[]> GetTipeProduk()
        {
            JnsBrng[] jnsBrngs = new JnsBrng[]
            {
                new JnsBrng()
                {

                    NamaJenis = "Stock"
                },
                 new JnsBrng()
                {

                    NamaJenis = "Service"
                },
                  new JnsBrng()
                {

                    NamaJenis = "Consumable"
                },
            };

            return Task.FromResult(jnsBrngs);
        }

        public Task<SatuanBarang[]> GetSatuan()
        {
            SatuanBarang[] satuans = new SatuanBarang[]
            {
                new SatuanBarang()
                {
                    NamaSatuan = "Pcs"
                },
                new SatuanBarang()
                {
                    NamaSatuan = "Set"
                },
                new SatuanBarang()
                {
                    NamaSatuan = "Unit"
                },
                new SatuanBarang()
                {
                    NamaSatuan = "Mtr"
                },
                new SatuanBarang()
                {
                    NamaSatuan = "Roll"
                },
            };
            return Task.FromResult(satuans);
        }

        public Task<CostingMethod[]> GetCosting()
        {
            CostingMethod[] jnsMethod = new CostingMethod[]
            {
                new CostingMethod()
                {

                    NamaMethod = "Moving Avarage"
                },
                new CostingMethod()
                {

                    NamaMethod = "Standard Cost"
                },

            };

            return Task.FromResult(jnsMethod);
        }

        public Task<TipeGl[]> GetTipeGl()
        {
            TipeGl[] jnsTipe = new TipeGl[]
            {
                new TipeGl()
                {

                    NamaTipe = "Balance Sheet"
                },
                 new TipeGl()
                {

                    NamaTipe = "Profit/Loss"
                },
                  new TipeGl()
                {

                    NamaTipe = "Retained Earning"
                },
            };

            return Task.FromResult(jnsTipe);
        }
    }
}




