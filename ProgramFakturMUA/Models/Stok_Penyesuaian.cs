using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramFakturMUA
{
    class Stok_Penyesuaian
    {
        Db db = new Db();

        public void insert(string tanggal, string stok_masuk_id, string qty, string status)
        {
            db.bind("tanggal", tanggal);
            db.bind("stok_masuk_id", stok_masuk_id);
            db.bind("qty", qty);
            db.bind("status", status);
            int var = db.nQuery("insert into stok_penyesuaian (tanggal, stok_masuk_id, qty, status) values (@tanggal, @stok_masuk_id, @qty, @status)");
            
        }
    }
}
