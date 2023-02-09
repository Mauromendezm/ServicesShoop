using System;
using System.Collections.Generic;

namespace AutorService.Model
{
    public class AutorBook
    {
        public int AutorBookId { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public DateTime? BirthDate { get; set; }
        public ICollection<AcademicDegree> ListAcademicDegree { get; set; }
        public string AutorBookGuid { get; set; }
    }
}
