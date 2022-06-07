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


//!!!!!!!!!!!!!!!!!!!!!!!!


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

                //Console.WriteLine(strExpression);






                if (strExpression.Contains("[") == true || strExpression.Contains("]") == true || strExpression.Contains("{") == true || strExpression.Contains("}") == true || strExpression.Contains("=") == true) //Проверяем на наличие скобок, которые в дальнейшем будут определять методы, и знака = (т.е. изначально быть скобок и знака = не должно).
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

                F_voiNumberControl(ref strExpression); //Выполняем поиск чисел.


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
                        strExpression =  strExpression.Insert(0, "(-1)*");
                    }
                }


                F_voiFunctionControlFuture(ref strExpression); //Создаем функции /, *, +,-.

                
                bool booControlCalculationOfSimpleFunctions = true;
                while (booControlCalculationOfSimpleFunctions == true)
                {
                    booControlCalculationOfSimpleFunctions = F_booCalculationOfSimpleFunctions(ref strExpression); //Преобразование простых функций.
                }
                



                
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





        static void F_voiCalculationOfComplexFunctions(ref string f_strExpression)
        {
        }




        static void F_voiNumberControl(ref string f_strExpression)
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
                    if (f_strExpression[int1-1] == ')' && f_strExpression[int1+1] == '(')
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
            string strFunction = null;
            double dblNumber = 0.0;
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
                        strFunction = strExpression.Substring(intStartBracket + 1, intStopBracket - intStartBracket - 1); //Берем кусок текста без скобок.
                        
                        booResult = double.TryParse(strFunction, out dblNumber);
                        if (booResult == true)
                        {
                            strTransformedFunction = Convert.ToString(dblNumber);
                            strFunction = "(" + strFunction + ")";
                            strExpression = strExpression.Replace(strFunction, strTransformedFunction);
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






    }
}
