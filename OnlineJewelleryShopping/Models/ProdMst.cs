//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnlineJewelleryShopping.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProdMst
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProdMst()
        {
            this.CartLists = new HashSet<CartList>();
            this.ItemMsts = new HashSet<ItemMst>();
        }
    
        public int Prod_Id { get; set; }
        public string Prod_Type { get; set; }
        public string Prod_Img { get; set; }
        public int Prod_Qnt { get; set; }
        public int Prod_Price { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CartList> CartLists { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemMst> ItemMsts { get; set; }
    }
}