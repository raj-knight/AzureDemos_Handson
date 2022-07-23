using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Features
{
    internal static class GenericsMethod_Demo
    {
        // Generic Methods
        public static T[] Reverse<T>(T[] name) //where T : class  
        {
            var reverse = new T[name.Length];
            var length = name.Length;

            for (int i = 0; i < length; i++)
            {
                reverse[i] = name[length-1-i ];
            }
            return reverse;
        }

        
        //public static string[] Reverse(string[] name)
        //{
        //    var reverse = new string[name.Length ];
        //    var length = name.Length;

        //    for (int i = 0; i < name.Length; i++)
        //    {
        //        reverse[i] = name[length-1-i];
        //    }

        //    return reverse;
        //}

      
    }

    // Generic Class
    internal static class GenericsClass_Demo<T> //where T : class
    {
        
        public static T[] Reverse(T[] name) 
        {
            var reverse = new T[name.Length];
            var length = name.Length;

            for (int i = 0; i < length; i++)
            {
                reverse[i] = name[length - 1 - i];
            }
            return reverse;
        }

    }

    class KeyValue<TKey, TValue>
    {
        public TKey Key { get; set; }
        public TValue Value { get; set; }
    }
}
