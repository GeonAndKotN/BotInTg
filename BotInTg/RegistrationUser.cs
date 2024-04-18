using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BotInTg.DBProfile;
using BotInTg.DungeonLevels;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace BotInTg
{
    public class RegistrationUser : StateUser
    {
        public override async void UserStateAsync(ITelegramBotClient botClient, long id, string message)
        {

            await botClient.SendTextMessageAsync(message, "Приветствую!" +
                            "\nДанный бот является МИНИ РПГ игрой где вам предстоит убивать монстров, исследовать подземелья и прокачивать" +
                            " собственного персонажа! " +
                            "\nВ данной игре не будет классов, вы можете быть кем угодно и прокачивать какие угодно навыки" +
                            "\n\nЗа помощью писать в этот чат - https://t.me/+WKfhhZfDpLRhOTky" +
                            "\n\nДля начала вам надо будет выбрать имя своего персонажа, введите ваше имя");

            /*if (message.Contains("/nick"))
            {
                UserData.Users[id].Nick = "UserNoName";
                _ = botClient.SendTextMessageAsync(id, "Выберите другое имя");
                UserData.Users[id].Nick = message;
                return;
            }
            if (message.Contains("/end"))
            {
                UserData.Users[id].State = new FirstLevelState();// перевод клиента в другое состояние с другим набором обрабатываемых команд

            }*/
        }
    }
}
