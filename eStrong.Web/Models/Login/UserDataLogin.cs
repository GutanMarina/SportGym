using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eStrong.Web.Models.Login
{
    public class UserDataLogin
    {
        [Required]
        [Display(Name = "Username")]
        [StringLength(30)]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [StringLength(50)]
        public string Password { get; set; }

    }
}