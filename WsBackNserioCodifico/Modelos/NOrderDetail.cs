namespace WsBackNserioCodifico.Modelos
{
    public class NOrderDetail
    {

        public int orderid { get; set; }
        public int custid { get; set; }
        public int empid { get; set; }
        public DateTime orderdate { get; set; }
        public DateTime requireddate { get; set; }
        public DateTime shippeddate { get; set; }
        public int shipperid { get; set; }
        public int freight { get; set; }
        public string shipname { get; set; }
        public string shipaddress { get; set; }
        public string shipcity { get; set; }
        public string shipregion { get; set; }
        public string shippostalcode{ get; set; }
        public string shipcountry { get; set; }
        public int productid { get; set; }
        public int unitprice { get; set; }
        public int qty { get; set; }
        public int discount { get; set; }

        public NOrderDetail() { }

        public NOrderDetail(
            int Orderid ,
        int Custid ,
         int Empid ,
         DateTime Orderdate ,
         DateTime Requireddate ,
         DateTime Shippeddate ,
         int Shipperid ,
        int Freight ,
         string Shipname,
        string Shipaddress ,
        string Shipcity,
         string Shipregion ,
         string Shippostalcode ,
         string Shipcountry,
         int Productid ,
         int Unitprice,
         int Qty,
        int Discount
            ) {
            this.orderid = Orderid;
            this.custid = Custid;
            this.empid = Empid;
            this.orderdate = Orderdate;
            this.requireddate = Requireddate;
            this.shippeddate = Shippeddate;
            this.shipperid = Shipperid;
            this.freight = Freight;
            this.shipname= Shipname;
            this.shipaddress= Shipaddress;
            this.shipcity =Shipcity;
            this.shipregion= Shipregion;
            this.shippostalcode= Shippostalcode;
            this.shipcountry =Shipcountry;
            this.productid =Productid;
            this.unitprice =Unitprice;
            this.qty= Qty;
            this.discount =Discount;
    }


    }
}
