using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarImageDetailDto : IDto
    {
        public string BrandName { get; set; }
        public short ModelYear { get; set; }
        public string ColorName { get; set; }
        public decimal DailyPrice { get; set; }
        public string ImagePath { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
