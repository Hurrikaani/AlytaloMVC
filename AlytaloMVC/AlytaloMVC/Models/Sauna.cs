//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AlytaloMVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Sauna
    {
        public int SaunaId { get; set; }
        public bool SaunanTila { get; set; }
        public string SaunanNykyLampotila { get; set; }
        public Nullable<System.DateTime> SaunaStart { get; set; }
        public Nullable<System.DateTime> SaunaStop { get; set; }
        public string SaunanNimi { get; set; }
    }
}
