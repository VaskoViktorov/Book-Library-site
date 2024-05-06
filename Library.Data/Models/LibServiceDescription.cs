namespace Library.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;
    public class LibServiceDescription
    {
        public int Id { get; set; }

        [Required]
        [MinLength(ServiceTypeMinLength)]
        [MaxLength(ServiceTypeMaxLength)]
        public string ServiceTypeBg { get; set; }

        [Required]
        [MinLength(ServiceTypeMinLength)]
        [MaxLength(ServiceTypeMaxLength)]
        public string ServiceTypeEn { get; set; }

        [MaxLength(DescriptionMaxLength)]
        public string DescriptionBg { get; set; }

        [MaxLength(DescriptionMaxLength)]
        public string DescriptionEn { get; set; }

        [MaxLength(PriceInfoMaxLength)]
        public string PriceInfoBg { get; set; }

        [MaxLength(PriceInfoMaxLength)]
        public string PriceInfoEn { get; set; }

        [Required]
        public int Order { get; set; }

        [Required]
        public int LibServiceTypeId { get; set; }

        [Required]
        public LibServiceType LibServiceType { get; set; }
    }
}
