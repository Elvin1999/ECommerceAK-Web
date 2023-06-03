using ECommerce.Core.DataAccess.EntityFramework;
using ECommerce.DataAccess.Abstract;
using ECommerce.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccess.Concrete.EntityFramework
{
    public class EfProductDal:EfEntityRepositoryBase<Product,NorthwindContext> , IProductDal
    {
    }
}
