//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace wpf_thingy.Cumponents
{
    using System;
    using System.Collections.Generic;
    
    public partial class ZakazPosition
    {
        public int Id { get; set; }
        public Nullable<int> IdOrder { get; set; }
        public Nullable<int> IdZakaz { get; set; }
    
        public virtual OrderList OrderList { get; set; }
        public virtual ZakazList ZakazList { get; set; }
    }
}