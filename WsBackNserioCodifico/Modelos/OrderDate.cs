namespace WsBackNserioCodifico.Modelos
{
    public class OrderDate
    {
      public DateTime orderdate { get; set; }

        public OrderDate() { }

        public OrderDate(DateTime Orderdate) {
            this.orderdate = Orderdate;
        }

    }
}
