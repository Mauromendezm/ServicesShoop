using System;
using System.Collections.Generic;

namespace CartService.Model
{
    public class SessionCart
    {
        public int SessionCartId { get; set; }
        public DateTime? CreatedDate{ get; set; }
        public ICollection<SessionCartDetail> DetailList { get; set; }
    }
}
