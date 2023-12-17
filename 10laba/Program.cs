using System.Globalization;
using System.Net.WebSockets;
using System.Text;

namespace _10laba
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("ru-RU");
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            while (true)
            {
                Console.Clear();
                funrole axyi = new funrole();
                Console.WriteLine("|-------------------------------------------------------|");
                Console.WriteLine("|                    Автorization                       |"); //доб украшения ебать
                Console.WriteLine("|-------------------------------------------------------|");
                Console.WriteLine("Вводи имя своё: ");
                string login = Console.ReadLine();
                Console.WriteLine("Вводи пароль: ");
                string parol = "";
                ConsoleKeyInfo nashimalka;    
                do
                {
                    nashimalka = Console.ReadKey(true);
                    if (nashimalka.Key != ConsoleKey.Backspace && nashimalka.Key != ConsoleKey.Enter)
                    {
                        parol += nashimalka.KeyChar; //жоско добавляю в пароль нажатую клавишу и запикаю её
                        Console.Write("*");
                    }
                    else if (nashimalka.Key == ConsoleKey.Backspace && parol.Length > 0)
                    {
                        parol = parol.Substring(0, parol.Length - 1); //удаляет одно знач в строке
                        Console.Write("\b \b"); //возвращает курсор назад
                    }
                } while (nashimalka.Key != ConsoleKey.Enter); //пока энтер не нажат нихуя не изменится




                user user = new user();
                pathjson path = new pathjson(); //вызов класса (создание объекта класса)
                Console.Clear();
                List<user> infouser = Serialization.Deserialization<List<user>>(path.pathdlyaavtoriz); //читаю данные из json со всеми
                foreach (var item in infouser) //присваем хуйню (item) json 
                {
                    if (item.Login == login && item.Password == parol)
                    {
                        switch (item.role)
                        {
                            case "adm":
                                axyi.adm();
                                Thread.Sleep(1000);
                                break;
                            case "buh":
                                Console.WriteLine("|-----------------------------------------------------------|");
                                Console.WriteLine("|                        Вы buh                             |");
                                Console.WriteLine("|-----------------------------------------------------------|");
                                break;
                            case "prodashnik":
                                Console.WriteLine("|-----------------------------------------------------------|");
                                Console.WriteLine("|                      Вы prodashnik                        |");
                                Console.WriteLine("|-----------------------------------------------------------|");
                                break;
                            case "skladmen":
                                Console.WriteLine("|-----------------------------------------------------------|");
                                Console.WriteLine("|                      Вы skladmen                          |");
                                Console.WriteLine("|-----------------------------------------------------------|");
                                break;
                            case "tipovbral":
                                Console.WriteLine("|-----------------------------------------------------------|");
                                Console.WriteLine("|                      Вы tipovbral                         |");
                                Console.WriteLine("|-----------------------------------------------------------|");
                                break;
                        }
                    }
                }
            } 
        }
    }
}