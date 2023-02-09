using System;

namespace CartService.Model
{
    public class SessionCartDetail
    {
        public int SessionCartDetailId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string Product { get; set; }

        public int SessionCartId { get; set; }

        public SessionCart SessionCart { get; set; }
    }
}
