using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramFakturMUA
{
    class Kota
    {
        Db db = new Db();
         
        public string getNamaKota(string id)
        {
            db.bind("id", id);
            string var = db.single("select nama_kota from kota where kota_id = @id");
            return var;
        }
    }
}
