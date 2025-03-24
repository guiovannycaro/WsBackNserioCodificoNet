namespace WsBackNserioCodifico.Modelos
{
    public class Products
    {
       public int productid  { get; set; }
        public string productname { get; set; }
        public int supplierid   { get; set; }
        public int categoryid { get; set; }
        public decimal unitprice    { get; set; }
        public bool discontinued { get; set; }

        public Products() { }
        public Products(
            int Productid ,
            string Productname,
            int Supplierid ,
            int Categoryid,
            decimal Unitprice ,
            bool Discontinued 
            ) {
            this.productid = Productid;
            this.productname= Productname;
            this.supplierid= Supplierid;
            this.categoryid= Categoryid;
            this.unitprice= Unitprice;
            this.discontinued= Discontinued;
        }
    }
}
