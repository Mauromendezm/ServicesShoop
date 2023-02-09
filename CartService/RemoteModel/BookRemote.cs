using System;

namespace CartService.RemoteModel
{
    public class BookRemote
    {
        public Guid? MaterialLibreryId { get; set; }
        public string Title { get; set; }
        public DateTime PublicationDate { get; set; }
        public Guid? AutorBook { get; set; }
    }
}
