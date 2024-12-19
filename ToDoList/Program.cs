using System.Text;

namespace ToDoList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.GetEncoding(1251);

            List<string> todoList = []; //список справ
            bool isNotRunning = false; //умова виконання програми
            string mark = "#greencode#"; //спеціальна марка для виконаних справ

            //текст головного меню
            string mainMenu = "Вас вітає Ваш список справ. Прошу обрати функцію:\n" +
                              "1. Додавання справи\n" +
                              "2. Виведення всіх справ\n" +
                              "3. Відмітка про виконання\n" +
                              "4. Видалення справи\n" +
                              "5. Вийти з програми";

            while (!isNotRunning)
            {
                Console.WriteLine(mainMenu); //виводимо меню
                                
                if (int.TryParse(Console.ReadLine(), out int numberUserTakedFunction))
                {
                    switch (numberUserTakedFunction)
                    {
                        case 1:
                            AddPoint(todoList);
                            break;
                        case 2:
                            PrintPoint(todoList, mark);
                            break;
                        case 3:
                            ExecutionMark(todoList, mark);
                            break;
                        case 4:
                            DeletePoint(todoList);
                            break;
                        case 5: //умова виходу із циклу
                            isNotRunning = true;                           
                            break;
                        default:
                            Console.WriteLine("Некоректний ввід. Спробуйте знову");
                            break;
                    }
                }
            }
            Console.WriteLine("Кінець виконання програми");
        } 
        
        static void AddPoint(List<string> toDoList)
        {
            Console.WriteLine();
            Console.WriteLine("Прохання ввести вашу справу");
            string point = Console.ReadLine() ?? "Упссссссссс";
            toDoList.Add(point); //додаємо нову справу до листа
            Console.WriteLine($"Справу під номером {toDoList.Count} додано");
            Console.WriteLine();
        }
        static void PrintPoint(List<string> toDoList, string mark)
        {
            if (toDoList.Count == 0) 
            {
                Console.WriteLine("Список справ пустий");
                Console.WriteLine();
            }
            else
            {
                for (int i = 0; i < toDoList.Count; i++)
                {
                    //якщо справа має позначку, то ми робимо її зеленою і додаємо нагадування про виконання
                    if (toDoList[i].Contains(mark))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine((i + 1) + " " + toDoList[i][..^mark.Length] + " Виконано!!!");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine((i + 1) + " " + toDoList[i]);
                    }
                }
                Console.WriteLine();
            }
        }
        static void ExecutionMark(List<string> toDoList, string mark)
        {
            if (toDoList.Count == 0)
            {
                Console.WriteLine("Щоб скористатися функцією, Вам потрібно мати хоч одну справу");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Прохання вказати порядковий номер виконаної справи");
                if (int.TryParse(Console.ReadLine(), out int markpoint) &&
                                 markpoint > 0 && markpoint <= toDoList.Count)
                {
                    if (toDoList[markpoint - 1].Contains(mark)) //для неможливості двічі виконати справу
                    {
                        Console.WriteLine("Справа вже виконана");
                        Console.WriteLine();
                    }
                    else //позначаємо справу як виконану
                    {
                        toDoList[markpoint - 1] += mark;
                        Console.WriteLine("Помітку додано");
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("Некоректні дані. Спробуйте знову");
                    Console.WriteLine();
                }
            }         
        }
        static void DeletePoint(List<string> toDoList)
        {
            if (toDoList.Count == 0)
            {
                Console.WriteLine("Щоб скористатися функцією, Вам потрібно мати хоч одну справу");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Прохання вести порядковий номер справи для видалення");
                if (int.TryParse(Console.ReadLine(), out int numberDelatePoint) &&
                    numberDelatePoint > 0 && numberDelatePoint <= toDoList.Count)
                {
                    toDoList.RemoveAt(numberDelatePoint - 1);
                    Console.WriteLine("Справу успішно видалено");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Некоректні дані. Спробуйте знову");
                    Console.WriteLine();
                }
            }          
        }
    }
}
