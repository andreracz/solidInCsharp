using System.Collections.Generic;

namespace solidInCsharp.Repository
{
    public interface IReadWriteRepository<T>: IReadRepository<T>, IWriteRepository<T> where T : class  
    {

    }
}