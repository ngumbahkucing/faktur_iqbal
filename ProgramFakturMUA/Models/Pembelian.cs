using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramFakturMUA
{
    class Pembelian
    {
        Db db = new Db();
        Stok_masuk stok_masuk = new Stok_masuk();
        Functions fungsi = new Functions();
        Setting setting = new Setting();

        public string getPembelian(string id, string kolom)
        {
            db.bind("id", id);
            db.bind("kolom", kolom);

            return db.single("select " + kolom + " from  pembelian where beli_id = @id");

        }

        public string getLatestIDPembelian()
        {
            string var = db.single("select beli_id from pembelian order by beli_id desc limit 1");
            return var;
        }

        public void hapusPembelian(string beli_id)
        {
            // hapus detail pembelian
            db.bind("id", beli_id);
            DataTable data = db.query("select * from pembelian_detail where beli_id = @id");
            foreach (DataRow row in data.Rows)
            {
                string barang_id = row["barang_id"].ToString();
                string detail_id = row["stok_id"].ToString();
                stok_masuk.hapusByTabelID(detail_id);
            }

            db.bind("beli_id", beli_id);
            db.nQuery("delete from pembelian_detail where beli_id = @beli_id");

            db.bind("beli_id", beli_id);
            db.nQuery("delete from pembelian where beli_id = @beli_id");
             
        }

        public string getLatestDetailID()
        {
            return db.single("select stok_id from pembelian_detail order by stok_id desc limit 1 ");
        }

        public string getHPP(string stok_masuk_id)
        {
            db.bind("id", stok_masuk_id);
            string tabel_id = db.single("select tabel_id from stok_masuk where stok_masuk_id = @id");
            db.bind("stok_id", tabel_id);
            //fungsi.showError(tabel_id);
            string harga_beli = db.single("select harga_beli - ((diskon_persen/100) * harga_beli) from pembelian_detail where stok_id = @stok_id");
            //fungsi.showError("hpp1: " + harga_beli); 
            if (string.IsNullOrEmpty(harga_beli))
            {
                db.bind("id", stok_masuk_id);
                string barang_id = db.single("select barang_id from stok_masuk where stok_masuk_id = @id");
                db.bind("barang_id", barang_id);
                harga_beli = db.single("select harga_beli - ((diskon_persen/100) * harga_beli) from pembelian_detail where barang_id = @barang_id limit 1");
                //fungsi.showError("hpp2: "+harga_beli);
            }
            
            db.bind("stok_id", tabel_id);
            string beli_id = db.single("select beli_id from pembelian_detail where stok_id = @stok_id");
            string ppn = setting.getSetting("ppn"); 
            if (string.IsNullOrEmpty(beli_id))
            {
                
            }
            else
            {
                db.bind("beli_id", beli_id);
                ppn = db.single("select ppn_persen from pembelian where beli_id = @beli_id");

            }
            //fungsi.showError(beli_id);
            //fungsi.showError("ppn:"+ppn+ " harga beli: " + harga_beli + " beli_id: "+beli_id+ " stok_masuk_id: "+stok_masuk_id+ " tabel_id: "+tabel_id);
            double hpp = 0;
            try
            {
                hpp = double.Parse(harga_beli) ;
            }
            catch 
            {
                fungsi.showError("ppn:" + ppn + " harga beli: " + harga_beli + " beli_id: " + beli_id + " stok_masuk_id: " + stok_masuk_id + " tabel_id: " + tabel_id);
            
            }
                return hpp.ToString();
        }

        public DataTable getDetailBarang(string beli_id)
        {
            db.bind("beli_id", beli_id);
            return db.query("select pembelian_detail.barang_id, pembelian_detail.stok_id, pembelian_detail.qty, satuan.nama_satuan, barang.nama_barang, " +
                "pembelian_detail.harga_beli as harga, pembelian_detail.diskon_persen, total, pembelian_detail.lot, pembelian_detail.ed " +

                "from pembelian_detail " +

                "left join barang on barang.barang_id = pembelian_detail.barang_id " +
                "left join satuan on satuan.satuan_id = barang.satuan_id " +

                "where beli_id = @beli_id  ");
        }

        public void hapusPembelianDetail(string beli_id)
        {
            // hapus detail 
            db.bind("id", beli_id);
            DataTable data = db.query("select * from pembelian_detail where beli_id = @id");
            foreach (DataRow row in data.Rows)
            {
                string barang_id = row["barang_id"].ToString();
                //string id = row["id"].ToString();
                string stok_id = row["stok_id"].ToString();
                db.bind("tabel_id", stok_id);
                string stok_masuk_id = db.single("select stok_masuk_id from stok_masuk where tabel_id = @tabel_id");
                string qty = row["qty"].ToString();

                // kurangi stok
                stok_masuk.kurangiStok(stok_masuk_id, qty);
            }
            db.bind("beli_id", beli_id);
            int var = db.nQuery("delete from pembelian_detail where beli_id = @beli_id");
            //Console.Write(var.ToString());


        }

        public void hapusPembelianDetailByStokID(string stok_id)
        {
            // hapus detail 
            
            db.bind("stok_id", stok_id);
            int var = db.nQuery("delete from pembelian_detail where stok_id = @stok_id");
            //Console.Write(var.ToString());


        }

        public void updatePembelian(string id, string kolom, string val)
        {
            db.bind("id", id);
            db.bind("val", val);

            db.nQuery("update pembelian  set " + kolom + " = @val where beli_id = @id  ");
        }

        public void insertPembayaran(string id, string tanggal, string jumlah)
        {
            db.bind("id", id);
            db.bind("tanggal", tanggal);
            db.bind("jumlah", jumlah);

            db.nQuery("insert into pembelian_bayar (beli_id, tanggal, jumlah) values (@id, @tanggal, @jumlah) ");
        }

        public void hapusPembayaran(string id)
        {
            db.bind("id", id);

            db.nQuery("delete from pembelian_bayar where id = @id ");
        }

        
    }
}
