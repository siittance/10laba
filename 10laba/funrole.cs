using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10laba;

public class funrole
{
    public void adm()
    {
        bool pravda = true;
        while (pravda != false)
        {
            Console.Clear();
            user user = new user();
            pathjson pathjson = new pathjson();
            sotrudnik sotrudnik = new sotrudnik();
            List<user> users = Serialization.Deserialization<List<user>>(pathjson.pathdlyaavtoriz);
            List<sotrudnik> sotrudniks = Serialization.Deserialization<List<sotrudnik>>(pathjson.pathdlyasotrudnik);
            foreach (user user1 in users)
            {
                foreach (sotrudnik sotrudnik1 in sotrudniks)
                {
                    if (user.id == sotrudnik1.id)
                    {
                        Console.Clear();
                        Console.WriteLine(" |-----------------------------------------------------------|");
                        Console.WriteLine($"           Вы залетели как adm, {sotrudnik.namee}            ");
                        Console.WriteLine(" |-----------------------------------------------------------|");
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("|-----------------------------------------------------------|");
                        Console.WriteLine("|                        Вы adm                             |");
                        Console.WriteLine("|-----------------------------------------------------------|");

                    }
                }
            }
            foreach(user user2 in users)
            {
                Console.WriteLine($"    {user.id}.{user.Login}");
            }
            var adm =  new admin();
            var key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.Z:
                    adm.dobavlenie();
                    break;
                case ConsoleKey.X:
                    adm.izmen();
                    break;
                case ConsoleKey.C:
                    adm.ydal();
                    break;
                case ConsoleKey.Escape:
                    pravda = false;
                    break;
                default:
                    var vibor = adm.CursorMenu(3,users.Count - 1) - 2; //то что рисунки в паинте ебать ахуеть
                    Console.Clear();
                    Console.WriteLine($"{users[vibor].id}\n{users[vibor].Login}\n{users[vibor].Password}\n{users[vibor].role}");
                    Console.ReadKey();
                    break; 
            }
        }
    }

}
