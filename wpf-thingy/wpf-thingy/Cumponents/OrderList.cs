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
    
    public partial class OrderList
    {
        public int Id { get; set; }
        public Nullable<int> ProductId { get; set; }
        public Nullable<int> Amount { get; set; }
        public Nullable<decimal> TotalPrice { get; set; }
    
        public virtual Product Product { get; set; }
    }
}
