using System;

//Створення динамічного масиву, додавання елементів в масив, видалення першого внесеного елементу та підрахунок кількості елементів в масиві

namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.Write("Enter array size: ");

            int arraySize = Convert.ToInt32(Console.ReadLine());

            GenericClass<int> genericClass = new GenericClass<int>(arraySize);

            int[] array = new int[arraySize];

            Console.WriteLine("\nEnter array elements: ");

            for (int i = 0; i < arraySize; i++)
            { 
                Console.Write($"Element [{i + 1}]: ");
                array[i] = Convert.ToInt32(Console.ReadLine());
            }
            genericClass.ArrayFill(array);

            genericClass.ArraySize();

            Console.WriteLine($"First element in Array is {genericClass.GettingElementByIndex(0)}");

            Console.WriteLine($"\nArray: ");

            for (int i = 0; i < arraySize; i++)
            {
                Console.Write($"{genericClass.tTypeArray[i]}  ");
            }
            Console.WriteLine();

            genericClass.RemoveElementFromArray(0);

            Console.WriteLine($"\nNew Array without first element: ");

            for (int i = 0; i < arraySize - 1; i++)
            {
                Console.Write($"{genericClass.newTTypeArray[i]}  ");
            }

            Console.WriteLine();

            genericClass.NewArraySize();

            Console.ReadKey();
        }
    }


    class GenericClass<T>
    {
        public T[] tTypeArray;
        public T[] newTTypeArray;

        public void ArrayFill(T[] element)
        {
            for (int i = 0; i < tTypeArray.Length; i++)
            {
                tTypeArray[i] = element[i];
            }
        }

        public void ArraySize()
        {
            Console.WriteLine($"\nArray size is {tTypeArray.Length}");
        }

        public void NewArraySize()
        {
            Console.WriteLine($"\nNew array size is {newTTypeArray.Length}");
        }

        public T GettingElementByIndex(int index)
        {
            return tTypeArray[index];
        }

        public void RemoveElementFromArray(int index)
        {
            for (int i = 0, g = 0; g < tTypeArray.Length; i++, g++)
            {
                if (g == index)
                {
                    i--;
                    continue;
                }
                else
                {
                    newTTypeArray[i] = tTypeArray[g];
                }
            }
        }

        public GenericClass(int size)
        {
            tTypeArray = new T[size];
            newTTypeArray = new T[size - 1];
        }
    }
}