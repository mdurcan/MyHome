using Microsoft.EntityFrameworkCore;

namespace MyHome.Core.Models
{
    [Keyless]
    public class CustomData
    {
        public List<int> RelatedPropertyIDs { get; set; }
        public bool IsMyHomePassport { get; set; }
        public string? PromotionalSnippet { get; set; }
        public string? DevelopmentLogoBgColour { get; set; }

        public CustomData() { 
            RelatedPropertyIDs= new List<int>();
        }
    }

}
