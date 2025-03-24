namespace WsBackNserioCodifico.Modelos
{
    public class Employees
    {

        public int empid    { get;set; }
        public string lastname { get; set; }
        public string firstname       { get;set; }
        public string    title  { get;set; }
        public string    titleofcourtesy  { get;set; }
        public DateTime birthdate       { get;set; }
        public DateTime hiredate { get; set; }

        public string address {get;set;}
        public string city { get; set; }
        public string region { get; set; }
        public string postalcode { get; set; }
        public string country { get; set; }
        public string  phone { get; set; }
        public int mgrid { get; set; }


        public Employees() { }
        public Employees(
          int empId ,
          string lastName ,
          string firstName ,
          string Title ,
          string titleoFcourtesy ,
          DateTime birthDate ,
          DateTime hiredate,
          string Address ,
          string City ,
          string Region ,
          string Postalcode ,
          string Country ,
          string Phone ,
          int Mgrid 
            )
        {
            this.empid = empId;
            this.lastname = lastName;
            this.firstname= firstName;
            this.title = Title;
            this.titleofcourtesy = titleoFcourtesy;
            this.birthdate = birthDate;
            this.hiredate = hiredate;
            this.address = Address;
            this.city = City;
            this.region = Region;
            this.postalcode = Postalcode;
            this.country = Country;
            this.phone = Phone;
            this.mgrid = Mgrid;
    }
    }
}
