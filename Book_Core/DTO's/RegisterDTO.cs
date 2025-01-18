using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Core.DTO_s
{
    public class RegisterDTO
    {
        [Required] 
        public string Username { get; set; }
        [Required]
        
        public string Password { get; set; }
        [Required]

        public int Gov_Code { get; set; }
        [Required]

        public int City_Code { get; set; }
        [Required]

        public int Zone_Code { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]

        public int Cus_ClassId { get; set; }
      
    }
}
