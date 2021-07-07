using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UMS.Models {
    public class User {
        public int UserID { get; set; }

        [Required]
        [MinLength(4, ErrorMessage = "Username Must be not less than 4 characters.")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [RegularExpression(@"(?=.*\d)(?=.*[$@$!%*?&])(?=.*[A-Z]).{8,}", ErrorMessage = "Password must be not less than 8 characters or numbers. and must contain at least one uppercase character, one number and one special character.")]
        public string Password { get; set; }

        [Required]
        [RegularExpression(@"^[A-Za-z].{5,}", ErrorMessage = "First name Must start with a character and not less than 5 characters.")]
        public string Firstname { get; set; }

        [Required]
        [RegularExpression(@"^[A-Za-z].{5,}", ErrorMessage = "Last name Must start with a character and not less than 5 characters.")]
        public string Lastname { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        [RegularExpression(@"^015(?=.*\d).{8,8}", ErrorMessage = "Must start with 010, 011, 012, 015 then 8 numbers")]
        public string Phonenumber { get; set; }

        [Required]
        public int Department { get; set; }

    }
}
