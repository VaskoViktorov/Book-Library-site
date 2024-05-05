namespace Library.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;
    public class EmployeePhone
    {
        public int Id { get; set; }

        [Required]
        [MinLength(EmployeePhoneMinLengt)]
        [MaxLength(EmployeePhoneMaxLengt)]
        public string PhoneNumber { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        [Required]
        public Employee Employee { get; set; }
    }
}
