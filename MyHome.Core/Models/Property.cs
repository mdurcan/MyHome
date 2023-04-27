﻿using System.ComponentModel.DataAnnotations;

namespace MyHome.Core.Models
{
    public class Property
    {
        [Required]
        [Key]
        public int id { get; set; }
        [Required]
        public int PropertyId { get; set; }
        public int GroupId { get; set; }
        public int SaleTypeId { get; set; }
        public CustomData CustomData { get; set; }
        public DateTime RefreshedOn { get; set; }
        public Location Location { get; set; }
        public string? Address { get; set; }
        public string? GroupPhoneNumber { get; set; }
        public string? GroupEmail { get; set; }
        public string? GroupName { get; set; }
        public string? GroupAddress { get; set; }
        public string? GroupUrlSlugIdentifier { get; set; }
        public Negotiator Negotiator { get; set; }
        public DateTime CreatedOnDate { get; set; }
        public DateTime ActivatedOn { get; set; }
        public bool IsNew { get; set; }
        public bool IsSaleAgreed { get; set; }
        public string? GroupLogoBgColor { get; set; }
        public string? GroupPremiumHeadTextColour { get; set; }
        public string? GroupLogoUrl { get; set; }
        public string? GroupPremiumLogoUrl { get; set; }
        public string? GroupPremiumJointLogoUrl { get; set; }
        public string? GroupRectangularLogoUrl { get; set; }
        public string? JointGroupRectangularLogoUrl { get; set; }
        public string? JointGroupPremiumJointLogo { get; set; }
        public string? GroupUrl { get; set; }
        public bool IsPremiumAd { get; set; }
        public bool IsBuildToRent { get; set; }
        public bool IsBuildToRentDevelopment { get; set; }
        public bool IsPrivateLandlord { get; set; }
        public bool IsBrandBooster { get; set; }
        public bool IsActive { get; set; }
        public bool IsFavourite { get; set; }
        public bool HasVideos { get; set; }
        public bool HasWebP { get; set; }
        public bool IsMappedAccurately { get; set; }
        public bool IsTopSpot { get; set; }
        public string? BedsString { get; set; }
        public string? PriceAsString { get; set; }
        public BrochureMap BrochureMap { get; set; }
        public float SizeStringMeters { get; set; }
        public bool PriceChangeIsIncrease { get; set; }
        public string? DisplayAddress { get; set; }
        public int PropertyClassId { get; set; }
        public string? PropertyClass { get; set; }
        public string? PropertyClassUrlSlug { get; set; }
        public string? PropertyStatus { get; set; }
        public string? PropertyType { get; set; }
        public string? BathString { get; set; }
        public string? BerRating { get; set; }
        public string? EnergyRatingMediaPath { get; set; }
        public List<object> OpenViewings { get; set; }
        public List<object> VirtualViewings { get; set; }
        public string? OrderedDisplayAddress { get; set; }
        public string? SeoDisplayAddress { get; set; }
        public string? BrochureUrl { get; set; }
        public string? SeoUrl { get; set; }
        public int PhotoCount { get; set; }
        public string? MainPhoto { get; set; }
        public string? MainPhotoWeb { get; set; }
        public List<string> Photos { get; set; }
        public List<object> TravelTimes { get; set; }
        public List<object> AuctionList { get; set; }
        public List<string> AdditionalLogoUrls { get; set; }
        public int RelatedPropertiesTotal { get; set; }
        public string? LatestPriceChangeString { get; set; }
        public string? NewHomeSizeString { get; set; }

        public Property() {
            BrochureMap = new BrochureMap();
            CustomData = new CustomData();
            Location= new Location();
            Negotiator= new Negotiator();
            OpenViewings= new List<object>();
            VirtualViewings= new List<object>();
            Photos = new List<string>();
            TravelTimes= new List<object>();
            AuctionList = new List<object>();
            AdditionalLogoUrls = new List<string>();

        }
    }

}
