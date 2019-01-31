using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace projectChat.Models
{
    public interface IManagerProduct
    {
        Task<List<ProductModel>> SearchByName(string name);

    }
}
