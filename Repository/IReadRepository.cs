using System.Collections.Generic;

namespace solidInCsharp.Repository
{
    public interface IReadRepository<T> where T : class  
    {

		public IEnumerable<T> ListAll();

    }
}