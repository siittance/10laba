using System.Globalization;
using System.Net.WebSockets;
using System.Text;

namespace _10laba
{
    internal class Program
    {

        internal static void Main()
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
                                axyi.adm(item.id);
                                Thread.Sleep(1000);
                                break;
                            case "buh":
                                axyi.buh(item.id);
                                Thread.Sleep(1000);
                                break;
                            case "prodashnik":
                                axyi.prodashnik(item.id);

                                break;
                            case "skladmen": //также как админ
                                axyi.skladmen(item.id);
                                Thread.Sleep(1000);
                                break;
                            case "tipovbral": //также как админ
                                axyi.tipovbral(item.id);
                                Thread.Sleep(1000);
                                break;
                        }
                    }
                }
            }
        }
    }
}