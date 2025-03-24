using System.Data;
using System.Security.Principal;

namespace WsBackNserioCodifico.Modelos
{
    public class Orders
    {
    public int orderid { get; set; }
  public int custid { get; set; }
    public int empid { get; set; }
    public DateTime orderdate { get; set; }
    public DateTime requireddate { get; set; }
    public DateTime shippeddate { get; set; }
    public int shipperid { get; set; }
    public decimal freight { get; set; }
    public string shipname { get; set; }
    public string shipaddress { get; set; }
    public string shipcity { get; set; }
    public string shipregion { get; set; }
    public string shippostalcode { get; set; }
    public string shipcountry { get; set; }

  
        public Orders() { }
        public Orders(
            int Orderid ,
            int Custid ,
            int Empid ,
            DateTime Orderdate ,
            DateTime Requireddate ,
            DateTime Shippeddate ,
            int Shipperid ,
            decimal Freight,
            string Shipname,
            string  Shipaddress ,
            string Shipcity ,
            string Shipregion,
            string Shippostalcode,
            string  Shipcountry   
            ) {
            this.orderid = Orderid;
            this.custid = Custid;
            this.empid = Empid;
            this.orderdate = Orderdate;
            this.requireddate = Requireddate;
            this.shippeddate = Shippeddate;
            this.shipperid = Shipperid;
            this.freight = Freight;
            this.shipname = Shipname;
            this.shipaddress = Shipaddress;
            this.shipcity = Shipcity;
            this.shipregion = Shipregion;
            this.shippostalcode = Shippostalcode;
            this.shipcountry = Shipcountry;

        }
    }
}
