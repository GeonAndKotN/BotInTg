using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace BotInTg.DBProfile;

public class Player
{
    public int StateID { get; set; }

    public long ChatId { get; set; }

    public string Nick { get; set; }

    public StateUser State { get; set; }
}
