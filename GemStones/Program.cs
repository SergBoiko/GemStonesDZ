using GemStones.Presentation.Services;
using GemStones.Presentation.Services.Interfaces;

namespace GemStones
{
    class Program
    {
        static void Main(string[] args)
        {
            IProductViewService service = new ProductViewService();

             var a = service.GetProductByGems(false);
            var b = service.GetProductById(1);
            var c = service.GetProductByType(1);
        }
    }
}
