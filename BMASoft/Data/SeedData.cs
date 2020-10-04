using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace BMASoft.Data
{

    public class JnsBrng
    {
        public string NamaJenis { get; set; }
    }

    public class SatuanBarang
    {
        public string NamaSatuan { get; set; }
    }

    public class SeedDataService
    {
                      
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
    }

}




