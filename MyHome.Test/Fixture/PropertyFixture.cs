using Newtonsoft.Json.Linq;

namespace MyHome.Test.Fixture
{
    public static class PropertyFixture
    {
        public static List<Property> GetTestProperties()
        {
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Fixture\\property_data.json");
            if (File.Exists(filePath))
            {
                var json = File.ReadAllText(filePath);
                var jobject = JObject.Parse(json);
                var properties = jobject["SearchResults"]?.ToObject<List<Property>>();
                if (properties != null)
                    return properties;
            }
            return new List<Property>();
        }
    }
}
