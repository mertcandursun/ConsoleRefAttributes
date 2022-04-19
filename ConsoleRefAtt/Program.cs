using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRefAtt
{
    class Program
    {
        static void Main(string[] args)
        {
            Person per1 = new Person()
            {
                Name = "Mert",
                Age = 22,
            };

            Console.WriteLine(Control.check(per1));

            Console.ReadKey();
        }
    }

    public class Person
    {
        [Required]
        public string Id;
        [Required]
        public string Name;
        [Required]
        public int Age;
    }

    public class RequiredAttribute : Attribute
    {

    }

    public static class Control
    {
        public static bool check(Person per)
        {
            Type type = per.GetType();
            foreach (var items in type.GetFields())
            {
                object[] attribute = items.GetCustomAttributes(typeof(RequiredAttribute), true);
                if (attribute.Length != 0)
                {
                    object value = items.GetValue(per);

                    if (value == null)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
