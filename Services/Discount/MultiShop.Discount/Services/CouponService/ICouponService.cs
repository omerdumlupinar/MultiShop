using MultiShop.Discount.Dtos;

namespace MultiShop.Discount.Services.CouponService
{
    public interface ICouponService
    {
        Task<List<ResultCouponDto>> GetAllCouponAsync();
        Task CreateCouponAsync(CreateCouponDto createCouponDto);
        Task UpdateCouponAsync(UpdateCouponDto updateCouponDto);
        Task DeleteCouponAsync(int id);
        Task<GetByIdCouponDto> GetCouponByIdAsync(int id);
    }
}
