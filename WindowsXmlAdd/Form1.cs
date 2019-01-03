using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace WindowsXmlAdd
{
    public partial class Form1 : Form
    {
        List<Ogrenci> ogrenciList = new List<Ogrenci>();
        public Form1()
        {
            InitializeComponent();
        }



      

        private void button1_Click(object sender, EventArgs e)
        {
            Ogrenci o = new Ogrenci();
            o.Id = Guid.NewGuid() ;
            o.Adi = txtName.Text;
            o.Soyadi = txtBxSurname.Text;
            o.DogumTarihi = dateTime.Value;
            if (radioButton1.Checked)
                o.Cinsiyet = cinsiyet.Erkek;
            else if (radioButton2.Checked)
                o.Cinsiyet = cinsiyet.Kadın;
            else
                o.Cinsiyet = cinsiyet.LGBT;

            ogrenciList.Add(o);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = ogrenciList;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveFileOgrenci.Title = "Öğrenci Bilgileri Kayıt";
            saveFileOgrenci.Filter = "*.xml|*.xml";
            saveFileOgrenci.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            XmlSerializer srl = new XmlSerializer(typeof(List<Ogrenci>));
            if (saveFileOgrenci.ShowDialog()==DialogResult.OK)
            {
                TextWriter tw = new StreamWriter(saveFileOgrenci.FileName);
                srl.Serialize(tw, ogrenciList);
                tw.Close();
                MessageBox.Show("Liste Kaydedildi.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<Ogrenci> okunanOgrenciler = new List<Ogrenci>();
            XmlSerializer srl = new XmlSerializer(typeof(List<Ogrenci>));
            if (openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                TextReader tr = new StreamReader(openFileDialog1.FileName);
                okunanOgrenciler = (List < Ogrenci >) srl.Deserialize(tr);
                tr.Close();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = okunanOgrenciler;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            ds.ReadXml("C:\\Users\\iau\\Desktop\\deneme.xml");
            

        }
    }
}
