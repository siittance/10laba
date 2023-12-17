using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10laba;
public abstract class role
{
    protected string NameRoli; 
    public role(string NameRoli)
    {
        this.NameRoli = NameRoli; //как self только this
    }

    public abstract void dobavlenie();
    public abstract void izmen();
    public abstract void ydal();
    public abstract void poisk();
    public int CursorMenu(int MinPos, int MaxPos)
    {
        ConsoleKeyInfo key = Console.ReadKey();
        int CursorPos = 2;
        while (key.Key != ConsoleKey.Enter)
        {
            Console.SetCursorPosition(0, CursorPos);
            Console.WriteLine("   ");
            if (key.Key == ConsoleKey.UpArrow && CursorPos > MinPos)
            {
                CursorPos--;
            }
            else if (key.Key == ConsoleKey.DownArrow && CursorPos < MaxPos + 1)
            {
                CursorPos++;
            }
            Console.SetCursorPosition(0, CursorPos);
            Console.WriteLine("-->");
            key = Console.ReadKey();
        }

        return CursorPos;
    }
}
public class admin : role
{
    public admin() : base("admin") // базовый класс для других классов с наслеследованием 
    {

    }
    public override void dobavlenie() //изменение реализации метода, который уже определен в базовом классе
    {
        Console.Clear();
        Console.WriteLine("Вы добавляете людей");
        pathjson pathjson = new pathjson();
        user user = new user(); 
        List<user> users = Serialization.Deserialization<List<user>>(pathjson.pathdlyaavtoriz);
        Console.WriteLine("Введите логин: ");
        string login = Console.ReadLine();
        Console.WriteLine("Введите пароль: ");
        string parol = Console.ReadLine();
        Console.WriteLine("Введите id пользователя: ");
        try
        {
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введи роль: ");
            string roli = Console.ReadLine();

            user newusers = new user();
            newusers.Login = login;
            newusers.Password = parol;
            newusers.id = id;
            newusers.role = roli;
            users.Add(newusers);
            Serialization.Sirialize(users, pathjson.pathdlyaavtoriz);
        } catch
        {
            Console.WriteLine("Проеб");
            Thread.Sleep(1000);
        }
    }

    public override void izmen()
    {
        Console.Clear();
        Console.WriteLine("Вы меняете людей");
        pathjson pathjson = new pathjson();
        user user = new user();
        List<user> users = Serialization.Deserialization<List<user>>(pathjson.pathdlyaavtoriz);
        int i = 1;
        foreach (var item in users)
        {
            Console.WriteLine($"{i++} {item.Login}");
        }
        Console.WriteLine("Выберите id пользователя, которого хотите изменить: ");
        try
        {
            int vibor = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите обновленный пароль: ");
            string parol =  Console.ReadLine();
            Console.WriteLine("Введите новую роль: ");
            string roli = Console.ReadLine();
            Console.WriteLine("Введите новый idшник: ");
            int id = Convert.ToInt32(Console.ReadLine());
            vibor -= 1;
            users[vibor].Password = parol;
            users[vibor].role = roli;
            users[vibor].id = id;
            Serialization.Sirialize(users, pathjson.pathdlyaavtoriz);
        }
        catch 
        {
            Console.WriteLine("Проеб");
            Thread.Sleep(1000);
        }
    }
    public override void ydal()
    {
        Console.Clear();
        Console.WriteLine("Вы удалете");
        pathjson pathjson = new pathjson();
        user user = new user();
        List<user> users = Serialization.Deserialization<List<user>>(pathjson.pathdlyaavtoriz);
        int i = 1;
        foreach(var item in users)
        {
            Console.WriteLine($"{i++} {item.Login}");
        }
        Console.WriteLine("Выберите пользователя, которого хотите удалить: ");
        try
        {
            int vibor = Convert.ToInt32(Console.ReadLine());
            vibor -= 1;
            users.RemoveAt(vibor);
            Serialization.Sirialize(users, pathjson.pathdlyaavtoriz);
        }
        catch 
        {
            Console.WriteLine("Проеб");
            Thread.Sleep(1000);
        }
    }
    public override void poisk()
    {
        throw new NotImplementedException();
    }
}


