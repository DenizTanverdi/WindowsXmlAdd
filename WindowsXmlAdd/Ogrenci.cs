using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsXmlAdd
{
   public class Ogrenci
    {
        private Guid id;

        public Guid Id
        {
            get { return id; }
            set { id = value; }
        }
        private string  adi;

        public string  Adi
        {
            get { return adi; }
            set { adi = value; }
        }
        private string soyadi;

        public string Soyadi
        {
            get { return soyadi; }
            set { soyadi = value; }
        }
        private DateTime dogumTarihi;

        public DateTime DogumTarihi
        {
            get { return dogumTarihi; }
            set { dogumTarihi = value; }
        }
        private cinsiyet cinsiyet;

        public cinsiyet Cinsiyet
        {
            get { return cinsiyet; }
            set { cinsiyet = value; }
        }


    }
   public enum cinsiyet
    {
        Kadın=1,
        Erkek=2,
        LGBT=3
    }
}
