using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotInTg.DBProfile;

public partial class Item
{
    public int ItemId { get; set;}
    
    public string Name { get; set;}

    public int ValueItem { get; set;}

    public int PricaeItem {  get; set;}

    public string ItemFunction { get; set;}
}
