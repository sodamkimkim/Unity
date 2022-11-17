using System;

namespace ConstraintsOnTypeParameters
{
    class StructArray<T> where T : struct
    {
        public T[] Array { get; set; }
    }
    class RefArray<T> where T : class
    {

    }
    class Base { }
    class Derived : Base { }
    class BaseArray<U> where U : Base
    {

    }

    class MainApp
    {
        static void Main(string[] args)
        {
      
        }
    }
}
