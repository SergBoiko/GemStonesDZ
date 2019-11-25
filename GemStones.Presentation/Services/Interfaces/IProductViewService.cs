using GemStones.Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GemStones.Presentation.Services.Interfaces
{
    public interface IProductViewService
    {
        ProductView GetProductById(int Id);
        List<ProductView> GetProductByType(int typeId);
        List<ProductView> GetProductByGems(bool containsGems);
    }
}
