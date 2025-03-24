namespace WsBackNserioCodifico.Modelos
{
    public class Shippers
    {
       public int shipperid {get;set;}
        public string companyname { get; set; }
        public string phone { get; set; }

        public Shippers() { }

        public Shippers(
              int Shipperid ,
              string Companyname ,
              string Phone 
            ) {
              this.shipperid = Shipperid;
              this.companyname = Companyname;
              this.phone = Phone;
        }
    }
}
