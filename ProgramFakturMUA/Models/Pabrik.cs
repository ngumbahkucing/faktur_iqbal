using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramFakturMUA
{
    class Pabrik
    {
        Db db = new Db();

        public string getNamaPabrikByID(string id)
        {
            db.bind("id", id);
            string var = db.single("select nama_pabrik from pabrik where pabrik_id = @id");
            return var;
        }

        public DataTable getData()
        {

            return db.query("select pabrik_id, nama_pabrik from pabrik order by nama_pabrik");

        }
    }
}
