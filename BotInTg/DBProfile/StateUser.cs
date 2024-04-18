using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;

namespace BotInTg.DBProfile
{
    public abstract class StateUser
    {
        public int StateID { get; set; }
        public abstract void UserStateAsync(ITelegramBotClient botClient, long id, string message);
    }
}

