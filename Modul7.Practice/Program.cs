//1.Создать класс с несколькими свойствами. Реализовать перегрузку операторов ==, != и Equals.
 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul_7
{
    using System;

    public class Product
    {
        public string Name { get; set; }
        public DateTime ExpirationDate { get; set; }

        public Product(string name, DateTime expirationDate)
        {
            Name = name;
            ExpirationDate = expirationDate;
        }

        public static bool operator ==(Product product1, Product product2)
        {
            // Сравнение  по названию и сроку годности
            return product1.Name == product2.Name && product1.ExpirationDate == product2.ExpirationDate;
        }

        public static bool operator !=(Product product1, Product product2)
        {
            return !(product1 == product2);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Product otherProduct = (Product)obj;
            return this == otherProduct;
        }

        public override int GetHashCode()
        {
            return (Name + ExpirationDate.ToString()).GetHashCode();
        }



        static void Main()
        {
            Product product1 = new Product("Apple", new DateTime(2023, 10, 19));
            Product product2 = new Product("Apple", new DateTime(2023, 09, 19));
            Product product3 = new Product("Banana", new DateTime(2023, 10, 20));


            Console.WriteLine("product1 == product2: " + (product1 == product2));
            Console.WriteLine("product1 == product3: " + (product1 == product3));


            Console.WriteLine("product1 != product2: " + (product1 != product2));
            Console.WriteLine("product1 != product3: " + (product1 != product3));


            Console.WriteLine("product1.Equals(product2): " + product1.Equals(product2));
            Console.WriteLine("product1.Equals(product3): " + product1.Equals(product3));
        }
    }
}
/*
//2.Дан класс содержащий внутри себя массив. Реализовать перегрузку операторов < , > так, чтобы если сумма элементов массива 1 класса больше, возвращалось значение true и наоборот.
 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul_7
{
    class RandomArr
    {
        private int[] array;

        public RandomArr(int length)
        {
            array = new int[length];
            Random rand = new Random();

            for (int i = 0; i < length; i++)
            {
                array[i] = rand.Next(1, 100);
            }
        }

        public static bool operator <(RandomArr container1, RandomArr container2)
        {
            return container1.GetSum() < container2.GetSum();
        }

        public static bool operator >(RandomArr container1, RandomArr container2)
        {
            return container1.GetSum() > container2.GetSum();
        }

        private int GetSum()
        {
            int sum = 0;
            foreach (int value in array)
            {
                sum += value;
            }
            return sum;
        }

        static void Main()
        {
            RandomArr container1 = new RandomArr(5);
            RandomArr container2 = new RandomArr(5);

            Console.WriteLine("container1 > container2: " + (container1 > container2));
            Console.WriteLine("container1 < container2: " + (container1 < container2));
        }
    }
}
//Esep 3.
 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul7
{

    class MyArray
    {
        private int[] array;

        public MyArray(int[] array)
        {
            this.array = array;
        }

        public int this[int index]
        {
            get
            {
                if (index >= 0 && index < array.Length)
                {
                    return array[index];
                }
                throw new IndexOutOfRangeException("Index:");
            }
            set
            {
                if (index >= 0 && index < array.Length)
                {
                    array[index] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException("Index:");
                }
            }
        }

        public int Length
        {
            get { return array.Length; }
        }

        public static MyArray operator *(MyArray array1, MyArray array2)
        {
            if (array1.Length != array2.Length)
            {
                throw new InvalidOperationException("Ne odinakovaya dlinna ");
            }

            int[] result = new int[array1.Length];
            for (int i = 0; i < array1.Length; i++)
            {
                result[i] = array1[i] * array2[i];
            }

            return new MyArray(result);
        }

        public static bool operator ==(MyArray array1, MyArray array2)
        {
            if (array1.Length != array2.Length)
            {
                return false;
            }

            for (int i = 0; i < array1.Length; i++)
            {
                if (array1[i] != array2[i])
                {
                    return false;
                }
            }

            return true;
        }

        public static bool operator !=(MyArray array1, MyArray array2)
        {
            return !(array1 == array2);
        }

        public static bool operator <=(MyArray array1, MyArray array2)
        {
            if (array1.Length != array2.Length)
            {
                throw new InvalidOperationException("Ne odinakovaya dlinna ");
            }

            int sum1 = 0;
            int sum2 = 0;
            for (int i = 0; i < array1.Length; i++)
            {
                sum1 += array1[i];
                sum2 += array2[i];
            }

            return sum1 <= sum2;
        }


        static void Main()
        {
            int[] data1 = { 1, 2, 3 };
            int[] data2 = { 4, 5, 6 };
            int[] data3 = { 1, 2, 3 };

            MyArray array1 = new MyArray(data1);
            MyArray array2 = new MyArray(data2);
            MyArray array3 = new MyArray(data3);

            MyArray result = array1 * array2;
            Console.WriteLine("array1 * array2: " + string.Join(", ", result));

            Console.WriteLine("array1 == array2: " + (array1 == array2));
            Console.WriteLine("array1 == array3: " + (array1 == array3));

            Console.WriteLine("array1 <= array2: " + (array1 <= array2));
        }
    }

}
//4.Класс – одномерный массив. Дополнительно перегрузить следующие операции: * – умножение массивов; [] – доступ по индексу, int() – размер массива; == – проверка на равенство; <= – сравнение
  using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul7
{
    using System;

    class MyArray
    {
        private int[] array;

        public MyArray(int[] array)
        {
            this.array = array;
        }

        public int this[int index]
        {
            get
            {
                if (index >= 0 && index < array.Length)
                {
                    return array[index];
                }
                throw new IndexOutOfRangeException("Index:");
            }
            set
            {
                if (index >= 0 && index < array.Length)
                {
                    array[index] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException("Index:");
                }
            }
        }

        public int Length
        {
            get { return array.Length; }
        }

        public static bool operator ==(MyArray array1, MyArray array2)
        {
            if (array1.Length != array2.Length)
            {
                return false;
            }

            for (int i = 0; i < array1.Length; i++)
            {
                if (array1[i] != array2[i])
                {
                    return false;
                }
            }

            return true;
        }

        public static bool operator !=(MyArray array1, MyArray array2)
        {
            return !(array1 == array2);
        }

        public static MyArray operator +(MyArray array1, MyArray array2)
        {
            int[] newArray = new int[array1.Length + array2.Length];
            array1.array.CopyTo(newArray, 0);
            array2.array.CopyTo(newArray, array1.Length);

            return new MyArray(newArray);
        }

        static void Main()
        {
            int[] data1 = { 1, 2, 3 };
            int[] data2 = { 4, 5, 6 };
            int[] data3 = { 1, 2, 3 };

            MyArray array1 = new MyArray(data1);
            MyArray array2 = new MyArray(data2);
            MyArray array3 = new MyArray(data3);

            MyArray result = array1 + array2;
            Console.WriteLine("array1 + array2: " + string.Join(", ", result));

            Console.WriteLine("array1 == array2: " + (array1 == array2));
            Console.WriteLine("array1 != array2: " + (array1 != array2));
        }
    }

}
//5.Класс – одномерный массив. Дополнительно перегрузить следующие операции: [] – доступ по индексу; == – проверка на равенство; != – проверка на неравенство; + – объединение массивов
 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul7
{
    struct Complex
    {
        public double Real { get; }
        public double Imaginary { get; }

        public Complex(double real, double imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }

        public static Complex operator +(Complex a, Complex b)
        {
            return new Complex(a.Real + b.Real, a.Imaginary + b.Imaginary);
        }

        public static Complex operator -(Complex a, Complex b)
        {
            return new Complex(a.Real - b.Real, a.Imaginary - b.Imaginary);
        }

        public static Complex operator *(Complex a, Complex b)
        {
            double real = a.Real * b.Real - a.Imaginary * b.Imaginary;
            double imaginary = a.Real * b.Imaginary + a.Imaginary * b.Real;
            return new Complex(real, imaginary);
        }

        public static Complex operator /(Complex a, Complex b)
        {
            double denominator = b.Real * b.Real + b.Imaginary * b.Imaginary;
            double real = (a.Real * b.Real + a.Imaginary * b.Imaginary) / denominator;
            double imaginary = (a.Imaginary * b.Real - a.Real * b.Imaginary) / denominator;
            return new Complex(real, imaginary);
        }

        public static explicit operator Complex(double real)
        {
            return new Complex(real, 0);
        }

        public override string ToString()
        {
            return $"{Real} + {Imaginary}i";
        }

        public override bool Equals(object obj)
        {
            if (obj is Complex other)
            {
                return Real == other.Real && Imaginary == other.Imaginary;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Real.GetHashCode() ^ Imaginary.GetHashCode();
        }

        public static bool operator ==(Complex a, Complex b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(Complex a, Complex b)
        {
            return !a.Equals(b);
        }

        static void Main()
        {
            Complex complex1 = new Complex(2, 3);
            Complex complex2 = new Complex(1, 1);

            Complex sum = complex1 + complex2;
            Complex difference = complex1 - complex2;
            Complex product = complex1 * complex2;
            Complex quotient = complex1 / complex2;

            Console.WriteLine("Sum: " + sum);
            Console.WriteLine("Difference: " + difference);
            Console.WriteLine("Product: " + product);
            Console.WriteLine("Quotient: " + quotient);

            Complex complex3 = (Complex)5.5;
            Console.WriteLine("Double to Complex: " + complex3);

            Console.WriteLine("Complex1 == Complex2: " + (complex1 == complex2));
            Console.WriteLine("Complex1 != Complex2: " + (complex1 != complex2));
        }
    }


}
//Esep 6 
using System;

namespace MyDecimalNamespace
{
    public class MyDecimal
    {
        private const int ArraySize = 100;
        private char[] digits;

        public MyDecimal()
        {
            digits = new char[ArraySize];
        }

        public MyDecimal(string value)
        {
            if (value.Length > ArraySize)
            {
                throw new ArgumentException("Input value is too large for the decimal representation.");
            }

            digits = new char[ArraySize];
            for (int i = 0; i < value.Length; i++)
            {
                if (!char.IsDigit(value[i]))
                {
                    throw new ArgumentException("Invalid character in input string.");
                }
                digits[ArraySize - value.Length + i] = value[i];
            }
        }

        public override string ToString()
        {
            return new string(digits).TrimStart('0');
        }

        public static MyDecimal operator +(MyDecimal a, MyDecimal b)
        {
            MyDecimal result = new MyDecimal();
            int carry = 0;
            for (int i = ArraySize - 1; i >= 0; i--)
            {
                int sum = (a.digits[i] - '0') + (b.digits[i] - '0') + carry;
                result.digits[i] = (char)((sum % 10) + '0');
                carry = sum / 10;
            }
            return result;
        }

        public static MyDecimal operator -(MyDecimal a, MyDecimal b)
        {
            MyDecimal result = new MyDecimal();
            int borrow = 0;
            for (int i = ArraySize - 1; i >= 0; i--)
            {
                int diff = (a.digits[i] - '0') - (b.digits[i] - '0') - borrow;
                if (diff < 0)
                {
                    diff += 10;
                    borrow = 1;
                }
                else
                {
                    borrow = 0;
                }
                result.digits[i] = (char)(diff + '0');
            }
            return result;
        }

        public static MyDecimal operator *(MyDecimal a, MyDecimal b)
        {
            // Реализация умножения двух объектов MyDecimal
            return new MyDecimal();
        }

        public static MyDecimal operator /(MyDecimal a, MyDecimal b)
        {
            // Реализация деления двух объектов MyDecimal
            return new MyDecimal();
        }
    }
}
using System;

namespace MyDecimalNamespace
{
    class Program
    {
        static void Main(string[] args)
        {
            MyDecimal a = new MyDecimal("1234");
            MyDecimal b = new MyDecimal("567");

            Console.WriteLine($"a: {a.ToString()}");
            Console.WriteLine($"b: {b.ToString()}");

            MyDecimal sum = a + b;
            MyDecimal difference = a - b;

            Console.WriteLine($"Sum: {sum.ToString()}");
            Console.WriteLine($"Difference: {difference.ToString()}");
        }
    }
}

*/
