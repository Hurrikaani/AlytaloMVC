using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlytaloMVC.ViewModels
{
    public class LampotilaViewModel
    {
        public int LampoId { get; set; }
        public string TalonTavoiteLampotila { get; set; }
        public string TalonNykyLampotila { get; set; }
        public Nullable<System.DateTime> LampotilaAsetettu { get; set; }
    }
}