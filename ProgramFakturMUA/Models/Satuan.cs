using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramFakturMUA
{
    class Satuan
    {
        Db db = new Db();

        public string getNamaSatuanByID(string id)
        {
            db.bind("id", id);
            string var = db.single("select nama_satuan from satuan where satuan_id = @id");
            return var;
        }

        public DataTable getData()
        {
             
            return db.query("select satuan_id, nama_satuan from satuan order by nama_satuan");
            
        }
    }
}
