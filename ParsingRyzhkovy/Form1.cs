using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ParsingRyzhkovy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private String Fizkultura()
        {
            System.Net.WebClient wc = new System.Net.WebClient();
            String Responce = wc.DownloadString("https://samara.metrofitness.ru/");
            // data - price = "6 000" value = "sale.moskovskoe@fizkultura.info,galimova@fizkultura.info,samorodova@fizkultura.info,tumanov@fizkultura.info,sharova@sabit.ru,artemenko@sabit.ru,kazanceva@sabit.ru,polina@sabit.ru" > Московское шоссе </ option >
            String Rate = System.Text.RegularExpressions.Regex.Match(Responce, @"data-price = ""([0-9]+\.[0-9]+))""").Groups[1].Value;
            return "Fizкультура:" + Rate + " p. \r\n";
        }
        private void Form1_Shown(object sender, EventArgs e)
        {
            textBox1.Text = Fizkultura();
        }
    }
}

