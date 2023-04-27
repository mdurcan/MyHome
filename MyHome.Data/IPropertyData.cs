using Microsoft.AspNetCore.JsonPatch;
using MyHome.Core.Models;
using System.Transactions;

namespace MyHome.Data
{
    public interface IPropertyData
    {
        public List<Property> GetAll();
        public Property GetById(int id);
        public Property Add(Property entity);
        public Property Update(int id, JsonPatchDocument<Property> fields);
        public Property Delete(int id);
    }
}
