//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DatabaseFirstEntityFramework
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserBook
    {
        public int Id { get; set; }
        public int UserID { get; set; }
        public int BookID { get; set; }
    
        public virtual Book Book { get; set; }
        public virtual User User { get; set; }
    }
}
