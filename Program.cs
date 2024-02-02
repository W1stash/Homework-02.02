using System;

namespace makarov_task
{
    public abstract class Parent
    {
        public Random rnd = new Random();

        protected dynamic array;
        protected dynamic length;
        protected dynamic columns;

        public Parent(int a)
        {
            array = new int[a];
            length = a;
        }

        public int this[int i]
        {
            set
            {
                array[i] = value;
            }
            get
            {
                return array[i];
            }
        }

        public virtual void Initialize()
        {            
            for (int i = 0; i < length; i++)
            {
                array[i] = rnd.Next(-150, 150);
            }
        }

        public virtual void Avg()
        {
            double sum = 0;
            for (int i = 0; i < length; i++)
            {
                sum += array[i];
            }
            Console.Write(sum/length);
        }

        public virtual void Show()
        {
            foreach (int el in array)
            {
                Console.Write(el + " ");
            }
            Console.WriteLine();
        }

        public virtual void Maximum()
        {
            int max = array[0];
            for (int i = 1; i < length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                }
            }
            Console.Write(max);
        }

        public virtual void Minimum()
        {
            int min = array[0];
            for (int i = 1; i < length; i++)
            {
                if (array[i] < min)
                {
                    min = array[i];
                }
            }
            Console.Write(min);
        }
    }

    public sealed class OneDimensionalChild : Parent
    {
        public OneDimensionalChild(int a) : base(a)
        {
            array = new int[a];
            length = a;
        }

        public override void Initialize()
        {
            base.Initialize();
            Console.WriteLine("Массив инициализиован!");
        }

        public override void Avg()
        {
            Console.Write("Среднее число в массиве:");
            base.Avg();
            Console.WriteLine();
        }

        public override void Show()
        {
            Console.WriteLine("Ваш массив: ");
            base.Show();
        }

        public override void Maximum()
        {
            Console.Write("Максимальное число: ");
            base.Maximum();
            Console.WriteLine();
        }

        public override void Minimum()
        {
            Console.Write("Минимальное число: ");
            base.Minimum();
            Console.WriteLine();
        }
    }

    public sealed class TwoDimensionalChild : Parent
    {
        public TwoDimensionalChild(int a, int b) : base(a)
        {
            array = new int[a, b];
            length = a;
            columns = b;
        }

        public override void Initialize()
        {
            for(int p = 0; p < length; p++)
            {
                for(int i = 0; i < columns; i++)
                {
                    array[p, i] = rnd.Next(-150, 150);
                }
            }
            Console.WriteLine("Двумерный массив инициализирован!");
        }

        public override void Show()
        {
            Console.WriteLine("Ваш массив:");
            for (int p = 0; p < length; p++)
            {
                for (int i = 0; i < columns; i++)
                {
                    Console.Write($"{array[p, i]}   ");
                }
                Console.WriteLine();
            }          
        }

        public override void Avg()
        {
            double sum = 0;
            for (int p = 0; p < length; p++)
            {
                for (int i = 0; i < columns; i++)
                {
                    sum += array[p, i];
                }                
            }
            Console.WriteLine($"Максимальное число в вашем массиве: {sum / length}");
        }

        public override void Minimum()
        {
            int min = array[0,0];
            for (int p = 0; p < length; p++)
            {
                for (int i = 0; i < columns; i++)
                {
                    if(array[p, i] < min)
                    {
                        min = array[p, i];
                    }
                }                
            }
            Console.WriteLine($"Максимальное число в вашем массиве: {min}");
        }

        public override void Maximum()
        {
            int max = array[0,0];
            for (int p = 0; p < length; p++)
            {
                for (int i = 0; i < columns; i++)
                {
                    if (array[p, i] > max)
                    {
                        max = array[p, i];
                    }
                }                
            }
            Console.WriteLine($"Максимальное число в вашем массиве: {max}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите желаемую длину вашего массива:");
            int c = int.Parse(Console.ReadLine());

            OneDimensionalChild array = new OneDimensionalChild(c);
            array.Initialize();
            array.Show();

            array.Avg();
            array.Maximum();
            array.Minimum();

            Console.WriteLine("Введите желаемое количество стобцов вашего массива:");
            int c1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите желаемую длину вашего массива:");
            int k1 = int.Parse(Console.ReadLine());

            TwoDimensionalChild array2 = new TwoDimensionalChild(c1, k1);

            array2.Initialize();
            array2.Show();

            array2.Avg();
            array2.Maximum();
            array2.Minimum();

            Console.ReadKey();
        }
    }
}