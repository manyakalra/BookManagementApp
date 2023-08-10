using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Collections
{
    public static  class ListUtils
    {

        public static IIndexedList<X> AddAll<X>(this IIndexedList<X> list, params X[] values)
        {
            foreach(var x in values)
                list.Add(x);

            return list;
        }
        public static IIndexedList<O> Transform<I,O>(this IIndexedList<I> list, Func<I,O> converter)
        {
            var result = new LinkedList<O>();

            for(int i=0; i<list.Length;i++)
                result.Add(converter(list[i]));

            return result;
        }

        public static IIndexedList<X> FindAll<X>(this IIndexedList<X> list, Func<X,bool> matcher)
        {
            var result = new LinkedList<X>();
            for(int i=0;i<list.Length;i++)
                if(matcher(list[i]))
                    result.Add(list[i]);

            return result;
        }

        public static X FindOne<X>(this IIndexedList<X> list, Func<X,bool> matcher)
        {
            for (int i = 0; i < list.Length; i++)
                if (matcher(list[i]))
                    return list[i];

            return default(X);
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
