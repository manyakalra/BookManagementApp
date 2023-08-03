using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Collections
{
    public static  class ListUtils
    {
        public static IIndexedList<O> Transform<I,O>(this IIndexedList<I> list, Func<I,O> converter)
        {
            var result = new LinkedList<O>();

            for(int i=0; i<list.Length;i++)
                result.Add(converter(list[i]));

            return result;
        }

        public static void ForEach<I>(this IIndexedList<I> list, Action<I> action)
        {
            list.ForEach((x, i) => action(x));
        }

        public static void ForEach<I>(this IIndexedList<I> list, Action<I,int> action)
        {
            for (int i = 0; i < list.Length; i++)
                action(list[i],i);
        }

    }
}
