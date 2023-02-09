using System;

namespace AutorService.Model
{
    public class AcademicDegree
    {
        public int AcademicDegreeId { get; set; }
        public string Name { get; set; }
        public string AcademicCenter { get; set; }
        public DateTime DegreeDate { get; set; }
        public int AutorBookId { get; set; }
        public AutorBook AutorBook { get; set; }
        public string AcademicDegreeGuid { get; set; }
    }
}
