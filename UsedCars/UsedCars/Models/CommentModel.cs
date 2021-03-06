﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsedCars.Models
{
    public class CommentModel
    {
        public int ID { get; }
        public int Owner_ID { get; }
        public String Title { get; private set; }
        public String Message { get; private set; }
        public long Submission_Time { get; }
        public int? User_ID { get; }
        public int? Vehicle_ID { get; }
        public int? Shop_ID { get; }

        public List<LikeModel> Likes = new List<LikeModel>();

        public CommentModel(int id, int owenerid, string title, string message, long submission_time, int? userid, int? vehicleid, int? shopid)
        {
            ID = id;
            Owner_ID = owenerid;
            Title = title;
            Message = message;
            Submission_Time = submission_time;
            User_ID = userid;
            Vehicle_ID = vehicleid;
            Shop_ID = shopid;
        }

        public DateTime GetDate() { return new DateTime(1970, 1, 1).AddMilliseconds(double.Parse(Submission_Time.ToString())); }

        public void AddLike(LikeModel like) { Likes.Add(like); }
        public void RemoveLike(LikeModel like) { Likes.Remove(like); }

        public void Update(string title, string message)
        {
            Title = title;
            Message = message;
        }
    }
}
