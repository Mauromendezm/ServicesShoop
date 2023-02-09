using AutoMapper;
using BookService.Aplication.DTOS;
using BookService.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookTest
{
    public class MappingTest :  Profile
    {
        public MappingTest()
        {
            CreateMap<MaterialLibrary, MaterialLibraryDTO>();
        }
    }
}
