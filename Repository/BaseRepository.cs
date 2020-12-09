using Microsoft.EntityFrameworkCore;

using System.Linq;
using System.Collections.Generic;

namespace solidInCsharp.Repository
{
    public abstract class BaseRepository<T,K> : DbContext where T : class  where K : BaseRepository<T,K>
    {
        public BaseRepository(DbContextOptions<K> options)
			: base(options)
		{ }

		protected DbSet<T> Items { get; set; }

		public void Add(T item) {
			this.Items.Add(item);
			this.SaveChanges();
		}

		public void Remove(T item) {
			this.Items.Remove(item);
		}

		public IEnumerable<T> ListAll() {
			return this.Items.ToArray();
		}

		
		public IQueryable<T> Query() {
			return this.Items.AsQueryable();
		}

		public void Update(T item) {
			this.Items.Update(item);
			this.SaveChanges();
		}


    }
}