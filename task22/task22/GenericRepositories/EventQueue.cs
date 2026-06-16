using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task22.GenericRepositories
{
    public class EventQueue<T>:IEnumerable<T>
    {
        private Queue<T> items= new Queue<T>();
        public void Enqueue(T entity)
        {
            items.Enqueue(entity);
        }
        public T Dequeue()
        {
            return items.Dequeue();
        }
        public bool TryDequeue(out T entity)
        {
            if (items.Count == 0)
            {
                entity = default(T);
                return false;
            }
            entity = items.Dequeue();
            return true;
        }
        public int Count()
        {
            return items.Count;
        }
        // to omplement IEumerable so i can foreach by a class
        public IEnumerator<T> GetEnumerator() => items.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
      
       
    }
}
