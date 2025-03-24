namespace WsBackNserioCodifico.Modelos
{
    public class DetailsOrders
    {

        public int orderid { get; set; }
        public string companyname { get; set; }
        public string contactname { get; set; }
        public string   productname { get; set; }
        public decimal unitprice { get; set; }
        public int qty { get; set; }
        public decimal discount { get; set; }


        public DetailsOrders() { }

        public DetailsOrders(
              int Orderid,
         string Companyname,
        string Contactname ,
         string Productname ,
        decimal Unitprice ,
        int Qty ,
        decimal Discount 
            ) {
            this.orderid = Orderid;
            this.companyname = Companyname;
            this.contactname = Contactname;
            this.productname = Productname;
            this.unitprice = Unitprice;
            this.qty = Qty;
            this.discount = Discount;



        }

    }
}
