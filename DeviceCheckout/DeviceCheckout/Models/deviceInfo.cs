//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DeviceCheckout.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class deviceInfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public deviceInfo()
        {
            this.orderInfo = new HashSet<orderInfo>();
        }
    
        public int serialId { get; set; }
        public int devicePresetId { get; set; }
        public int zoneId { get; set; }
        public string imgUrl { get; set; }
        public string specialSw { get; set; }
        public string description { get; set; }
        public string os { get; set; }
        public string model { get; set; }
        public string ram { get; set; }
        public string status { get; set; }
    
        public virtual zone zone { get; set; }
        public virtual devicePreset devicePreset { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<orderInfo> orderInfo { get; set; }
    }
}
