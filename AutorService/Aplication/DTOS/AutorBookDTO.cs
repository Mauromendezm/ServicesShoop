using AutorService.Model;
using System.Collections.Generic;
using System;

namespace AutorService.DTOS
{
    public class AutorBookDTO
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public DateTime? BirthDate { get; set; }
        public string AutorBookGuid { get; set; }
    }
}
