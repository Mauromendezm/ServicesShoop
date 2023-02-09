using System;

namespace CartService.Aplication.DTOS
{
    public class SessionCartDTO
    {
        public Guid? LibroId { get; set; }
        public string TitleBook { get; set; }
        public AutorDTO AutorBook { get; set; }
        public DateTime PublicationDate { get; set; }
    }
}
