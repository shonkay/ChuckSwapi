using ChuckSwapi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChuckSwapi.Core.Interface
{
    public interface ICategory
    {
        Task<ResponseModel> GetAllCategories();
    }
}
