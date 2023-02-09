using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookTest
{
    public class AsynEnumerator<T> : IAsyncEnumerator<T>
    {
        private readonly IEnumerator<T> _enumerator;

        public T Current => _enumerator.Current;
        public AsynEnumerator(IEnumerator<T> enumerator)
            => _enumerator = enumerator
            ?? throw new ArgumentNullException(nameof(enumerator));
      

        public async ValueTask DisposeAsync()
        {
            await Task.CompletedTask;
        }

        public async ValueTask<bool> MoveNextAsync()
        {
            return await Task.FromResult(_enumerator.MoveNext());
        }
    }
}
