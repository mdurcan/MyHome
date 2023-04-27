using Microsoft.EntityFrameworkCore;

namespace MyHome.Core.Models
{
    [Keyless]
    public class BrochureMap
    {
        public double longitude { get; set; }
        public double latitude { get; set; }

        public BrochureMap() { }
    }

}
