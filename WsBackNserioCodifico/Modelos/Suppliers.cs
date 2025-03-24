namespace WsBackNserioCodifico.Modelos
{
    public class Suppliers
    {
       public int supplierid { get;set;}
        public string companyname { get;set;}
        public string contactname { get; set;}
        public string contacttitle { get; set;}
        public string address { get; set;}
        public string city { get; set;}
        public string region { get; set;}
        public string postalcode { get; set;}
        public string country { get; set;}
        public string phone { get; set;}
        public string fax { get; set;}

        public Suppliers() { }


              public Suppliers(
          int Supplierid ,
          string Companyname ,
          string Contactname ,
          string Contacttitle ,
          string Address ,
          string City ,
          string Region ,
          string Postalcode ,
          string Country ,
          string Phone ,
          string Fax 
                  ) {
            this.supplierid = Supplierid;
            this.supplierid = Supplierid;
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
