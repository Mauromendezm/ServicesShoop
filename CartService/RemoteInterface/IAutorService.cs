using CartService.RemoteModel;
using System.Threading.Tasks;

namespace CartService.RemoteInterface
{
    public interface IAutorService
    {
        Task<(bool result, AutorRemote autor, string msgError)> GetAutor(string autorId);
    }
}
