using System.Collections.Generic;

namespace GetPropertyNameViaLinq
{
    public class LinkedListWithInit<T> : LinkedList<T>
    {
        public void Add( T item )
        {
            ((ICollection<T>)this).Add(item);
        }
    }
}