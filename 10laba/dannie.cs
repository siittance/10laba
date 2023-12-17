using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10laba;

internal class ID
{
    public int id { get; set; }
}
internal class user: ID
{
    public string Login { get; set; }
    public string Password { get; set; }
    public string role = "";
}
internal class sotrudnik: ID
{
    public string surname { get; set; }
    public string namee { get; set; }
    public string middlename { get; set; }
    public string datarod { get; set; }
    public int PassportNomSer { get; set; }
    public string dolshnost { get; set; }
    public int zp {  get; set; }
    public int user_id { get; set; }
}

internal class tovar: ID
{
    public string naimenovanie { get; set; }
    public int odnashtykacena { get; set; }
    public int skokavsego { get; set; }
}

internal class pokypka
{
    public string chokupili { get; set; }
    public int cenavsego { get; set; }
    public int skokavsego { get; set; }
}

internal class pathjson //хранит пути до json :_)
{
    public string pathdlyaavtoriz = "C:\\Users\\Administrator\\source\\repos\\10laba\\10laba\\avtorizacia.json";
    public string pathdlyasotrudnik = "C:\\Users\\Administrator\\source\\repos\\10laba\\10laba\\sotrudnik.json";
}
  


