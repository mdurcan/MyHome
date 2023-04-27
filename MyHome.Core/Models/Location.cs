using Microsoft.EntityFrameworkCore;

namespace MyHome.Core.Models
{
    [Keyless]
    public class Location
    {
        public int lat { get; set; }
        public int lon { get; set; }

        public Location() { }
    }

}
