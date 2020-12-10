using System.Collections.Generic;

namespace solidInCsharp.Repository
{
    public interface IWriteRepository<T> where T : class  
    {

		public void Add(T item);
		public void Remove(T item);
		public void Update(T item);

    }
}