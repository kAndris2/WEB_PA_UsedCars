﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UsedCars.Controllers
{
    [Authorize]
    public class VehicleController : Controller
    {
        IDAO IDAO = IDAO.Singleton;

        [AllowAnonymous]
        [HttpGet("Vehicle_Profile/{id}")]
        public IActionResult Vehicle_Profile(int id)
        {
            return View(IDAO.GetVehicleByID(id));
        }

        [HttpGet("Vehicle_Edit/{id}")]
        public IActionResult Vehicle_Edit(int id)
        {
            return View(IDAO.GetVehicleByID(id));
        }

        [HttpPost]
        public IActionResult Editor([FromForm(Name = "brand")] string brand, [FromForm(Name = "model")] string model, [FromForm(Name = "type")] string type, [FromForm(Name = "fuel")] string fuel,
            [FromForm(Name = "odometer")] int odometer, [FromForm(Name = "year")] int year, [FromForm(Name = "validity")] string validity, [FromForm(Name = "price")] int price, [FromForm(Name = "type_designation")] string type_des,
            [FromForm(Name = "cylinder")] int cylinder, [FromForm(Name = "performance")] int performance, [FromForm(Name = "description")] string description, [FromForm(Name = "id")] int id)
        {
            IDAO.EditVehicle(id,
                             brand,
                             model,
                             type,
                             fuel,
                             type_des,
                             odometer,
                             year,
                             validity == "Valid",
                             price,
                             cylinder,
                             performance,
                             description);
            return View("Vehicle_Profile", IDAO.GetVehicleByID(id));
        }

        [HttpGet("Delete_Vehicle/{id}")]
        public IActionResult Delete_Vehicle(int id)
        {
            IDAO.Delete("vehicles", id);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Buy_Vehicle([FromForm(Name = "vehicleid")] int vehicleid, [FromForm(Name = "userid")] int userid, [FromForm(Name = "shopid")] int shopid)
        {
            IDAO.BuyVehicle(vehicleid, userid, shopid);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Vehicle_Comment([FromForm(Name = "title")] string title, [FromForm(Name = "message")] string message, [FromForm(Name = "ownerid")] int ownerid, [FromForm(Name = "vehicleid")] int vehicleid)
        {
            IDAO.CreateComment("vehicle", vehicleid, title, message, ownerid);
            return View("Vehicle_Profile", IDAO.GetVehicleByID(vehicleid));
        }
    }
}