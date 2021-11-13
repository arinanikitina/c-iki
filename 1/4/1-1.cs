using System;
using System.Collections;
using System.Collections.Generic;

namespace Z1
{
    public class Animal : IComparable<Animal>
    {
        public int Age;
        public string Name;

        /*public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            Animal AnimalSort = obj as Animal;
            if (AnimalSort != null)
            {
                return this.Age.CompareTo(AnimalSort.Age);
            }
            else
                throw new ArgumentException("Object isn't an age");
        }*/

        public int CompareTo(Animal an)
        {
            if (an == null)
            {
                return 1;
            }
            else
            {
                return this.Age.CompareTo(an.Age);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Animal> Animals = new List<Animal>();
            Animals.Add(new Animal() { Age = 4, Name = "sheep" });
            Animals.Add(new Animal() { Age = 3, Name = "pig" });
            Animals.Add(new Animal() { Age = 8, Name = "goat" });
            Animals.Add(new Animal() { Age = 7, Name = "goose" });
            Animals.Add(new Animal() { Age = 5, Name = "ram" });

            foreach (Animal animal in Animals)
            {
                Console.WriteLine("Name: " + animal.Name + " | Age: " + animal.Age);
            }

            /*ArrayList Animals = new ArrayList();

            Animals.Add(new Animal() { Age = 4, Name = "sheep" });
            Animals.Add(new Animal() { Age = 3, Name = "pig" });
            Animals.Add(new Animal() { Age = 3, Name = "goat" });
            Animals.Add(new Animal() { Age = 5, Name = "ram" });
            Animals.Add(new Animal() { Age = 7, Name = "goose" });

            foreach (Animal animal in Animals)
            {
                Console.WriteLine("Name: " + animal.Name + " | Age: " + animal.Age);
            }

            try
            {
                Animals.Sort();
            }
            catch (System.InvalidOperationException e)
            {
                Console.WriteLine("\nСбой при сравнении двух элементов массива.
                По крайней мере в одном объекте должен быть реализован интерфейс IComparable", e.Message);
            }*/

            /* ArrayList.Sort();
               System.InvalidOperationException
               Сбой при сравнении двух элементов массива.
               ArgumentException: По крайней мере в одном объекте должен быть реализован интерфейс IComparable. */

            try
            {
                Animals.Sort();
            }
            catch (System.InvalidOperationException e)
            {
                Console.WriteLine("\nСбой при сравнении двух элементов массива", e.Message);
            }

            Console.WriteLine("\nSorted by age:");

            foreach (Animal animal in Animals)
            {
                Console.WriteLine("Name: " + animal.Name + " | Age: " + animal.Age);
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
