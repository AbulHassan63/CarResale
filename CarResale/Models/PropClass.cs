using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CarResale.Models
{
    public class PropClass
    {
    }

    public class CarRegister
    {
        public List<CarMan> CarManinfo { get; set; }
        public List<CarModel> CarModelinfo { get; set; }
        public List<CarBrand> CarBrandinfo { get; set; }
        public int Reg_id { get; set; }
        public int Man_id { get; set; }
        public int Brand_id { get; set; }
        public int Model_id { get; set; }
        public int YearBuild { get; set; }
        public int Kilometer_Coverd { get; set; }
        public List<string> Images { get; set; }
        public DataTable DtImages { get; set; }
        public string Model_name { get; set; }
    }

    public class CarMan   
    {
        public int Man_id { get; set; }
        public string Man_name { get; set; }
    }
    public class CarModel
    {
        public int Model_id { get; set; }
        public string Model_name { get; set; }
    }
    public class CarBrand
    {
        public int Brand_id { get; set; }
        public string Brand_name { get; set; }
    }


    public class DashCarRegister
    {
    
        public int Reg_id { get; set; }
        public string Man_name { get; set; }
        public string Brand_name { get; set; }
        public string Model_name { get; set; }
        public int YearBuild { get; set; }
        public decimal Kilometer_Coverd { get; set; }
        public string CarImage { get; set; }
    }

    public class Dashboardview
    {
        public IList<DashCarRegister> DashCarRegister { get; set; }
        public List<CarMan> CarManinfo { get; set; }
        public List<CarModel> CarModelinfo { get; set; }
        public List<CarBrand> CarBrandinfo { get; set; }
        public int Man_id { get; set; }
        public int Brand_id { get; set; }
        public int Model_id { get; set; }
    }
}
