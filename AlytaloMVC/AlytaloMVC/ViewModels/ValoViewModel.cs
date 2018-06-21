using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlytaloMVC.ViewModels
{
    public class ValoViewModel
    {
        public int ValoId { get; set; }
        public bool ValoOff { get; set; }
        public bool Valo33 { get; set; }
        public bool Valo66 { get; set; }
        public bool Valo100 { get; set; }
        public Nullable<System.DateTime> ValoOffAika { get; set; }
        public Nullable<System.DateTime> Valo33Aika { get; set; }
        public Nullable<System.DateTime> Valo66AIka { get; set; }
        public Nullable<System.DateTime> valo100Aika { get; set; }
        public string HuoneValo { get; set; }
    }
}