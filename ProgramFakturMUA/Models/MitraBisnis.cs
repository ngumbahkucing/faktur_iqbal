using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramFakturMUA
{
    class MitraBisnis
    {
        Db db = new Db();
         

        public string getMitraBisnis(string supplier_id, string kolom)
        {
            db.bind("supplier_id", supplier_id);
            db.bind("kolom", kolom);
            string var = db.single("select "+kolom+" from supplier where supplier_id = @supplier_id");
            return var;
        }
        public void updateKTP(string ktp, string supplier_id)
        {
            db.bind("ktp", ktp);
            db.bind("id", supplier_id);
            db.nQuery("update supplier set ktp = @ktp where supplier_id = @id");
        }

        public DataTable getData(string txt)
        {
            db.bind("nama", "%" + txt + "%");
            return db.query("select supplier_id, nama_supplier, alamat, kota.nama_kota, ktp, npwp " +
                "from supplier " +
                "left join kota on kota.kota_id = supplier.kota_id " +
                "where nama_supplier like @nama");
        }

        public void insert(string nama, string alamat, string kota_id, string ktp, string npwp)
        {
            db.bind("nama_supplier", nama);
            db.bind("alamat", alamat);
            db.bind("kota_id", kota_id);
            db.bind("ktp", ktp);
            db.bind("npwp", npwp);
            db.nQuery("insert into supplier (nama_supplier, alamat, kota_id, ktp, npwp) values (" +
                "@nama_supplier, @alamat, @kota_id, @ktp, @npwp)");
        }

        public void update(string nama, string alamat, string kota_id, string ktp, string npwp, string supplier_id)
        {
            db.bind("nama_supplier", nama);
            db.bind("alamat", alamat);
            db.bind("kota_id", kota_id);
            db.bind("ktp", ktp);
            db.bind("npwp", npwp);
            db.bind("supplier_id", supplier_id);
            db.nQuery("update supplier " +
                "set nama_supplier = @nama_supplier, alamat = @alamat, kota_id = @kota_id, ktp= @ktp, npwp=@npwp "+
                "where supplier_id = @supplier_id");
        }
    }
}
