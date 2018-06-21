using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlytaloMVC.ViewModels
{
    public class SaunaVIewModel
    {
        public int SaunaId { get; set; }
        public bool SaunanTila { get; set; }
        public string SaunanNykyLampotila { get; set; }
        public Nullable<System.DateTime> SaunaStart { get; set; }
        public Nullable<System.DateTime> SaunaStop { get; set; }
        public string SaunanNimi { get; set; }
    }
}