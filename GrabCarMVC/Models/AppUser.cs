//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GrabCarMVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class AppUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string TypeName { get; set; }
        public Nullable<int> RoleId { get; set; }
        public string UpdateCardBy { get; set; }
        public Nullable<System.DateTime> UpdateCardDate { get; set; }
    }
}
