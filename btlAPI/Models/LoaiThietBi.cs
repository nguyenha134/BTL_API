//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace btlAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class LoaiThietBi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LoaiThietBi()
        {
            this.ThietBiYTes = new HashSet<ThietBiYTe>();
        }
    
        public string MaLoai { get; set; }
        public string MaDanhMuc { get; set; }
        public string TenLoai { get; set; }
    
        public virtual DanhMuc DanhMuc { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThietBiYTe> ThietBiYTes { get; set; }
    }
}
