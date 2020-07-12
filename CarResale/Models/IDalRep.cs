using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarResale.Models
{
    public interface IDalRep
    {
        bool SaveRegister(CarRegister _carRegister);
        List<CarMan> Gatcarmaninfo();
        List<CarBrand> GetCarbrand(int Man_id);
        List<CarModel> GetCarmodel(int Brand_id);
        List<DashCarRegister> GetAllrecords();
        List<DashCarRegister> Getrecordsbyfilter(int Man_id,int Brand_id,int Model_id);
        bool SaveModel(CarRegister _carRegister);
    }
}
