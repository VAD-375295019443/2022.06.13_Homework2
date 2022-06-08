using System;

namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string? strExpression = null;

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



                for (int int1 = 0; int1 <= strExpression.Length - 1; int1++)
                {
                    if (strExpression[int1] == '.')
                    {
                        strExpression = strExpression.Remove(int1, 1);
                        strExpression = strExpression.Insert(int1, ",");
                    }
                    else if (strExpression[int1] == ',')
                    {
                        strExpression = strExpression.Remove(int1, 1);
                        strExpression = strExpression.Insert(int1, ".");
                    }
                }



                //Проверяем на наличие скобок, которые в дальнейшем будут определять методы, и знака = (т.е. изначально быть скобок и знака = не должно).
                if (strExpression.Contains("[") == true || strExpression.Contains("]") == true || strExpression.Contains("{") == true || strExpression.Contains("}") == true || strExpression.Contains("=") == true)
                {
                    Console.WriteLine("Вы ввели не корректные данные.");
                    Console.WriteLine("");
                    continue;
                }

                /*
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
                */

                //------------------------------------------------------------------------------
                //------------------------------------------------------------------------------
                //------------------------------------------------------------------------------
                //------------------------------------------------------------------------------




                F_voiFunctionControlNumber(ref strExpression); //Выполняем поиск чисел.


                F_voiFunctionControlHistory(ref strExpression); //Выполняем поиск введенных функций.


                //Корректируем начало строки.
                if (strExpression.Length > 1 && strExpression[1] == '(')
                {
                    if (strExpression[0] == '+')
                    {
                        strExpression = strExpression.Remove(0, 1);
                    }
                    else if (strExpression[0] == '-')
                    {
                        strExpression = strExpression.Remove(0, 1);
                        strExpression = strExpression.Insert(0, "(-1)*");
                    }
                }


                F_voiFunctionControlFuture(ref strExpression); //Создаем функции /, *, +,-.


                bool booControlCalculationOfSimpleFunctions = true;
                while (booControlCalculationOfSimpleFunctions == true)
                {
                    booControlCalculationOfSimpleFunctions = F_booCalculationOfSimpleFunctions(ref strExpression); //Преобразование простых функций.
                }





                bool booControlCalculationOfComplexFunctions = true;
                //while (booControlCalculationOfComplexFunctions == true)
                //{
                booControlCalculationOfComplexFunctions = F_booCalculationOfComplexFunctions(ref strExpression); //Преобразование сложных функций.
                //}











                Console.WriteLine(strExpression);
                Console.WriteLine("");


                /*
                string xx = Console.ReadLine();
                bool z = false;
                double zz;
                z = double.TryParse(xx, out zz);
                
                Console.WriteLine(zz);
                */
            }
        }










        static void F_voiFunctionControlNumber(ref string f_strExpression)
        {
            bool booControl = false; //т.е. не число.

            for (int int1 = 0; int1 <= f_strExpression.Length - 1; int1++)
            {
                if (f_strExpression[int1] == ',' ||
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
                        int1 = int1 + 1;
                    }
                }
                else
                {
                    if (booControl == true) //Если мы в числе.
                    {
                        booControl = false; //Выходим из числа.
                        f_strExpression = f_strExpression.Insert(int1, ")");
                        int1 = int1 + 1;
                    }
                }
            }

            if (booControl == true) //Если мы в числе.
            {
                booControl = false; //Выходим из числа.
                f_strExpression = f_strExpression + ")";
            }
        }


        static void F_voiFunctionControlHistory(ref string f_strExpression)
        {
            bool booControlNameFunction = false; //т.е. не текст.

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
                    f_strExpression[int1] != '[' &&
                    f_strExpression[int1] != ']' &&
                    f_strExpression[int1] != '{' &&
                    f_strExpression[int1] != '}' &&
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
                    if (booControlNameFunction == false) //Если мы не в тексте.
                    {
                        booControlNameFunction = true; //Заходим в текст.
                        f_strExpression = f_strExpression.Insert(int1, "([");
                        int1 = int1 + 2;
                    }
                }
                else
                {
                    if (booControlNameFunction == true) //Если мы в тексте.
                    {
                        booControlNameFunction = false; //Выходим из текста.

                        if (f_strExpression[int1] == '(')
                        {
                            bool booResult = false;
                            int intStopBracket = 0;

                            booResult = F_booRightBracketPosition(f_strExpression, int1, ref intStopBracket);

                            if (booResult == true)
                            {
                                f_strExpression = f_strExpression.Remove(intStopBracket, 1);
                                f_strExpression = f_strExpression.Insert(intStopBracket, "})");

                                f_strExpression = f_strExpression.Remove(int1, 1);
                                f_strExpression = f_strExpression.Insert(int1, "]{");
                            }
                            else
                            {
                                f_strExpression = f_strExpression.Insert(int1, "]{})");
                            }
                        }
                        else
                        {
                            f_strExpression = f_strExpression.Insert(int1, "]{})");
                        }
                    }
                }
            }

            //Обработка конца строки.
            if (booControlNameFunction == true) //Если мы в тексте.
            {
                f_strExpression = f_strExpression + "]{})";
            }
        }


        static void F_voiFunctionControlFuture(ref string f_strExpression) //Пересмотреть по поводу -3.
        {
            bool booResult = false; //booResult затенен (просто другого варианта у него нет).
            int intStopBracket = 0;

            for (int int1 = 1; int1 <= f_strExpression.Length - 2; int1++) //от 1 до -2 т.к. проверяем )/(.
            {
                if (f_strExpression[int1] == '/')
                {
                    if (f_strExpression[int1 - 1] == ')' && f_strExpression[int1 + 1] == '(')
                    {
                        f_strExpression = f_strExpression.Remove(int1, 1);
                        f_strExpression = f_strExpression.Insert(int1, ".");

                        booResult = false;
                        intStopBracket = 0;

                        booResult = F_booRightBracketPosition(f_strExpression, int1, ref intStopBracket);
                        if (booResult == true)
                        {
                            f_strExpression = f_strExpression.Remove(intStopBracket, 1);
                            f_strExpression = f_strExpression.Insert(intStopBracket, ")})");
                        }

                        booResult = F_booLeftBracketPosition(f_strExpression, int1, ref intStopBracket);
                        if (booResult == true)
                        {
                            f_strExpression = f_strExpression.Insert(intStopBracket, "([Division]{");
                        }
                    }
                }
                else if (f_strExpression[int1] == '*')
                {
                    if (f_strExpression[int1 - 1] == ')' && f_strExpression[int1 + 1] == '(')
                    {
                        f_strExpression = f_strExpression.Remove(int1, 1);
                        f_strExpression = f_strExpression.Insert(int1, ".");

                        booResult = false;
                        intStopBracket = 0;

                        booResult = F_booRightBracketPosition(f_strExpression, int1, ref intStopBracket);
                        if (booResult == true)
                        {
                            f_strExpression = f_strExpression.Remove(intStopBracket, 1);
                            f_strExpression = f_strExpression.Insert(intStopBracket, ")})");
                        }

                        booResult = F_booLeftBracketPosition(f_strExpression, int1, ref intStopBracket);
                        if (booResult == true)
                        {
                            f_strExpression = f_strExpression.Insert(intStopBracket, "([Multiplication]{");
                        }
                    }
                }
            }
            for (int int1 = 1; int1 <= f_strExpression.Length - 2; int1++)
            {
                if (f_strExpression[int1] == '+')
                {
                    if (f_strExpression[int1 - 1] == ')' && f_strExpression[int1 + 1] == '(')
                    {
                        f_strExpression = f_strExpression.Remove(int1, 1);
                        f_strExpression = f_strExpression.Insert(int1, ".");

                        booResult = false;
                        intStopBracket = 0;

                        booResult = F_booRightBracketPosition(f_strExpression, int1, ref intStopBracket);
                        if (booResult == true)
                        {
                            f_strExpression = f_strExpression.Remove(intStopBracket, 1);
                            f_strExpression = f_strExpression.Insert(intStopBracket, ")})");
                        }

                        booResult = F_booLeftBracketPosition(f_strExpression, int1, ref intStopBracket);
                        if (booResult == true)
                        {
                            f_strExpression = f_strExpression.Insert(intStopBracket, "([Addition]{");
                        }
                    }
                }
                else if (f_strExpression[int1] == '-')
                {
                    if (f_strExpression[int1 - 1] == ')' && f_strExpression[int1 + 1] == '(')
                    {
                        f_strExpression = f_strExpression.Remove(int1, 1); //Удаляем -
                        f_strExpression = f_strExpression.Insert(int1, "."); //Заменяем - на ,

                        booResult = false;
                        intStopBracket = 0;

                        booResult = F_booRightBracketPosition(f_strExpression, int1, ref intStopBracket);
                        if (booResult == true)
                        {
                            f_strExpression = f_strExpression.Remove(intStopBracket, 1);
                            f_strExpression = f_strExpression.Insert(intStopBracket, ")})");
                        }

                        booResult = F_booLeftBracketPosition(f_strExpression, int1, ref intStopBracket);
                        if (booResult == true)
                        {
                            f_strExpression = f_strExpression.Insert(intStopBracket, "([Subtraction]{");
                        }
                    }
                }
            }
        }


        static bool F_booRightBracketPosition(in string f_strExpression, in int f_intStartBracket, ref int f_intStopBracket)
        {
            int intCountBracket = 0; //т.е. скобок нет.
            bool booControlBracket = false; //Контроль вхождения в зону открытия скобок.

            for (int int1 = f_intStartBracket; int1 <= f_strExpression.Length - 1; int1++)
            {
                if (f_strExpression[int1] == '(')
                {
                    if (booControlBracket == false) //Если скобок еще не было.
                    {
                        booControlBracket = true; //Регистрируем скобку (т.е. скобки все таки есть).
                    }

                    intCountBracket++; //Плюсуем одну (.
                }
                else if (f_strExpression[int1] == ')')
                {
                    intCountBracket--; //Минусуем одну ).
                }

                if (booControlBracket == true && intCountBracket == 0)
                {
                    f_intStopBracket = int1;
                    return (true); //Ошибок нет.
                }
            }
            return (false); //Метод закончен с ошибками.
        }


        static bool F_booLeftBracketPosition(in string f_strExpression, in int f_intStartBracket, ref int f_intStopBracket)
        {
            int intCountBracket = 0; //т.е. скобок нет.
            bool booControlBracket = false; //Контроль вхождения в зону открытия скобок.

            for (int int1 = f_intStartBracket; int1 >= 0; int1--)
            {
                if (f_strExpression[int1] == ')')
                {
                    if (booControlBracket == false) //Если скобок еще не было.
                    {
                        booControlBracket = true; //Регистрируем скобку (т.е. скобки все таки есть).
                    }

                    intCountBracket++; //Плюсуем одну ).
                }
                else if (f_strExpression[int1] == '(')
                {
                    intCountBracket--; //Минусуем одну (.
                }

                if (booControlBracket == true && intCountBracket == 0)
                {
                    f_intStopBracket = int1;
                    return (true); //Ошибок нет.
                }
            }
            return (false); //Метод закончен с ошибками.
        }


        static bool F_booCalculationOfSimpleFunctions(ref string f_strExpression)
        {
            string strExpression = f_strExpression;

            bool booResult = false;
            int intStartBracket = 0;
            int intStopBracket = 0;
            string strNumber = null;
            double dblNumber = 0;
            string strTransformedFunction = null;

            for (int int1 = 0; int1 <= strExpression.Length - 1; int1++)
            {
                if (strExpression[int1] == '(')
                {
                    intStartBracket = int1;
                    intStopBracket = 0;

                    booResult = F_booRightBracketPosition(strExpression, intStartBracket, ref intStopBracket);

                    if (booResult == true)
                    {
                        strNumber = strExpression.Substring(intStartBracket + 1, intStopBracket - intStartBracket - 1); //Берем кусок текста без скобок.

                        booResult = double.TryParse(strNumber, out dblNumber);
                        if (booResult == true)
                        {
                            strTransformedFunction = Convert.ToString(dblNumber);
                            strNumber = "(" + strNumber + ")";
                            strExpression = strExpression.Replace(strNumber, strTransformedFunction);
                        }
                    }
                }
            }

            if (f_strExpression != strExpression)
            {
                f_strExpression = strExpression;
                return (true);
            }
            else
            {
                return (false);
            }
        }


        static bool F_booCalculationOfComplexFunctions(ref string f_strExpression)
        {
            string strExpression = f_strExpression;

            int intStartBracket = 0;
            int intStopBracket = 0;

            string? strFunctionName = null;
            string? strFunctionBody = null;
            bool booControlFunctionName = false;
            bool booControlFunctionBody = false;

            for (int int1 = 0; int1 <= strExpression.Length - 1; int1++)
            {
                strFunctionName = null;
                booControlFunctionName = false;

                strFunctionBody = null;
                booControlFunctionBody = false;

                if (strExpression[int1] == '[') //Блок поиска [] скобок.
                {
                    intStartBracket = int1;

                    for (int int2 = int1 + 1; int2 <= strExpression.Length - 1; int2++)
                    {
                        if (strExpression[int2] == ']')
                        {
                            intStopBracket = int2;
                            strFunctionName = strExpression.Substring(intStartBracket + 1, intStopBracket - intStartBracket - 1); //Врезаем имя функции. Берем кусок текста без скобок.
                            booControlFunctionName = true;
                            break;
                        }
                    }

                    for (int int2 = int1 + 1; int2 <= strExpression.Length - 1; int2++)
                    {
                        if (strExpression[int2] == '{')
                        {
                            intStartBracket = int2;

                            for (int int3 = int2 + 1; int3 <= strExpression.Length - 1; int3++)
                            {
                                if (strExpression[int3] == '}')
                                {
                                    intStopBracket = int3;
                                    strFunctionBody = strExpression.Substring(intStartBracket + 1, intStopBracket - intStartBracket - 1); //Врезаем имя функции. Берем кусок текста без скобок.
                                    booControlFunctionBody = true;
                                    break;
                                }
                                else if (strExpression[int3] == '{')
                                {
                                    break;
                                }
                            }
                            break;
                        }
                    }
                }



                if (booControlFunctionName = true && booControlFunctionBody == true)
                {



                }






                ///////Обработка имени и тела функции.




                if (booControlFunctionName = true && booControlFunctionBody == true)
                {
                    Console.WriteLine(strFunctionName);
                    Console.WriteLine(strFunctionBody);
                }
            }

            if (f_strExpression != strExpression)
            {
                f_strExpression = strExpression;
                return (true);
            }
            else
            {
                return (false);
            }
        }






        static bool F_booCalculationFunction(in string f_strFunctionName, in string f_strFunctionBody, ref string f_strFunction)
        {
            if (f_strFunctionName == "Addition")
            {

            }
            else if (f_strFunctionName == "Subtraction")
            {

            }
            else if (f_strFunctionName == "Division")
            {






            }
            else if (f_strFunctionName == "Multiplication")
            {







                /*
                +

                -

                *

                /

                Abs(double value): возвращает абсолютное значение для аргумента value

                Acos(double value): возвращает арккосинус value.Параметр value должен иметь значение от -1 до 1

                Asin(double value): возвращает арксинус value.Параметр value должен иметь значение от -1 до 1

                Atan(double value): возвращает арктангенс value

                Cos(double d): возвращает косинус угла d

                Cosh(double d): возвращает гиперболический косинус угла d

                Exp(double d): возвращает основание натурального логарифма, возведенное в степень d

                Log(double d): возвращает натуральный логарифм числа d

                Log(double a, double newBase): возвращает логарифм числа a по основанию newBase

                Log10(double d): возвращает десятичный логарифм числа d

                Pow(double a, double b): возвращает число a, возведенное в степень b

                Round(double d): возвращает число d, округленное до ближайшего целого числа

                Sin(double value): возвращает синус угла value

                Sqrt(double value): возвращает квадратный корень числа value

                Tan(double value): возвращает тангенс угла value

                !(int value): возвращает факториал числа value
                */


            }
            
            return (true);
        }





    }
}
