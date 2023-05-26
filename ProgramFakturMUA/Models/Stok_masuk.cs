using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramFakturMUA
{
    class Stok_masuk
    {
        Db db = new Db();
        Functions fungsi = new Functions();

        public string getIDBarangFromStokMasukID(string stok_masuk_id)
        {
            db.bind("id", stok_masuk_id);
            string var = db.single("select barang_id from stok_masuk where stok_masuk_id = @id");
            return var;
        }

        public string getStok(string stok_masuk_id)
        {
            db.bind("id", stok_masuk_id);
            string var = db.single("select sisa from stok_masuk where stok_masuk_id = @id");
            return var;
        }

        

        public void insert(string tanggal, string barang_id, string detail_id, string qty)
        {

            string sql = "insert into stok_masuk (tanggal, barang_id, jenis, tabel_id, qty, sisa) values ("+
            "@tanggal, @barang_id, @jenis, @tabel_id, @qty, @sisa)";

            db.bind("tanggal", tanggal);
            db.bind("barang_id", barang_id);
            db.bind("jenis", "beli");
            db.bind("tabel_id", detail_id);
            db.bind("qty", qty);
            db.bind("sisa", qty);
            db.nQuery(sql);
        }

        public void hapusByTabelID(string tabel_id)
        {
            db.bind("tabel_id", tabel_id);

            db.nQuery("delete from stok_masuk where tabel_id = @tabel_id and jenis = 'beli'");
        }

        public void tambahkanStok(string stok_masuk_id, string qty)
        {
            db.bind("stok_masuk_id", stok_masuk_id);
            db.bind("qty", qty);

            db.nQuery("update stok_masuk set sisa = sisa + @qty where stok_masuk_id = @stok_masuk_id ");
        }

        public void kurangiStok(string stok_masuk_id, string qty)
        {
            db.bind("stok_masuk_id", stok_masuk_id);
            db.bind("qty", qty);

            db.nQuery("update stok_masuk set sisa = sisa - @qty where stok_masuk_id = @stok_masuk_id ");
        }

        public void kurangiStok(string stok_id, string barang_id, string qty)
        {
            db.bind("stok_id", stok_id);
            db.bind("qty", qty);
            db.bind("barang_id", barang_id);

            int i = db.nQuery("update stok_masuk set sisa = sisa - @qty where tabel_id = @stok_id and barang_id = @barang_id and sisa >= 0");
            //fungsi.showError(stok_id.ToString());
        }

        public void updateStok(string stok_id, string barang_id, string qty)
        {
            db.bind("stok_id", stok_id);
            db.bind("qty", qty);
            db.bind("barang_id", barang_id);

            db.nQuery("update stok_masuk set sisa =  sisa + @qty where tabel_id = @stok_id and barang_id = @barang_id and sisa >= 0 ");
        }

    }
}
