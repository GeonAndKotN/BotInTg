using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BotInTg.DBProfile;
using BotInTg.DungeonLevels;
using Telegram.Bot;

namespace BotInTg
{
    public class RegistrationUser : StateUser
    {
        public override void UserState(ITelegramBotClient botClient, long id, string message)
        {
            if (message.Contains("/nick"))
            {
                UserData.Users[id].Nick = "UserNoName";
                _ = botClient.SendTextMessageAsync(id, "Выберите другое имя");
                UserData.Users[id].Nick = message;
                return;
            }

            if (message.Contains("/end"))
            {
                UserData.Users[id].State = new FirstLevelState();// перевод клиента в другое состояние с другим набором обрабатываемых команд

            }
        }
    }
}
