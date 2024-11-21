using System;

namespace Proj
{ 
class Calc
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите 'exit' для выхода:");
        Console.WriteLine("Введите 'help' для вызова помощи:");
        while (true)
        {
            Console.Write("Введите операцию:");
            string input = Console.ReadLine();
            if (input.ToLower() == "help")
            {
                Console.WriteLine("Введите первое число, затем нажмите ПРОБЕЛ, полсе " +
                    "введите знак операции (+,-,*,/,%,^) + ПРОБЕЛ, затем второе число и ENTER");  
            }

            if (input.ToLower() == "exit")
            {
                break; 
            }

            string[] parts = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length != 3)
            {
                continue;
            }

            string value1 = parts[0];
            string sign = parts[1];
            string value2 = parts[2];

            if (!int.TryParse(value1, out int num1) || !int.TryParse(value2, out int num2))
            {
                Console.WriteLine("Одно из введенных значений не является числом.");
                continue; // Возврат к началу цикла
            }

            int result = 0;

            switch (sign)
            {
                case "+":
                    result = Sum(num1, num2);
                    break;

                case "-":
                    result = Minus(num1, num2);
                    break;

                case "*":
                    result = Multi(num1, num2);
                    break;

                case "/":
                    result = Divide(num1, num2);
                    break;
                case "%":
                     result = RemainderFromDivision(num1, num2);
                    break;
                case "^":
                    result = Convert.ToInt32(Exponentiation(num1, num2));
                    break;

                default:
                    Console.WriteLine("Неизвестный оператор.");
                    continue; // Возврат к началу цикла
            }

            Console.WriteLine($"{value1} {sign} {value2} = {result}");
        }
    }

    static int Sum(int a, int b) => a + b;

    static int Minus(int a, int b) => a - b;

    static int Multi(int a, int b) => a * b;

    static int Divide(int a, int b)
    {
        if (b == 0)
        {
            Console.WriteLine("На ноль делить нельзя.");
            return 0; 
        }
        return a / b;
    }
    static int RemainderFromDivision(int a, int b) => a % b;
    static long Exponentiation(long a, long b)
    {
        double baseNumber = a;
        double exponent = b;

        double result = Math.Pow(baseNumber, exponent);

        
        if (result > long.MaxValue || result < long.MinValue)
        {
            throw new OverflowException("Результат превышает диапазон типа long.");
        }

        long y = Convert.ToInt64(result);
        return y;
    }

    
}
}
