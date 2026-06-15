using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task22.Interfaces;

namespace task22.Repositories
{
    public class GenericRepository<T> where T : IHasId
    {
        private Stack<T> _items = new Stack<T>();
        public void Add(T entity)
        {
            _items.Push(entity);
        }
        public void Remove()
        {
            _items.Pop();
        }
        public T GetById(int id)
        {
          var item=  _items.FirstOrDefault(s => s.Id == id);
            return item;

        }
        public IEnumerable<T> GetAll()
        {
            return _items;
        }
        public IEnumerable<T> FindAll(Func<T,bool> finddelegate)
        {
            var items = _items.Where(finddelegate);
            return items;
        }

    }
}
