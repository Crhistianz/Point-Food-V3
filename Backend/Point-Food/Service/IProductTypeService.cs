using PointFood.Commons;
using PointFood.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointFood.Service
{
    public interface IProductTypeService
    {
        Task<DataCollection<ProductTypeDto>> GetAll(int page, int take);
    }
}
