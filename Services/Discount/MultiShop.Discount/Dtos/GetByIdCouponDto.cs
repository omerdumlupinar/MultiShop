﻿namespace MultiShop.Discount.Dtos
{
    public class GetByIdCouponDto
    {
        public int CouponId { get; set; }
        public string Code { get; set; }
        public int Rate { get; set; }
        public int IsActive { get; set; }
        public DateTime ValidDate { get; set; }
    }
}
