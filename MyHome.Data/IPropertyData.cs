using MyHome.Core.Models;

namespace MyHome.Data
{
    public interface IPropertyData
    {
        public Task<List<Property>> GetAll();
        public Task<Property> GetById(int id);
        public Task<Property> Add(Property entity);
    }
}
