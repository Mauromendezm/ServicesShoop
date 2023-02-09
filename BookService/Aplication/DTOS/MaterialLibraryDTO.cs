using System;

namespace BookService.Aplication.DTOS
{
    public class MaterialLibraryDTO
    {
        public Guid? MaterialLibreryId { get; set; }
        public string Title { get; set; }
        public DateTime? PublicationDate { get; set; }
        public Guid? AutorBook { get; set; }
    }
}
