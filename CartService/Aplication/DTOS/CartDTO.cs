using System;
using System.Collections.Generic;

namespace CartService.Aplication.DTOS
{
    public class CartDTO
    {
        public int CartId { get; set; }
        public DateTime? CreatedDateSession { get; set; }
        public List<SessionCartDTO> LIstDetail { get; set; }
    }
}
