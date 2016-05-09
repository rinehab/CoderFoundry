using System;
using System.Collections.Generic;
using System.Linq;
using CoderFoundry.Models;

namespace CoderFoundry.HCL2Services
{
    public class CarService : ICarService
    {
        private readonly HCL2Entities _hcl2Entities = new HCL2Entities();

        public SelectCarGridModels GetCars(CarGridParametersModel carGridParameters) //Gets the cars
        {
            IQueryable<CarModel> carListsResults = _hcl2Entities.Cars
                .Where(
                    a =>
                        a.make != string.Empty && a.make_display != string.Empty && a.model_name != null &&
                        (carGridParameters.FilteredMake == null || a.make_display == carGridParameters.FilteredMake) &&
                        (carGridParameters.FilteredModel == null || a.model_name == carGridParameters.FilteredModel) &&
                        a.model_name != string.Empty)
                .Select(
                    a => new CarModel
                    {

                        Id = a.id,
                        Make = a.make_display,
                        Model = a.model_name,
                        Year = a.model_year,
                        Trim = a.model_trim
                    });

            IOrderedQueryable<CarModel> orderedCars;
            bool sortAscending = !carGridParameters.SortDescending;
            switch (carGridParameters.SortColumn)
            {
                case "Make":
                    orderedCars = sortAscending ? carListsResults.OrderBy(c=> c.Make) : carListsResults.OrderByDescending(c => c.Make);
                    break;
                case "Model":
                    orderedCars = sortAscending ? carListsResults.OrderBy(c => c.Model) : carListsResults.OrderByDescending(c => c.Model);
                    break;
                case "Year":
                    orderedCars = sortAscending ? carListsResults.OrderBy(c => c.Year) : carListsResults.OrderByDescending(c => c.Year);
                    break;

                case "Trim":
                    orderedCars = sortAscending ? carListsResults.OrderBy(c => c.Trim) : carListsResults.OrderByDescending(c => c.Trim);
                    break;
                default:
                    orderedCars = sortAscending ? carListsResults.OrderBy(c => c.Make) : carListsResults.OrderByDescending(c => c.Make);
                    break;
            }
            int totalRows = orderedCars.Count();
            List<CarModel> results = carGridParameters.MaxRows.HasValue
                ? orderedCars.Take(carGridParameters.MaxRows.Value).ToList()
                : orderedCars.ToList();


            return new SelectCarGridModels { SelectCarModels  = results, TotalRows = totalRows };
        }

        public List<MakeModel> GetMakes()
        {
            var makes = _hcl2Entities.Cars
                .Where(c => c.make_display != null && c.make_display != string.Empty)
                .Select(c => new MakeModel
                {
                    MakeValue = c.make,
                    MakeDisplay = c.make_display
                }).Distinct().OrderBy(c => c.MakeDisplay).ToList();

            return makes;
        }


        public void AddCar(Car car)
        {
            _hcl2Entities.Cars.Add(car);
            _hcl2Entities.SaveChanges();
        }

        public void RemoveCar(CarModel car)
        {
            Car removeCar = _hcl2Entities.Cars.SingleOrDefault(c => c.id == car.Id);
            if (removeCar != null)
            {
                _hcl2Entities.Cars.Remove(removeCar);
                _hcl2Entities.SaveChanges();
            }
        }

        public void RemoveCar(int id)
        {
            Car removeCar = _hcl2Entities.Cars.SingleOrDefault(c => c.id == id);
            if (removeCar != null)
            {
                _hcl2Entities.Cars.Remove(removeCar);
                _hcl2Entities.SaveChanges();
            }
        }

        public List<ModelModel> GetModels(string make)
        {
            var models = _hcl2Entities.Cars
                .Where(c => c.make == make)
                .Select(c => new ModelModel
                {
                    ModelValue = c.model_name,
                    ModelDisplay = c.model_name
                }).Distinct().OrderBy(c => c.ModelDisplay).ToList();

            return models;
        }
    }
}
