//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcOkul.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class TblNotlar
    {
        public int NotId { get; set; }
        public Nullable<int> DersId { get; set; }
        public Nullable<int> OgrId { get; set; }
        public Nullable<byte> Sinav1 { get; set; }
        public Nullable<byte> Sinav2 { get; set; }
        public Nullable<byte> Sinav3 { get; set; }
        public Nullable<byte> Proje { get; set; }
        public Nullable<decimal> Ortalama { get; set; }
        public Nullable<bool> Durum { get; set; }
    
        public virtual TblDersler TblDersler { get; set; }
        public virtual TblOgrenciler TblOgrenciler { get; set; }
    }
}
