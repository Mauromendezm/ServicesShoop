using AutoMapper;
using BookService.Aplication;
using BookService.Aplication.DTOS;
using BookService.Model;
using BookService.Persistence;
using GenFu;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace BookTest
{
    public class BookServiceTest
    {

        private IEnumerable<MaterialLibrary> GetData()
        {
            A.Configure<MaterialLibrary>()
                .Fill(x => x.Title).AsArticleTitle()
                .Fill(x => x.MaterialLibreryId, () => { return Guid.NewGuid(); });

            var list = A.ListOf<MaterialLibrary>(30);
            list[0].MaterialLibreryId = Guid.Empty;
            return list;
        }

        private Mock<LibreryContext> creteContext()
        {
            var dataTest = GetData().AsQueryable();

            Mock<DbSet<MaterialLibrary>> dbset = new Mock<DbSet<MaterialLibrary>>();
            dbset.As<IQueryable<MaterialLibrary>>().Setup(x => x.Provider).Returns(dataTest.Provider);
            dbset.As<IQueryable<MaterialLibrary>>().Setup(x => x.Expression).Returns(dataTest.Expression);
            dbset.As<IQueryable<MaterialLibrary>>().Setup(x => x.ElementType).Returns(dataTest.ElementType);
            dbset.As<IQueryable<MaterialLibrary>>().Setup(x => x.GetEnumerator()).Returns(dataTest.GetEnumerator());

            dbset.As<IAsyncEnumerable<MaterialLibrary>>().Setup(x => x.GetAsyncEnumerator(new System.Threading.CancellationToken()))
                .Returns(new AsynEnumerator<MaterialLibrary>(dataTest.GetEnumerator()));

            dbset.As<IQueryable<MaterialLibrary>>().Setup(x => x.Provider).Returns(new AsynQueryProvider<MaterialLibrary>(dataTest.Provider));

            var context = new Mock<LibreryContext>();
            context.Setup(x => x.MaterialLibrary).Returns(dbset.Object);
            return context;
        }

        [Fact]
        public async void getBookById()
        {
            var mockContext = creteContext();
            // 2. Emular imaaper
            var mapConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingTest());
            });

            var mockMapper = mapConfig.CreateMapper();

            //3. Intanciar a la clase handler y pasarle como parametros los mocks

            ConsultFilter.Execute request = new ConsultFilter.Execute();
            request.MaterialLibreryId = Guid.Empty;

            ConsultFilter.Handler manejador = new ConsultFilter.Handler(mockContext.Object, mockMapper);


            var book = await manejador.Handle(request, new System.Threading.CancellationToken());

            Assert.NotNull(book);
            Assert.True(book.MaterialLibreryId == Guid.Empty);

        }

        [Fact]
        public async void GetBooks()
        {
            // 1 .emular las intancias ef core, context para la db
            // para emular acciones y eventos en ambiente trst, utilizamos objtos de tipo MOCK 
            var mockContext = creteContext();

            // 2. Emular imaaper
            var mapConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingTest());
            });

            var mockMapper = mapConfig.CreateMapper();

            //3. Intanciar a la clase handler y pasarle como parametros los mocks
            Consult.Handler handler = new Consult.Handler(mockContext.Object, mockMapper);

            Consult.Execute execute = new Consult.Execute();
            var list = await handler.Handle(execute, new System.Threading.CancellationToken());

            Assert.True(list.Any());

        }


        [Fact]
        public async void BookSave()
        {
            // Solo utilizar en un metodo, esta  linea de debugger
            System.Diagnostics.Debugger.Launch();

            var options = new DbContextOptionsBuilder<LibreryContext>()
                .UseInMemoryDatabase(databaseName: "BaseDatosLibrery")
                .Options;

            var context = new LibreryContext(options);


            New.Execute request = new New.Execute();
            request.Title = "Libreo de unitest";
            request.AutorBook = Guid.Empty;
            request.PublicationDate = DateTime.Now;

            New.Handler handler = new New.Handler(context);
            var result = await handler.Handle(request, new System.Threading.CancellationToken());

            Assert.True(result != null);

        }
    }
}
