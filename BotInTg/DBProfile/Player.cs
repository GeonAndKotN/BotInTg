using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotInTg.DBProfile;

public partial class Player
{
    public int StateID { get; set; }

    public long ChatId { get; set; }

    public string Nick { get; set; }

}
