using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AlytaloMVC.ViewModels
{
    public class UserDataViewModel
    {
        public int UserId { get; set; }
        [Required(ErrorMessage = "Kenttä ei saa olla tyhjä")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Kenttä ei saa olla tyhjä")]
        [StringLength(100, ErrorMessage = "Salasanan täytyy olla vähintään 6 merkkiä pitkä", MinimumLength = 6)]
        public string Password { get; set; }

    }
}