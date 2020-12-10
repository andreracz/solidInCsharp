using Microsoft.EntityFrameworkCore;

using System.Linq;
using System.Collections.Generic;

namespace solidInCsharp.Repository
{
    public abstract class BaseRepository<T,K> : BaseReadOnlyRepository<T,K> where T : class  where K : BaseRepository<T,K>
    {
        public BaseRepository(DbContextOptions<K> options)
			: base(options)
		{ }

		public void Add(T item) {
			this.Items.Add(item);
			this.SaveChanges();
		}

		public void Remove(T item) {
			this.Items.Remove(item);
		}

		public void Update(T item) {
			this.Items.Update(item);
			this.SaveChanges();
		}


    }
}