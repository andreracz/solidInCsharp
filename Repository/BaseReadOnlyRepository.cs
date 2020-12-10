using Microsoft.EntityFrameworkCore;

using System.Linq;
using System.Collections.Generic;

namespace solidInCsharp.Repository
{
    public abstract class BaseReadOnlyRepository<T,K> : DbContext where T : class  where K : BaseReadOnlyRepository<T,K>
    {
        public BaseReadOnlyRepository(DbContextOptions<K> options)
			: base(options)
		{ }

		protected DbSet<T> Items { get; set; }


		public IEnumerable<T> ListAll() {
			return this.Items.ToArray();
		}

		
		public IQueryable<T> Query() {
			return this.Items.AsQueryable();
		}


    }
}