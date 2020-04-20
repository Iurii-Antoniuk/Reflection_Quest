using System;
using System.Reflection;
using System.Collections.Generic;

namespace Reflection_quest
{
    class Program
    {
        static void Main(string[] args)
        {
            var jimbo = new Person();
            jimbo.SayHello();

            var inspector = new ClassInspector(jimbo);

            var props = inspector.GetAllProperties();
            inspector.PrintCollection(props);

            var fields = inspector.GetAllFields();
            inspector.PrintCollection(fields);

            var methods = inspector.GetAllMethods();
            inspector.PrintCollection(methods);
        }
    }

    public class ClassInspector
    {
        private Object _obj;
        private Type _type;
        
        public ClassInspector(Object obj)
        {
            _obj = obj;
            _type = _obj.GetType();
        }

        public PropertyInfo[] GetAllProperties()
        {
            PropertyInfo[] props = _type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            Console.WriteLine("Properties:");
            return props;
        }

        public FieldInfo[] GetAllFields()
        {
            FieldInfo[] fields = _type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            Console.WriteLine("Fields:");
            return fields;
        }

        public MethodInfo[] GetAllMethods()
        {
            MethodInfo[] methods = _type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            Console.WriteLine("Methods:");
            return methods;
        }

        public void PrintCollection<T>(IEnumerable<T> entries)
        {
            foreach (var entry in entries)
            {
                Console.WriteLine($"\t {entry}");
            }
            Console.WriteLine();
        }
    }
    
    public class Person
    {
        private Int32 _pornhubSubscriberNumber;
        public String Name { get; set; }
        private String Nickname { get; set; }

        public Person()
        {
            _pornhubSubscriberNumber = 45;
            Name = "Jimbo";
            Nickname = "Le Grand";
        }
        public void SayHello()
        {
            Console.WriteLine("Hi there! I like watching gay porn all day long.");
        }

        private void GetPremiumSubscriberNumber()
        {
            _pornhubSubscriberNumber = 666;
        }
    }
}
