using System.Data;

namespace WsBackNserioCodifico.Modelos
{
    public class OrderDetails
    {
        public int orderid { get; set; }
        public int productid { get; set; }
        public decimal unitprice { get; set; }
        public int qty { get; set; }
        public decimal discount { get; set; }

        public OrderDetails() { }

        public OrderDetails(
            int Orderid ,
            int Productid,
            decimal Unitprice,
            int Qty,
            decimal Discount 
            ) {
            this.orderid = Orderid;
            this.productid = Productid;
            this.unitprice = Unitprice;
            this.qty = Qty;
            this.discount = Discount;


        }



    }
}
