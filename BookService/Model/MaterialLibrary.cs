using System;
using System.ComponentModel.DataAnnotations;

namespace BookService.Model
{
    public class MaterialLibrary
    {
        [Key]
        public Guid? MaterialLibreryId { get; set; }
        public string Title { get; set; }
        public DateTime? PublicationDate { get; set; }

        public Guid? AutorBook { get; set; }
    }
}
