using MyHome.Core.Models;

namespace MyHome.Data
{
    public interface IPropertyData
    {
        public Task<List<Property>> GetAll();
    }
}
