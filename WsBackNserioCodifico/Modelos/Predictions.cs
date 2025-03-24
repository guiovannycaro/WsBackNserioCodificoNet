namespace WsBackNserioCodifico.Modelos
{
    public class Predictions
    {
        public int custid {get;set;}
       public  string companyname {get;set;}
       public string contactname {get;set;}
       public DateTime orderdate{get;set;}
       public DateTime nexpredictedorder{get;set;}

        public Predictions() { }

        public Predictions(int Custid, string Companyname, string Contactname,
         DateTime Orderdate, DateTime Nexpredictedorder ) {

            this.custid = Custid;
            this.companyname = Companyname;
            this.contactname = Contactname;
            this.orderdate = Orderdate;
            this.nexpredictedorder = Nexpredictedorder;
        }


    }
}
