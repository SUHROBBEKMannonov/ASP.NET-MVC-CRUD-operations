using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FirstProjectWeb.Models
{
    public class FirstModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }


        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "email is faield")]
        public string Email { get; set; }

        [Required]
        [DisplayName("Phone Name")]
        [Range(1,10000000000, ErrorMessage ="Phone Number  length must be between 1 and 10 character only ")]
        public Int64 PhoneNumber { get; set; }

        [Required]
        [DisplayName("Birth of Date")]
        public DateTime BirthDate { get; set; }
        


    }
}
