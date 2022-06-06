using System;

namespace Temporary1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string? strExpression;

            while (1 == 1)
            {
                Console.WriteLine("Введите выражение. Для выхода нажмите: Exit.");
                strExpression = Console.ReadLine();

                if (strExpression == "Exit" || strExpression == "exit")
                {
                    Console.WriteLine("Goodbye.");
                    break;
                }

                strExpression = strExpression.Replace(" ", ""); //Удаляем все пробелы.

                if (strExpression == "") //Если после удаления пробелов строка пустая, то error.
                {
                    Console.WriteLine("Вы не ввели значение.");
                    continue;
                }
                //Какой-то значимый текст точно введен, потому далее.


                if (strExpression.Contains("[") == true || strExpression.Contains("]") == true || strExpression.Contains("=") == true) //Проверяем на наличие скобок, которые в дальнейшем будут определять методы, и знака = (т.е. изначально быть скобок и знака = не должно).
                {
                    Console.WriteLine("Вы ввели не корректные данные.");
                    Console.WriteLine("");
                    continue;
                }

                /*
                //В этом блоке проверяем на некорректный ввод данных: ++ -* /* +- ...
                string[] arrstrOperator = new string[0];
                Array.Resize(ref arrstrOperator, 4);
                arrstrOperator[0] = "+";
                arrstrOperator[1] = "-";
                arrstrOperator[2] = "*";
                arrstrOperator[3] = "/";

                string strOperators = "";

                for (int int1 = 0; int1 <= arrstrOperator.Length - 1; int1++)
                {
                    for (int int2 = 0; int2 <= arrstrOperator.Length - 1; int2++)
                    {
                        strOperators = arrstrOperator[int1] + arrstrOperator[int2];

                        if (strExpression.Contains(strOperators) == true)
                        {
                            Console.WriteLine("Вы ввели не корректные данные.");
                            Console.WriteLine("");
                            continue;
                        }
                    }
                    if (strExpression.Contains(strOperators) == true)
                    {
                        continue;
                    }
                }
                */

                //------------------------------------------------------------------------------
                //Проверяем круглые скобки на парность.
                int intControlParentheses = 0; //Скобок 0.

                for (int int1 = 0; int1 <= strExpression.Length - 1; int1++)
                {
                    if (strExpression[int1] == '(')
                    {
                        intControlParentheses++;
                    }
                    else if (strExpression[int1] == ')')
                    {
                        intControlParentheses--;
                    }

                    if (intControlParentheses < 0)
                    {
                        Console.WriteLine("Вы ввели не корректные данные.");
                        Console.WriteLine("");
                        break;
                    }
                }

                if (intControlParentheses < 0)
                {
                    continue;
                }

                if (intControlParentheses > 0)
                {
                    Console.WriteLine("Вы ввели не корректные данные.");
                    Console.WriteLine("");
                    continue;
                }
                //------------------------------------------------------------------------------




                F_voiTextControl(ref strExpression); //Выполняем поиск функций введенных пользователем.

                //После названия каждой функции должна быть комбинация: ](
                bool booError = false;
                for (int int1 = 0; int1 <= strExpression.Length - 2; int1++)
                {
                    if (strExpression[int1] == ']')
                    {
                        if (strExpression[int1 + 1] != '(')
                        {
                            Console.WriteLine("Вы ввели не корректные данные.");
                            Console.WriteLine("");
                            booError = true;
                            break;

                        }
                    }
                }
                if (booError == true)
                {
                    booError = false;
                    continue;
                }






















                F_voiNumberControl(ref strExpression); //Выполняем поиск чисел.

                /*
                if (strExpression[0] == '/' || strExpression[0] == '*')
                {
                    Console.WriteLine("Вы ввели не корректные данные.");
                    Console.WriteLine("");
                    continue;
                }

                if (strExpression[0] == '+')
                {
                    strExpression = strExpression.Substring(0, 0); //Удаляем + в начале строки.
                }
                
                if (strExpression == "") //Если после удаления + строка пустая, то error.
                {
                    Console.WriteLine("Вы ввели не корректные данные.");
                    Console.WriteLine("");
                    continue;
                }
                */





                /*
                if (strExpression[0] == '-')
                {
                    strExpression = strExpression.Insert(0, "(");

                }
                */



                Console.WriteLine(strExpression);
                Console.WriteLine("");
            }
        }






        static void F_voiTextControl(ref string f_strExpression)
        {
            bool booControl = false; //т.е. не текст.

            for (int int1 = 0; int1 <= f_strExpression.Length - 1; int1++)
            {
                if (f_strExpression[int1] != '+' &&
                    f_strExpression[int1] != '-' &&
                    f_strExpression[int1] != '*' &&
                    f_strExpression[int1] != '/' &&
                    f_strExpression[int1] != ',' &&
                    f_strExpression[int1] != '.' &&
                    f_strExpression[int1] != '(' &&
                    f_strExpression[int1] != ')' &&
                    f_strExpression[int1] != '0' &&
                    f_strExpression[int1] != '1' &&
                    f_strExpression[int1] != '2' &&
                    f_strExpression[int1] != '3' &&
                    f_strExpression[int1] != '4' &&
                    f_strExpression[int1] != '5' &&
                    f_strExpression[int1] != '6' &&
                    f_strExpression[int1] != '7' &&
                    f_strExpression[int1] != '8' &&
                    f_strExpression[int1] != '9')
                {
                    if (booControl == false) //Если мы не в тексте.
                    {
                        booControl = true; //Заходим в текст.
                        f_strExpression = f_strExpression.Insert(int1, "[");
                    }
                }
                else
                {
                    if (booControl == true) //Если мы в тексте.
                    {
                        booControl = false; //Выходим из текста.
                        f_strExpression = f_strExpression.Insert(int1, "]");
                    }
                }
            }

            if (booControl == true) //Если мы в тексте.
            {
                booControl = false; //Выходим из текста.
                f_strExpression = f_strExpression + "]";
            }
        }



        static void F_voiNumberControl(ref string f_strExpression)
        {
            bool booControl = false; //т.е. не число.

            for (int int1 = 0; int1 <= f_strExpression.Length - 1; int1++)
            {
                if (f_strExpression[int1] == '.' ||
                    f_strExpression[int1] == '0' ||
                    f_strExpression[int1] == '1' ||
                    f_strExpression[int1] == '2' ||
                    f_strExpression[int1] == '3' ||
                    f_strExpression[int1] == '4' ||
                    f_strExpression[int1] == '5' ||
                    f_strExpression[int1] == '6' ||
                    f_strExpression[int1] == '7' ||
                    f_strExpression[int1] == '8' ||
                    f_strExpression[int1] == '9')
                {
                    if (booControl == false) //Если мы не в числе.
                    {
                        booControl = true; //Заходим в число.
                        f_strExpression = f_strExpression.Insert(int1, "(");
                    }
                }
                else
                {
                    if (booControl == true) //Если мы в числе.
                    {
                        booControl = false; //Выходим из числа.
                        f_strExpression = f_strExpression.Insert(int1, ")");
                    }
                }
            }

            if (booControl == true) //Если мы в числе.
            {
                booControl = false; //Выходим из числа.
                f_strExpression = f_strExpression + ")";
            }
        }














    }
}
