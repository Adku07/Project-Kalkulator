using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kalkulator
{
    public partial class Kalkulator : Form
    {
        public Kalkulator()
        {
            InitializeComponent();
            KalculatorInit();
        }
        private void KalculatorInit()
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Penjumlahan");
            comboBox1.Items.Add("Pengurangan");
            comboBox1.Items.Add("Perkalian");
            comboBox1.Items.Add("Pembagian");
            comboBox1.SelectedIndex = 0;
        }

        public delegate void Proses(int nilaiA, int nilaiB, string operasi, string operasiLabel, float hasil);

        public event Proses prosesEvent;

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnProses_Click(object sender, EventArgs e)
        {
            int nilaiA = int.Parse(NilaiA.Text);
            int nilaiB = int.Parse(NilaiB.Text);
            string operasi = "";
            string operasiLabel = "";
            float hasil = 0;
            switch (comboBox1.SelectedIndex)
            {
                // Penjumlahan
                case 0:
                    hasil = Hitung.Penjumlahan(nilaiA, nilaiB);
                    operasiLabel = "Penjumlahan";
                    operasi = "+";
                    break;
                // Pengurangan
                case 1:
                    hasil = Hitung.Pengurangan(nilaiA, nilaiB);
                    operasiLabel = "Pengurangan";
                    operasi = "-";
                    break;
                // Perkalian
                case 2:
                    hasil = Hitung.Perkalian(nilaiA, nilaiB);
                    operasiLabel = "Perkalian";
                    operasi = "x";
                    break;
                // Pembagian
                case 3:
                    hasil = (float)Hitung.Pembagian(nilaiA, nilaiB);
                    operasiLabel = "Pembagian";
                    operasi = "/";
                    break;

            }
            prosesEvent(nilaiA, nilaiB, operasi, operasiLabel, hasil);
        }
    }
}

