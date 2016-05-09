using System.Collections.Generic;
using CoderFoundry.Models;

namespace CoderFoundry.HCL2Services
{
    public interface ICarService
    {
        SelectCarGridModels GetCars(CarGridParametersModel carGridParameters);
        List<MakeModel> GetMakes();
        List<ModelModel> GetModels(string make);
        void AddCar(Car car);
        void RemoveCar(CarModel car);
        void RemoveCar(int id);
    }
}