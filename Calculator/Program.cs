using System;

namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Your attention is invited to a calculator that performs calculations of a line of the form:");  //Вашему вниманию предлагается калькулятор, выполняющий расчеты строки вида:
            Console.WriteLine("2*3+(18-12)/4+!(5)*Pow(2.3, 4) и т.д. (Press ENTER to get the result).");  //Для получения результата нажмите ENTER.
            Console.WriteLine("");
            Console.WriteLine("You have the following operators and functions in your arsenal:"); //Вы имеете в арсенале следующие операторы и функции:
            Console.WriteLine("+: addition operator."); //оператор сложения.
            Console.WriteLine("-: subtraction operator."); //оператор вычитания.
            Console.WriteLine("*: multiplication operator."); //оператор умножения.
            Console.WriteLine("/: division operator."); //оператор деления.
            Console.WriteLine("Abs(double value): Returns the absolute value for the argument value."); //возвращает абсолютное значение для аргумента value.
            Console.WriteLine("Acos(double value): returns the arc cosine of value. The value parameter must be between -1 and 1."); //возвращает арккосинус value.Параметр value должен иметь значение от -1 до 1.
            Console.WriteLine("Asin(double value): returns the arcsine of value. The value parameter must be between -1 and 1."); //возвращает арксинус value.Параметр value должен иметь значение от -1 до 1.
            Console.WriteLine("Atan(double value): returns the arc tangent of value."); //возвращает арктангенс value.
            Console.WriteLine("Cos(double d): returns the cosine of angle d."); //возвращает косинус угла d.
            Console.WriteLine("Cosh(double d): returns the hyperbolic cosine of angle d."); //возвращает гиперболический косинус угла d.
            Console.WriteLine("Exp(double d): returns the base of the natural logarithm raised to the power of d."); //возвращает основание натурального логарифма, возведенное в степень d.
            Console.WriteLine("Log(double d): returns the natural logarithm of d."); //возвращает натуральный логарифм числа d.
            Console.WriteLine("Log(double a, double newBase): returns the logarithm of a to the base newBase."); //возвращает логарифм числа a по основанию newBase.
            Console.WriteLine("Pow(double a, double b): returns the number a raised to the power b."); //возвращает число a, возведенное в степень b.
            Console.WriteLine("Round(double d): returns the number d rounded to the nearest whole number."); //возвращает число d, округленное до ближайшего целого числа.
            Console.WriteLine("Sin(double value): returns the sine of the angle value."); //возвращает синус угла value.
            Console.WriteLine("Sqrt(double value): returns the square root of value."); //возвращает квадратный корень числа value.
            Console.WriteLine("Tan(double value): returns the tangent of the angle value."); //возвращает тангенс угла value.
            Console.WriteLine("!(int value): returns the factorial of value."); //возвращает факториал числа value.
            Console.WriteLine("");
            

            while (1 == 1)
            {
                Console.WriteLine("Enter an expression. To exit, press: Exit."); //Введите выражение. Для выхода нажмите: Exit.


                string? strExpression = Console.ReadLine();

                if (strExpression == "Exit" || strExpression == "exit")
                {
                    Console.WriteLine("Goodbye.");
                    break;
                }


                //------------------------------------------------------------------------------
                strExpression = strExpression.Replace(" ", ""); //Удаляем все пробелы.


                //------------------------------------------------------------------------------
                if (strExpression == "") //Если после удаления пробелов строка пустая, то error.
                {
                    Console.WriteLine("You have not entered a value."); //Вы не ввели значение.
                    continue;
                }
                //Какой-то значимый текст точно введен, потому далее.


                //Проверяем наличие знака "=" в конце выражения.
                if (strExpression[strExpression.Length - 1] == '=')
                {
                    strExpression = strExpression.Remove(strExpression.Length - 1);
                }


                if (strExpression == "") //Если после удаления знака "=" строка пустая, то error.
                {
                    Console.WriteLine("You have not entered a value."); //Вы не ввели значение.
                    continue;
                }
                //Какой-то значимый текст точно введен, потому далее.
                
                
                //------------------------------------------------------------------------------
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


                //------------------------------------------------------------------------------
                //Проверяем на наличие скобок, которые в дальнейшем будут определять методы, и знака = (т.е. изначально быть скобок и знака = не должно).
                if (strExpression.Contains("[") == true || strExpression.Contains("]") == true || strExpression.Contains("{") == true || strExpression.Contains("}") == true || strExpression.Contains("=") == true)
                {
                    Console.WriteLine("You have entered incorrect data."); //Вы ввели не корректные данные.
                    Console.WriteLine("");
                    continue;
                }
                
                
                //------------------------------------------------------------------------------
                F_voiFunctionControlNumber(ref strExpression); //Выполняем поиск чисел.
                //Console.WriteLine(strExpression);


                F_voiFunctionControlHistory(ref strExpression); //Выполняем поиск введенных функций.
                //Console.WriteLine(strExpression);


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
                //Console.WriteLine(strExpression);


                F_voiFunctionControlFuture(ref strExpression); //Создаем функции /, *, +,-.
                Console.WriteLine("Calculation steps:"); //Этапы вычислений:
                Console.WriteLine(strExpression);


                //В этом блоке РЕШАЕМ все функции.
                bool booControlCalculationOfSimpleFunctions = true;
                bool booControlCalculationOfComplexFunctions = true;
                while (booControlCalculationOfSimpleFunctions == true || booControlCalculationOfComplexFunctions == true)
                {
                    booControlCalculationOfSimpleFunctions = F_booCalculationOfSimpleFunctions(ref strExpression); //Преобразование простых функций.
                    booControlCalculationOfComplexFunctions = F_booCalculationOfComplexFunctions(ref strExpression); //Преобразование сложных функций.
                }

                
                bool booControl = false;
                double dblExpression = 0;
                booControl = double.TryParse(strExpression, out dblExpression);
                if (booControl == false)
                {
                    Console.WriteLine("You have entered incorrect data."); //Вы ввели не корректные данные.
                    Console.WriteLine("");
                    continue;
                }
                else
                {
                    strExpression = strExpression.Replace(",", ".");

                    Console.WriteLine($"Result: {strExpression}"); //Результат:
                    Console.WriteLine("");
                }
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
            string strNumber = "";
            double dblNumber = 0;
            string strTransformedFunction = "";

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
                Console.WriteLine(strExpression);
                f_strExpression = strExpression;
                return (true);
            }
            else
            {
                return (false);
            }
        }


        static bool F_booCalculationOfComplexFunctions(ref string f_strExpression) //Выаделяем из функции имя и тело.
        {
            string strExpression = f_strExpression;

            int intStartBracket = 0;
            int intStopBracket = 0;

            string? strFunctionName = "";
            string? strFunctionBody = "";
            bool booControlFunctionName = false;
            bool booControlFunctionBody = false;

            string? strFunctionResult = "";

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
                    bool booControl = false;

                    booControl = F_booCalculationFunction(strFunctionName, strFunctionBody, ref strFunctionResult);

                    if (booControl == true)
                    {
                        strExpression = strExpression.Replace("[" + strFunctionName + "]{" + strFunctionBody + "}", strFunctionResult);
                    }
                }
            }

            if (f_strExpression != strExpression)
            {
                Console.WriteLine(strExpression);
                f_strExpression = strExpression;
                return (true);
            }
            else
            {
                return (false);
            }
        }

        
        static bool F_booCalculationFunction(in string f_strFunctionName, in string f_strFunctionBody, ref string f_strFunctionResult) //Решаем функцию.
        {
            bool booControl = false;
            double[] arrdblParameter = new double[0];
            double dblFunctionResult = 0;

            if (f_strFunctionName == "Addition") //(double, double): возвращает сумму двух чисел. 
            {
                booControl = F_booCalculationParameter(f_strFunctionBody, 2, ref arrdblParameter);
                if (booControl == false) //Если НЕ получилось преобразовать f_strFunctionBody в массив параметров.
                {
                    return (false);
                }

                dblFunctionResult = arrdblParameter[0] + arrdblParameter[1]; //Если получилось, то проводим расчеты.

                f_strFunctionResult = Convert.ToString(dblFunctionResult); //Конвертируем в строку и отправляем в f_strFunctionResult

                return (true);
            }
            else if (f_strFunctionName == "Subtraction")
            {
                booControl = F_booCalculationParameter(f_strFunctionBody, 2, ref arrdblParameter);
                if (booControl == false) //Если НЕ получилось преобразовать f_strFunctionBody в массив параметров.
                {
                    return (false);
                }

                dblFunctionResult = arrdblParameter[0] - arrdblParameter[1]; //Если получилось, то проводим расчеты.

                f_strFunctionResult = Convert.ToString(dblFunctionResult); //Конвертируем в строку и отправляем в f_strFunctionResult

                return (true);
            }
            else if (f_strFunctionName == "Multiplication")
            {
                booControl = F_booCalculationParameter(f_strFunctionBody, 2, ref arrdblParameter);
                if (booControl == false) //Если НЕ получилось преобразовать f_strFunctionBody в массив параметров.
                {
                    return (false);
                }

                dblFunctionResult = arrdblParameter[0] * arrdblParameter[1]; //Если получилось, то проводим расчеты.

                f_strFunctionResult = Convert.ToString(dblFunctionResult); //Конвертируем в строку и отправляем в f_strFunctionResult

                return (true);
            }
            else if (f_strFunctionName == "Division")
            {
                booControl = F_booCalculationParameter(f_strFunctionBody, 2, ref arrdblParameter);
                if (booControl == false) //Если НЕ получилось преобразовать f_strFunctionBody в массив параметров.
                {
                    return (false);
                }

                dblFunctionResult = arrdblParameter[0] / arrdblParameter[1]; //Если получилось, то проводим расчеты.

                f_strFunctionResult = Convert.ToString(dblFunctionResult); //Конвертируем в строку и отправляем в f_strFunctionResult

                return (true);
            }
            else if (f_strFunctionName == "Abs" || f_strFunctionName == "abs") //(double value): возвращает абсолютное значение для аргумента value
            {
                booControl = F_booCalculationParameter(f_strFunctionBody, 1, ref arrdblParameter);
                if (booControl == false) //Если НЕ получилось преобразовать f_strFunctionBody в массив параметров.
                {
                    return (false);
                }

                dblFunctionResult = Math.Abs(arrdblParameter[0]); //Если получилось, то проводим расчеты.

                f_strFunctionResult = Convert.ToString(dblFunctionResult); //Конвертируем в строку и отправляем в f_strFunctionResult

                return (true);
            }
            else if (f_strFunctionName == "Acos" || f_strFunctionName == "acos") //(double value): возвращает арккосинус value. Параметр value должен иметь значение от -1 до 1
            {
                booControl = F_booCalculationParameter(f_strFunctionBody, 1, ref arrdblParameter);
                if (booControl == false || arrdblParameter[0]<(-1) || arrdblParameter[0]>1) //Если НЕ получилось преобразовать f_strFunctionBody в массив параметров.
                {
                    return (false);
                }

                dblFunctionResult = Math.Acos(arrdblParameter[0]); //Если получилось, то проводим расчеты.

                f_strFunctionResult = Convert.ToString(dblFunctionResult); //Конвертируем в строку и отправляем в f_strFunctionResult

                return (true);
            }
            else if (f_strFunctionName == "Asin" || f_strFunctionName == "asin") //(double value): возвращает арксинус value.Параметр value должен иметь значение от -1 до 1
            {
                booControl = F_booCalculationParameter(f_strFunctionBody, 1, ref arrdblParameter);
                if (booControl == false || arrdblParameter[0] < (-1) || arrdblParameter[0] > 1) //Если НЕ получилось преобразовать f_strFunctionBody в массив параметров.
                {
                    return (false);
                }

                dblFunctionResult = Math.Asin(arrdblParameter[0]); //Если получилось, то проводим расчеты.

                f_strFunctionResult = Convert.ToString(dblFunctionResult); //Конвертируем в строку и отправляем в f_strFunctionResult

                return (true);
            }
            else if (f_strFunctionName == "Atan" || f_strFunctionName == "atan") //(double value): возвращает арктангенс value
            {
                booControl = F_booCalculationParameter(f_strFunctionBody, 1, ref arrdblParameter);
                if (booControl == false) //Если НЕ получилось преобразовать f_strFunctionBody в массив параметров.
                {
                    return (false);
                }

                dblFunctionResult = Math.Atan(arrdblParameter[0]); //Если получилось, то проводим расчеты.

                f_strFunctionResult = Convert.ToString(dblFunctionResult); //Конвертируем в строку и отправляем в f_strFunctionResult

                return (true);
            }
            else if (f_strFunctionName == "Cos" || f_strFunctionName == "cos") //(double d): возвращает косинус угла d
            {
                booControl = F_booCalculationParameter(f_strFunctionBody, 1, ref arrdblParameter);
                if (booControl == false) //Если НЕ получилось преобразовать f_strFunctionBody в массив параметров.
                {
                    return (false);
                }

                dblFunctionResult = Math.Cos(arrdblParameter[0]); //Если получилось, то проводим расчеты.

                f_strFunctionResult = Convert.ToString(dblFunctionResult); //Конвертируем в строку и отправляем в f_strFunctionResult

                return (true);
            }
            else if (f_strFunctionName == "Cosh" || f_strFunctionName == "cosh") //(double d): возвращает гиперболический косинус угла d
            {
                booControl = F_booCalculationParameter(f_strFunctionBody, 1, ref arrdblParameter);
                if (booControl == false) //Если НЕ получилось преобразовать f_strFunctionBody в массив параметров.
                {
                    return (false);
                }

                dblFunctionResult = Math.Cosh(arrdblParameter[0]); //Если получилось, то проводим расчеты.

                f_strFunctionResult = Convert.ToString(dblFunctionResult); //Конвертируем в строку и отправляем в f_strFunctionResult

                return (true);
            }
            else if (f_strFunctionName == "Exp" || f_strFunctionName == "exp") //(double d): возвращает основание натурального логарифма, возведенное в степень d
            {
                booControl = F_booCalculationParameter(f_strFunctionBody, 1, ref arrdblParameter);
                if (booControl == false) //Если НЕ получилось преобразовать f_strFunctionBody в массив параметров.
                {
                    return (false);
                }

                dblFunctionResult = Math.Exp(arrdblParameter[0]); //Если получилось, то проводим расчеты.

                f_strFunctionResult = Convert.ToString(dblFunctionResult); //Конвертируем в строку и отправляем в f_strFunctionResult

                return (true);
            }
            else if (f_strFunctionName == "Log" || f_strFunctionName == "log") //(double d): возвращает натуральный логарифм числа d
            {
                booControl = F_booCalculationParameter(f_strFunctionBody, 1, ref arrdblParameter);
                if (booControl == false) //Если НЕ получилось преобразовать f_strFunctionBody в массив параметров.
                {
                    return (false);
                }

                dblFunctionResult = Math.Log(arrdblParameter[0]); //Если получилось, то проводим расчеты.

                f_strFunctionResult = Convert.ToString(dblFunctionResult); //Конвертируем в строку и отправляем в f_strFunctionResult

                return (true);
            }
            else if (f_strFunctionName == "Log" || f_strFunctionName == "log") //(double a, double newBase): возвращает логарифм числа a по основанию newBase
            {
                booControl = F_booCalculationParameter(f_strFunctionBody, 2, ref arrdblParameter);
                if (booControl == false) //Если НЕ получилось преобразовать f_strFunctionBody в массив параметров.
                {
                    return (false);
                }

                dblFunctionResult = Math.Log(arrdblParameter[0], arrdblParameter[1]); //Если получилось, то проводим расчеты.

                f_strFunctionResult = Convert.ToString(dblFunctionResult); //Конвертируем в строку и отправляем в f_strFunctionResult

                return (true);
            }
            else if (f_strFunctionName == "Pow" || f_strFunctionName == "pow") //(double a, double b): возвращает число a, возведенное в степень b
            {
                booControl = F_booCalculationParameter(f_strFunctionBody, 2, ref arrdblParameter);
                if (booControl == false) //Если НЕ получилось преобразовать f_strFunctionBody в массив параметров.
                {
                    return (false);
                }

                dblFunctionResult = Math.Pow(arrdblParameter[0], arrdblParameter[1]); //Если получилось, то проводим расчеты.

                f_strFunctionResult = Convert.ToString(dblFunctionResult); //Конвертируем в строку и отправляем в f_strFunctionResult

                return (true);
            }
            else if (f_strFunctionName == "Round" || f_strFunctionName == "round") //(double d): возвращает число d, округленное до ближайшего целого числа
            {
                booControl = F_booCalculationParameter(f_strFunctionBody, 1, ref arrdblParameter);
                if (booControl == false) //Если НЕ получилось преобразовать f_strFunctionBody в массив параметров.
                {
                    return (false);
                }

                dblFunctionResult = Math.Round(arrdblParameter[0]); //Если получилось, то проводим расчеты.

                f_strFunctionResult = Convert.ToString(dblFunctionResult); //Конвертируем в строку и отправляем в f_strFunctionResult

                return (true);
            }
            else if (f_strFunctionName == "Sin" || f_strFunctionName == "sin") //(double value): возвращает синус угла value
            {
                booControl = F_booCalculationParameter(f_strFunctionBody, 1, ref arrdblParameter);
                if (booControl == false) //Если НЕ получилось преобразовать f_strFunctionBody в массив параметров.
                {
                    return (false);
                }

                dblFunctionResult = Math.Sin(arrdblParameter[0]); //Если получилось, то проводим расчеты.

                f_strFunctionResult = Convert.ToString(dblFunctionResult); //Конвертируем в строку и отправляем в f_strFunctionResult

                return (true);
            }
            else if (f_strFunctionName == "Sqrt" || f_strFunctionName == "sqrt") //(double value): возвращает квадратный корень числа value
            {
                booControl = F_booCalculationParameter(f_strFunctionBody, 1, ref arrdblParameter);
                if (booControl == false) //Если НЕ получилось преобразовать f_strFunctionBody в массив параметров.
                {
                    return (false);
                }

                dblFunctionResult = Math.Sqrt(arrdblParameter[0]); //Если получилось, то проводим расчеты.

                f_strFunctionResult = Convert.ToString(dblFunctionResult); //Конвертируем в строку и отправляем в f_strFunctionResult

                return (true);
            }
            else if (f_strFunctionName == "Tan" || f_strFunctionName == "tan") //(double value): возвращает тангенс угла value
            {
                booControl = F_booCalculationParameter(f_strFunctionBody, 1, ref arrdblParameter);
                if (booControl == false) //Если НЕ получилось преобразовать f_strFunctionBody в массив параметров.
                {
                    return (false);
                }

                dblFunctionResult = Math.Tan(arrdblParameter[0]); //Если получилось, то проводим расчеты.

                f_strFunctionResult = Convert.ToString(dblFunctionResult); //Конвертируем в строку и отправляем в f_strFunctionResult

                return (true);
            }
            else if (f_strFunctionName == "!") //(int value): возвращает факториал числа value
            {
                booControl = F_booCalculationParameter(f_strFunctionBody, 1, ref arrdblParameter);
                if (booControl == false || arrdblParameter[0]<=0 || (int)arrdblParameter[0]!= arrdblParameter[0]) //Если НЕ получилось преобразовать f_strFunctionBody в массив параметров.
                {
                    return (false);
                }

                dblFunctionResult = 1; //Если получилось, то проводим расчеты.
                for (int int1=1; int1<= arrdblParameter[0]; int1++)
                {
                    dblFunctionResult = dblFunctionResult * int1;
                }

                f_strFunctionResult = Convert.ToString(dblFunctionResult); //Конвертируем в строку и отправляем в f_strFunctionResult

                return (true);
            }
            return (false);
        }
        

        static bool F_booCalculationParameter(in string f_strFunctionBody, in int f_intCountParameter, ref double[] f_arrdblParameter)
        {
            string[]? arrstrParameter = new string[1];
            
            if (f_strFunctionBody.Length > 0)
            {
                for (int int1 = 0; int1 <= f_strFunctionBody.Length - 1; int1++)
                {
                    if (f_strFunctionBody[int1] == '.')
                    {
                        Array.Resize(ref arrstrParameter, arrstrParameter.Length + 1);
                    }
                    else
                    {
                        arrstrParameter[arrstrParameter.Length - 1] = arrstrParameter[arrstrParameter.Length - 1] + f_strFunctionBody[int1];
                    }
                }
            }
            
            bool booControl = false;
            
            if (arrstrParameter.Length != f_intCountParameter)
            {
                return (false);
            }

            f_arrdblParameter = new double[arrstrParameter.Length];

            for (int int1 = 0; int1 <= arrstrParameter.Length - 1; int1++)
            {
                booControl = double.TryParse(arrstrParameter[int1], out f_arrdblParameter[int1]);

                if (booControl == false)
                {
                    return (false);
                }
            }
            return (true);
        }
    }
}
