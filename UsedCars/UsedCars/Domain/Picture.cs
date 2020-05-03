﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsedCars.Domain
{
    public class Picture
    {
        public int ID { get; }
        public String Route { get; }
        public int? User_ID { get; }
        public int? Vehicle_ID { get; }
        public int? Shop_ID { get; }

        public Picture(int id, string route, int? userid, int? vehicleid, int? shopid)
        {
            ID = id;
            Route = route;
            User_ID = userid;
            Vehicle_ID = vehicleid;
            Shop_ID = shopid;
        }
    }
}
