using System;
using System.Threading.Tasks;
using CartService.RemoteModel;

namespace CartService.RemoteInterface
{
    public interface IBookService
    {
        Task<(bool result, BookRemote book, string msgError)> GetLibro(Guid libroId);
    }
}
