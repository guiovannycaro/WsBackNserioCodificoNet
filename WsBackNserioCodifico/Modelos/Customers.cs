using System.Diagnostics.Metrics;
using System.Net;
using System.Numerics;
using System.Security.Principal;

namespace WsBackNserioCodifico.Modelos
{
    public class Customers
    {
       public  int custid { get; set; }
        public string  companyname{ get; set; }
        public string contactname { get; set; }
        public string contacttitle { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string region { get; set; }
        public string postalcode { get; set; }
        public string country { get; set; }
        public string phone { get; set; }
        public string fax { get; set; }

        public Customers() { }
        public Customers(
          int Custid ,
          string Companyname ,
          string Contactname,
          string Contacttitle,
          string Address  ,
          string City     ,
          string Region   ,
          string Postalcode,
          string Country,
          string Phone  ,
          string Fax  
            ) {
            this.custid = Custid;
            this.companyname = Companyname;
            this.contactname = Contactname;
            this.contacttitle = Contacttitle;
            this.address = Address;
            this.city = City;
            this.region = Region;
            this.postalcode = Postalcode;
            this.country = Country;
            this.phone = Phone;
            this.fax = Fax;
        }





    }
}
