using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sozlukApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        vtModel _baglan = new vtModel();

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //ara            
            if (textBox1.Text != "")
            {
                var arama = _baglan.sozlukTabloVerileri.Where(x => x.TrKelime.Contains(textBox1.Text) || x.IngKelime.Contains(textBox1.Text));
                dataGridView1.DataSource = arama.OrderBy(x => x.TrKelime).ToList();
            }
            else
            {
                yukle();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //açılış
            yukle();
        }

        private void yukle()
        {
            if (_baglan.sozlukTabloVerileri.Count() == 0)
            {
                sozlukTablo _veri = new sozlukTablo();
                _veri.TrKelime = "araba araç otomobil";
                _veri.IngKelime = "car vehicle";
                _baglan.sozlukTabloVerileri.Add(_veri);
                _veri = new sozlukTablo();
                _veri.TrKelime = "ev daire";
                _veri.IngKelime = "house home";
                _baglan.sozlukTabloVerileri.Add(_veri);
                _veri = new sozlukTablo();
                _veri.TrKelime = "kedi";
                _veri.IngKelime = "cat";
                _baglan.sozlukTabloVerileri.Add(_veri);
                _veri = new sozlukTablo();
                _veri.TrKelime = "keçi";
                _veri.IngKelime = "goat";
                _baglan.sozlukTabloVerileri.Add(_veri);
                _baglan.SaveChanges();
            }
            _baglan.SaveChanges();
            dataGridView1.DataSource = _baglan.sozlukTabloVerileri.OrderBy(x => x.TrKelime).ToList();
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //sil
            int id = (int)dataGridView1.CurrentRow.Cells[0].Value;
            sozlukTablo silinecek = _baglan.sozlukTabloVerileri.Where(x => x.Id == id).FirstOrDefault();
            _baglan.sozlukTabloVerileri.Remove(silinecek);
            yukle();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //yenile            
            yukle();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //ekle
            if (textBox2.Text != "" && textBox3.Text != "")
            {
                sozlukTablo _veri = new sozlukTablo();
                _veri.TrKelime = textBox2.Text;
                _veri.IngKelime = textBox3.Text;
                _baglan.sozlukTabloVerileri.Add(_veri);
                yukle();
            }
        }
    }
}
