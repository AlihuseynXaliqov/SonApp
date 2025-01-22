﻿using SonMVCApp.Models.Base;

namespace SonMVCApp.Models
{
    public class Agent:BaseEntity
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int PositionId { get; set; }
        public Position Position { get; set; }
    }
}
