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
    
    public partial class UserRegMst
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UserRegMst()
        {
            this.Invoices = new HashSet<Invoice>();
        }
    
        public int userId { get; set; }
        public string userFname { get; set; }
        public string userLname { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string mobNo { get; set; }
        public string emailID { get; set; }
        public System.DateTime dob { get; set; }
        public System.DateTime cdate { get; set; }
        public string password { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}