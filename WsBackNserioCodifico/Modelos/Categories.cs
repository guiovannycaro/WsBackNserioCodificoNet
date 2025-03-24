namespace WsBackNserioCodifico.Modelos
{
    public class Categories
    {

      public int categoryid { get; set; }
      public string categoryname { get; set; }
      public    string description { get; set; }

        public Categories() { }

        public Categories(int categoryId, string categoryName,string Description) {
            this.categoryid = categoryId;
            this.categoryname = categoryName;
            this.description = Description;
        }

    }
}
