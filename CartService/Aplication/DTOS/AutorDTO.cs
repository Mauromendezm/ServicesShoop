using System;

namespace CartService.Aplication.DTOS
{
    public class AutorDTO
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public DateTime? BirthDate { get; set; }
        public string AutorBookGuid { get; set; }
    }
}
