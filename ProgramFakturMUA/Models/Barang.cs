using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramFakturMUA
{
    class Barang
    {
        Db db = new Db();

        public string getIDBarangFromStokMasukID(string stok_masuk_id)
        {
            db.bind("id", stok_masuk_id);
            string var = db.single("select barang_id from stok_masuk where stok_masuk_id = @id");
            return var;
        }

        public string getNamaBarangFromIDBarang(string barang_id)
        {
            db.bind("id", barang_id);
            string var = db.single("select nama_barang from barang where barang_id = @id");
            return var;
        }

        public string getIDPabrikFromBarangID(string barang_id)
        {
            db.bind("id", barang_id);
            string var = db.single("select pabrik_id from barang where barang_id = @id");
            return var;
        }

        public string getIDSatuanFromBarangID(string barang_id)
        {
            db.bind("id", barang_id);
            string var = db.single("select satuan_id from barang where barang_id = @id");
            return var;
        }
        public string getIDPabrikFromIDBarang(string barang_id)
        {
            db.bind("id", barang_id);
            string var = db.single("select pabrik_id from barang where barang_id = @id");
            return var;
        }

        public DataTable getData(string txt)
        {
            db.bind("nama", "%"+txt+"%");
            return db.query("select barang_id, kode, nama_barang, satuan.nama_satuan, pabrik.nama_pabrik, harga_jual, pricelist "+
                "from barang "+
                "left join satuan on satuan.satuan_id = barang.satuan_id "+
                "left join pabrik on pabrik.pabrik_id = barang.pabrik_id "+
                "where nama_barang like @nama");
        }

        public void insert(string nama, string kode, string satuan_id, string pabrik_id, string harga, string pricelist)
        {
            db.bind("nama_barang", nama);
            db.bind("kode", kode);
            db.bind("satuan_id", satuan_id);
            db.bind("pabrik_id", pabrik_id);
            db.bind("harga", harga);
            db.bind("pricelist", pricelist);
            db.nQuery("insert into barang (kode, nama_barang, satuan_id, pabrik_id, harga_jual, pricelist) values ("+
                "@kode, @nama_barang, @satuan_id, @pabrik_id, @harga, @pricelist)");
        }

        public void update(string nama, string kode, string satuan_id, string pabrik_id, string harga, string pricelist, string id_edit)
        {
            db.bind("nama_barang", nama);
            db.bind("kode", kode);
            db.bind("satuan_id", satuan_id);
            db.bind("pabrik_id", pabrik_id);
            db.bind("harga", harga);
            db.bind("pricelist", pricelist);
            db.bind("barang_id", id_edit);
            db.nQuery("update barang " +
                "set nama_barang = @nama_barang, kode = @kode, satuan_id = @satuan_id, pabrik_id = @pabrik_id, harga_jual = @harga, pricelist = @pricelist where barang_id = @barang_id");
        }
    }
}
