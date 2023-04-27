using Microsoft.AspNetCore.JsonPatch;
using MyHome.Core.Models;

namespace MyHome.Data
{
    public class InMemoryPropertyData : IPropertyData
    {
        private static List<Property> _properties;

        public InMemoryPropertyData()
        {
            _properties = SetData();
        }

        public Property Add(Property entity)
        {
            var property = _properties.FirstOrDefault(p => p.PropertyId == entity.PropertyId);
            if (property == null)
            {
                entity.id = _properties.Max(p => p.id) + 1;
                _properties.Add(entity);
                return entity;
            }
            return null;
        }

        public Property Delete(int id)
        {
            var property = _properties.FirstOrDefault(p => p.PropertyId== id);
            if (property != null)
            {
                _properties.Remove(property);
            }
            return property;
        }

        public List<Property> GetAll()
        {
            return _properties;
        }

        public Property GetById(int id)
        {
            return _properties.SingleOrDefault(p => p.PropertyId == id);
        }

        public Property Update(int id, JsonPatchDocument<Property> fields)
        {
            var property = _properties.SingleOrDefault(p => p.PropertyId == id);
            if (property != null)
                fields.ApplyTo(property);
            return property;
        }

        private List<Property> SetData()
        {
            return new List<Property>()
            {
                new Property(){
                    id = 1,
                    PropertyId = 1,
                    GroupId = 5631,
                    CustomData = new CustomData()
                    {
                        RelatedPropertyIDs = new List<int>(),
                        IsMyHomePassport = false
                    },
                    RefreshedOn = DateTime.UtcNow,
                    Location = new Location()
                    {
                        lat = 0,
                        lon = 0
                    },
                    Address = "7 Phelan Street",
                    GroupPhoneNumber = "Sherry FitzGerald McDermott Tullow",
                    GroupEmail = "tullow@sfmcdermott.ie",
                    GroupName = "Sherry FitzGerald McDermott Tullow",
                    GroupAddress = "The Square, Tullow, Co. Carlow",
                    GroupUrlSlugIdentifier = "sherry-fitzgerald-mcdermott-tullow",
                    Negotiator = new Negotiator()
                    {
                        NegotiatorId = 517697,
                        Name = "Helen Brophy",
                        Email = "helen@sfmcdermott.ie",
                        WebSite = "https://www.sherryfitz.ie/branch/tullow"
                    },
                    CreatedOnDate = DateTime.UtcNow,
                    ActivatedOn = DateTime.UtcNow,
                    IsNew = false,
                    IsSaleAgreed = false,
                    GroupLogoBgColor = "#000000",
                    GroupPremiumHeadTextColour = "#FFFFFF",
                    GroupLogoUrl = "https://photos-a.propertyimages.ie/groups/1/3/6/5631/logo.jpg",
                    GroupPremiumLogoUrl = "",
                    GroupPremiumJointLogoUrl = "",
                    GroupRectangularLogoUrl = "",
                    JointGroupRectangularLogoUrl = "",
                    JointGroupPremiumJointLogo = "",
                    GroupUrl = "/estate-agents/sherry-fitzgerald-mcdermott-tullow-5631",
                    IsPremiumAd = false,
                    IsBuildToRent = false,
                    IsBuildToRentDevelopment = false,
                    IsPrivateLandlord = false,
                    IsBrandBooster = false,
                    IsActive = true,
                    SaleTypeId = 17,
                    IsFavourite = false,
                    HasVideos = false,
                    HasWebP = false,
                    IsMappedAccurately = true,
                    IsTopSpot = false,
                    BedsString = "3 beds",
                    PriceAsString = "€168,950",
                    BrochureMap = new BrochureMap()
                    {
                        longitude = -6.6927361488342285,
                        latitude = 52.880714416503906
                    },
                    SizeStringMeters = 87,
                    PriceChangeIsIncrease = false,
                    DisplayAddress = "7 Phelan Street, Rathvilly, Co. Carlow",
                    PropertyClassId = 1,
                    PropertyClass = "ResidentialForSale",
                    PropertyClassUrlSlug = "residential",
                    PropertyStatus = "ForSale",
                    PropertyType = "Terraced House",
                    BathString = "1 bath",
                    BerRating = "E2",
                    EnergyRatingMediaPath = "//photos-a.propertyimages.ie/static/images/energyRating/E2.png",
                    OpenViewings = new List<object>(),
                    VirtualViewings = new List<object>(),
                    OrderedDisplayAddress = "7 phelan street rathvilly co carlow",
                    SeoDisplayAddress = "7-phelan-street-rathvilly-co-carlow",
                    BrochureUrl = "/residential/brochure/7-phelan-street-rathvilly-co-carlow/4690497",
                    SeoUrl = "/residential/brochure/7-phelan-street-rathvilly-co-carlow/4690497",
                    PhotoCount = 0,
                    MainPhoto = "https://www.myhome.ie/app/assets/images/heart.png",
                    MainPhotoWeb = "https://www.myhome.ie/app/assets/images/heart.png",
                    Photos = new List<string>(),
                    TravelTimes = new List<object>(),
                    AuctionList = new List<object>(),
                    AdditionalLogoUrls = new List<string>(),
                    RelatedPropertiesTotal = 0
                }
            };
        }

    }
}
