using Domain.Models;
using Domain.Products;

namespace Application
{
    public interface IBikeRepository 
    {
        void CreateBike(Bike bike);
        IEnumerable<Product> GetBikes();
        void DeleteBike(Bike bike);
        Product GetBikeById(int bikeId);
        void UpdateBike(int bikeId, Bike bike);
    }
}
