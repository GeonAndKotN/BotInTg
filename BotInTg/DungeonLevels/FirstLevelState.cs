using BotInTg.DBProfile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;

namespace BotInTg.DungeonLevels
{
    public class FirstLevelState : StateUser
    {
        public override void UserStateAsync(ITelegramBotClient botClient, long id, string message)
        {
            throw new NotImplementedException();
        }
    }
}
