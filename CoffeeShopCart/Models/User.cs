//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CoffeeShopCart.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public string Name { get; set; }
        public string CoffeeType { get; set; }
        public string Drinkware { get; set; }
    
        public virtual User Users1 { get; set; }
        public virtual User User1 { get; set; }
    }
}
