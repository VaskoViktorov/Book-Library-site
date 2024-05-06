namespace Library.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;
    public class LibServiceType
    {
        public int Id { get; set; }

        [Required]
        [MinLength(LibServiceTypeMinLength)]
        [MaxLength(LibServiceTypeMaxLength)]
        public string ServiceNameBg { get; set; }

        [Required]
        [MinLength(LibServiceTypeMinLength)]
        [MaxLength(LibServiceTypeMaxLength)]
        public string ServiceNameEn { get; set; }

        [Required]
        public int Order { get; set; }

        public List<LibServiceDescription> LibServiceDescriptions { get; set; } = new List<LibServiceDescription>();

    }
}
