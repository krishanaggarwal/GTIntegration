//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NaGreenWebApi
{
    using System;
    using System.Collections.Generic;
    
    public partial class Game_Round
    {
        public Game_Round()
        {
            this.Transactions = new HashSet<Transaction>();
        }
    
        public long RoundId { get; set; }
        public int UserId { get; set; }
        public long Stake { get; set; }
        public Nullable<long> Win { get; set; }
        public Nullable<long> BalanceChange { get; set; }
        public string ReferenceId { get; set; }
        public System.DateTime StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
    
        public virtual User User { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}