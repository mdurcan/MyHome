using MyHome.Core.Models;

namespace MyHome.Core.Services
{
    public interface IPropertyService
    {
        public Task<List<Property>> GetAll();
    }
}
