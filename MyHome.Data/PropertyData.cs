using MyHome.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHome.Data
{
    public class PropertyData : IPropertyData
    {

        public PropertyData() { }

        public Task<List<Property>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
