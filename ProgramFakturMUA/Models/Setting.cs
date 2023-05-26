using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramFakturMUA
{
    class Setting
    {
        Db db = new Db();

        public string getSetting(string nama)
        {
            db.bind("id", nama);
            string var = db.single("select isi from settings where nama = @id");
            return var;
        }

        public void setSetting(string nama, string val)
        {
            db.bind("nama", nama);
            db.bind("val", val);

            db.nQuery("update settings set isi = @val where nama = @nama");
            
        }
    }
}
