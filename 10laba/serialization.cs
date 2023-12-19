using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace _10laba;

static class Serialization
{
    public static void Sirialize <tipe> (tipe data, string path) //жоская тема, типо типе передает в большеменьше типы данных, дабы дохера раз их не вводить в сериализацию
    {
        string json = JsonConvert.SerializeObject (data);
        File.WriteAllText (path, json); //чтение текста из файла 
    }

    public static tipe Deserialization<tipe> (string path)
    {
        string json = "";
        try
        {
            json = File.ReadAllText(path);

        }
        catch (Exception)
        {
            File.Create(path).Close (); 
            json = File.ReadAllText(path);
        }
        tipe data = JsonConvert.DeserializeObject <tipe>(json);
        return data; //возврат значения дата
    }
}

