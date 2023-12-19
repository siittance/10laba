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
        int CursorPos = 3;
        while (key.Key != ConsoleKey.Enter)
        {
            Console.SetCursorPosition(0, CursorPos);
            Console.WriteLine("   ");
            if (key.Key == ConsoleKey.UpArrow && CursorPos > MinPos)
            {
                CursorPos--;
            }
            else if (key.Key == ConsoleKey.DownArrow && CursorPos < MaxPos)
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

public class tipovbral : role
{
    public tipovbral() : base("tipovbral")
    {

    }
    public override void dobavlenie() //изменение реализации метода, который уже определен в базовом классе
    {
        Console.Clear();
        Console.WriteLine("Вы добавляете людей");
        pathjson pathjson = new pathjson();
        sotrudnik sotrudnik = new sotrudnik();
        List<sotrudnik> sotrudniks = Serialization.Deserialization<List<sotrudnik>>(pathjson.pathdlyasotrudnik);
        Console.WriteLine("Введите id сотрудника: ");
        try
        {
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите фамилию: ");
            string Surname = Console.ReadLine();
            Console.WriteLine("Введите имя: ");
            string Namee = Console.ReadLine();
            Console.WriteLine("Введи отчество: ");
            string MiddleName = Console.ReadLine();
            Console.WriteLine("Введите время спавна: ");
            string Datarosh = Console.ReadLine();
            Console.WriteLine("Введите паспортные данные: ");
            string PassportNomSer = Console.ReadLine();
            Console.WriteLine("Введите должность: ");
            string Dolshnost = Console.ReadLine();
            Console.WriteLine("Введите зарплату: ");
            int Zp = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите idшник аккаунта: ");
            int User_id = Convert.ToInt32(Console.ReadLine());
            sotrudnik newsotrudnik = new sotrudnik();
            newsotrudnik.id = id;
            newsotrudnik.surname = Surname;
            newsotrudnik.namee = Namee;
            newsotrudnik.middlename = MiddleName;
            newsotrudnik.datarod = Datarosh;
            newsotrudnik.passportNomSer = PassportNomSer;
            newsotrudnik.dolshnost = Dolshnost;
            newsotrudnik.zp = Zp;
            newsotrudnik.user_id = User_id;
            sotrudniks.Add(newsotrudnik);
            Serialization.Sirialize(sotrudniks, pathjson.pathdlyasotrudnik);
        }
        catch    
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
        sotrudnik sotrudnik = new sotrudnik();
        List<sotrudnik> sotrudniks = Serialization.Deserialization<List<sotrudnik>>(pathjson.pathdlyasotrudnik);
        int i = 1;
        foreach (var item in sotrudniks)
        {
            Console.WriteLine($"{i++} {item.namee}");
        }
        Console.WriteLine("Выберите id пользователя, которого хотите изменить: ");
        try
        {
            int vibor = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите новый idшник: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите новую фамилию: ");
            string Surname = Console.ReadLine();
            Console.WriteLine("Введите новое имя: ");
            string Namee = Console.ReadLine();
            Console.WriteLine("Введите новое отчество: ");
            string MiddleName = Console.ReadLine();
            Console.WriteLine("Введите новую дату спавна: ");
            string Datarod = Console.ReadLine();
            Console.WriteLine("Введите новые пасспортные данные: ");
            string PassportNomSer = Console.ReadLine();
            Console.WriteLine("Введите новую должность: ");
            string Dolshnost = Console.ReadLine();
            Console.WriteLine("Введите новую зарплату: ");
            int zp = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Привяжите должность к новому пользователю: ");
            int User_id = Convert.ToInt32(Console.ReadLine());
            vibor -= 1;
            sotrudniks[vibor].id = id;
            sotrudniks[vibor].surname = Surname;
            sotrudniks[vibor].namee = Namee;
            sotrudniks[vibor].middlename = MiddleName;
            sotrudniks[vibor].datarod = Datarod;
            sotrudniks[vibor].passportNomSer = PassportNomSer;
            sotrudniks[vibor].dolshnost = Dolshnost;
            sotrudniks[vibor].zp = zp;
            sotrudniks[vibor].user_id = User_id;
            Serialization.Sirialize(sotrudniks, pathjson.pathdlyasotrudnik);
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
        sotrudnik sotrudnik = new sotrudnik();
        List<sotrudnik> sotrudniks = Serialization.Deserialization<List<sotrudnik>>(pathjson.pathdlyasotrudnik);
        int i = 1;
        foreach (var item in sotrudniks)
        {
            Console.WriteLine($"{i++} {item.namee}");
        }
        Console.WriteLine("Выберите пользователя, которого хотите удалить: ");
        try
        {
            int vibor = Convert.ToInt32(Console.ReadLine());
            vibor -= 1;
            sotrudniks.RemoveAt(vibor);
            Serialization.Sirialize(sotrudniks, pathjson.pathdlyasotrudnik);
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

public class skladmen : role
{
    public skladmen() : base("skladmen") // базовый класс для других классов с наслеследованием 
    {

    }
    public override void dobavlenie() //изменение реализации метода, который уже определен в базовом классе
    {
        Console.Clear();
        Console.WriteLine("Вы добавляете товар");
        pathjson pathjson = new pathjson();
        tovar tovar = new tovar();
        List<tovar> tovars = Serialization.Deserialization<List<tovar>>(pathjson.pathdlyasklad);
        try
        {
            Console.WriteLine("Введите id товара: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите наименование: ");
            string naimen = Console.ReadLine();
            Console.WriteLine("Введите количество: ");
            int kolvo = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите цену за штуку: ");
            int shtykacena = Convert.ToInt32(Console.ReadLine());
            tovar newtovar = new tovar();
            newtovar.id = id;
            newtovar.naimenovanie = naimen;
            newtovar.skokavsego = kolvo;
            newtovar.odnashtykacena = shtykacena;
            tovars.Add(newtovar);
            Serialization.Sirialize(tovars, pathjson.pathdlyasklad);
        }
        catch
        {
            Console.WriteLine("Проеб");
            Thread.Sleep(1000);
        }
    }

    public override void izmen()
    {
        Console.Clear();
        Console.WriteLine("Вы меняете товар");
        pathjson pathjson = new pathjson();
        tovar tovar = new tovar();
        List<tovar> tovars = Serialization.Deserialization<List<tovar>>(pathjson.pathdlyasklad);
        int i = 1;
        foreach (var item in tovars)
        {
            Console.WriteLine($"{i++} {item.naimenovanie}");
        }
        Console.WriteLine("Выберите id товара который хотите изменить: ");
        try
        {
            Console.WriteLine("Введите id товара: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите наименование: ");
            string naimen = Console.ReadLine();
            Console.WriteLine("Введите количество: ");
            int kolvo = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите цену за штуку: ");
            int shtykacena = Convert.ToInt32(Console.ReadLine());
            tovar newtovar = new tovar();
            newtovar.id = id;
            newtovar.naimenovanie = naimen;
            newtovar.skokavsego = kolvo;
            newtovar.odnashtykacena = shtykacena;
            Serialization.Sirialize(tovars, pathjson.pathdlyasklad);
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
        tovar tovar = new tovar();
        List<tovar> tovars = Serialization.Deserialization<List<tovar>>(pathjson.pathdlyasklad);
        int i = 1;
        foreach (var item in tovars)
        {
            Console.WriteLine($"{i++} {item.naimenovanie}");
        }
        Console.WriteLine("Выберите товар, который хотите удалить: ");
        try
        {
            int vibor = Convert.ToInt32(Console.ReadLine());
            vibor -= 1;
            tovars.RemoveAt(vibor);
            Serialization.Sirialize(tovars, pathjson.pathdlyasklad);
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


