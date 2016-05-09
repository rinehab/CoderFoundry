using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using CoderFoundry.HCL2Services;
using CoderFoundry.Models;
using MvcJqGrid;

namespace CoderFoundry.Web.Controllers
{
    public class SearchController : Controller
    {
        public SearchController(ICarService carService)
        {
            CarService = carService;
        }

        private ICarService CarService { get; }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetCars(GridSettings gridSettings)
        {
            CarGridParametersModel selectLocationSearchFilter = GetCarGridSearchFilter(gridSettings);

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            JqGridData<CarModel> gridData = new JqGridData<CarModel>();
            SelectCarGridModels selectCarGridModel =
                CarService.GetCars(selectLocationSearchFilter);
            gridData.Rows =
                selectCarGridModel.SelectCarModels
                    .Select(c => new CarModel
                    {
                        Id = c.Id,
                        Make = c.Make,
                        Model = c.Model,
                        Year = c.Year,
                        Trim = c.Trim
                    }).ToList();

            // For simplicity just use Int32's max value.
            // You could always read the value from the config section mentioned above.
            serializer.MaxJsonLength = Int32.MaxValue;
            int totalCars = gridData.Rows.Count();
            gridData.Page = gridSettings.PageIndex;
            gridData.Records = selectCarGridModel.TotalRows;
            gridData.Total = totalCars / gridSettings.PageSize + (totalCars % gridSettings.PageSize > 0 ? 1 : 0);

            JsonResult jsonResult = Json(gridData, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        private CarGridParametersModel GetCarGridSearchFilter(GridSettings gridSettings)
        {
            CarGridParametersModel carGridParameters = new CarGridParametersModel();

            if (gridSettings.Where != null)
            {
                foreach (Rule rule in gridSettings.Where.rules.Where(rule => rule.data != "null"))
                {
                    switch (rule.field)
                    {
                        case "filteredMake":
                            carGridParameters.FilteredMake = rule.data;
                            break;
                        case "filteredModel":
                            carGridParameters.FilteredModel = rule.data;
                            break;
                    }
                }
            }
            carGridParameters.SortColumn = gridSettings.SortColumn;
            carGridParameters.SortDescending = gridSettings.SortOrder != "asc";
            carGridParameters.MaxRows = gridSettings.PageSize;
            return carGridParameters;
        }

        [HttpPost]
        public string Create([Bind(Exclude = "Id")] Car car)
        {
            string msg;
            try
            {
                if (ModelState.IsValid)
                {
                    CarService.AddCar(car);
                    msg = "Saved Successfully";
                }
                else
                {
                    msg = "Validation data not successfull";
                }
            }
            catch (Exception ex)
            {
                msg = "Error occured:" + ex.Message;
            }
            return msg;
        }

        public string Edit(CarModel car)
        {
            string msg;
            try
            {
                if (ModelState.IsValid)
                {
                    CarService.RemoveCar(car);
                    msg = "Saved Successfully";
                }
                else
                {
                    msg = "Validation data not successfull";
                }
            }
            catch (Exception ex)
            {
                msg = "Error occured:" + ex.Message;
            }
            return msg;
        }

        public string Delete(int id)
        {
            CarService.RemoveCar(id);
            return "Deleted successfully";
        }

        public JsonResult GetMakes()
        {
            var makes = CarService.GetMakes()
                .Select(sli => new SelectListItem
                {
                    Value = sli.MakeValue,
                    Text = sli.MakeDisplay
                }).ToList();

            return Json(makes, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetModels(string make)
        {
            var models = CarService.GetModels(make)
                .Select(sli => new SelectListItem
                {
                    Value = sli.ModelValue,
                    Text = sli.ModelDisplay
                }).ToList();

            return Json(models, JsonRequestBehavior.AllowGet);
        }
    }
}