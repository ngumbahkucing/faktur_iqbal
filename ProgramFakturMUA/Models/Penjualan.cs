using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramFakturMUA
{
    class Penjualan
    {
        Db db = new Db();
        Stok_masuk stok_masuk = new Stok_masuk();

        public string getLatestIDPenjualan()
        {
            string var = db.single("select jual_id from penjualan order by jual_id desc limit 1");
            return var;
        }

        public void hapusPenjualan(string jual_id)
        {
            // hapus detail 
            db.bind("id", jual_id);
            DataTable data = db.query("select * from penjualan_detail where jual_id = @id");
            foreach (DataRow row in data.Rows)
            {
                string barang_id = row["barang_id"].ToString();
                string qty = row["qty"].ToString();
                string stok_masuk_id = row["stok_masuk_id"].ToString();

                // tambahkan stok
                stok_masuk.tambahkanStok(stok_masuk_id, qty);
            }
            db.bind("jual_id", jual_id);
            db.nQuery("delete from penjualan_detail where jual_id = @jual_id");

            db.bind("jual_id", jual_id);
            db.nQuery("delete from penjualan where jual_id = @jual_id");

        }

        public void setPrint(string id)
        {
            db.bind("id", id);
            db.nQuery("update penjualan set print = print + 1 where jual_id = @id");
            
        }

        public string getPenjualan(string id, string kolom)
        {
            db.bind("id", id);
            db.bind("kolom", kolom);

            return db.single("select "+kolom+" from  penjualan where jual_id = @id");

        }

        public DataTable getDetailBarang(string jual_id)
        {
            db.bind("jual_id", jual_id);
            return db.query("select penjualan_detail.barang_id, penjualan_detail.stok_masuk_id, penjualan_detail.qty, satuan.nama_satuan, barang.nama_barang, " +
                "harga, penjualan_detail.diskon_persen, total_harga, pembelian_detail.lot, pembelian_detail.ed, " +
                "cn1_persen, cn2_persen, margin, hpp "+
                "from penjualan_detail "+
                
                "left join barang on barang.barang_id = penjualan_detail.barang_id " +
                "left join satuan on satuan.satuan_id = barang.satuan_id " +
                "left join stok_masuk on stok_masuk.stok_masuk_id = penjualan_detail.stok_masuk_id " +
                "left join pembelian_detail on pembelian_detail.stok_id = stok_masuk.tabel_id "+
                "where jual_id = @jual_id  ");
        }

        public void hapusPenjualanDetail(string jual_id)
        {
            // hapus detail 
            db.bind("id", jual_id);
            DataTable data = db.query("select * from penjualan_detail where jual_id = @id");
            foreach (DataRow row in data.Rows)
            {
                string barang_id = row["barang_id"].ToString();
                string id = row["id"].ToString();
                string stok_masuk_id = row["stok_masuk_id"].ToString();
                string qty = row["qty"].ToString();

                // tambahkan stok
                stok_masuk.tambahkanStok(stok_masuk_id, qty);
            }
            db.bind("jual_id", jual_id);
            int var = db.nQuery("delete from penjualan_detail where jual_id = @jual_id");
            //Console.Write(var.ToString());
            

        }

        public void update(string id, string kolom, string val)
        {
            db.bind("id", id);
            db.bind("val", val);

            db.nQuery("update penjualan_detail set "+kolom+" = @val where id = @id  ");
        }

        public void updatePenjualan(string id, string kolom, string val)
        {
            db.bind("id", id);
            db.bind("val", val);

            db.nQuery("update penjualan  set " + kolom + " = @val where jual_id = @id  ");
        }

        public void insertPembayaran(string id, string tanggal, string jumlah)
        {
            db.bind("id", id);
            db.bind("tanggal", tanggal);
            db.bind("jumlah", jumlah);

            db.nQuery("insert into penjualan_bayar (jual_id, tanggal, jumlah) values (@id, @tanggal, @jumlah) ");
        }

        public void hapusPembayaran(string id)
        {
            db.bind("id", id);


            db.nQuery("delete from penjualan_bayar where id = @id ");
        }

        public string getTotalPembayaran(string id)
        {
            db.bind("jual_id", id);


            return db.single("select sum(jumlah) from penjualan_bayar where jual_id = @jual_id ");
        }

        public string getCN(string id)
        {
            db.bind("jual_id", id);


            return db.single("select sum((cn1_uang+cn2_uang)*qty) from penjualan_detail where jual_id = @jual_id ");
        }

    }
}
