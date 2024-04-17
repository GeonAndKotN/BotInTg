using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types;
using static System.Net.Mime.MediaTypeNames;
using System.Threading;
using BotInTg.DungeonLevels;

namespace BotInTg
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var botClient = new TelegramBotClient("7140884239:AAFMcWNsUnDo7rFrDQGRlpYovz1C0KewLIQ");

            ReceiverOptions receiverOptions = new()
            {
                AllowedUpdates = Array.Empty<UpdateType>()
            };

            botClient.StartReceiving(HandleUpdateAsync, HandlePollingErrorAsync);
            Console.WriteLine("Бот запущен!");
            
            Console.ReadLine();
        }
        private static async Task HandlePollingErrorAsync(ITelegramBotClient client, Exception exception, CancellationToken token)
        {
            await client.SendPhotoAsync(exception.Message, InputFile.FromUri("https://raw.githubusercontent.com/GeonAndKotN/BotInTg/master/BotInTg/Photo/HahaErrorMan.png"), caption: "Упс, кажется возникла ошибка, сообщите в службу поддержки о баге!", cancellationToken: token);
        }

        public static async Task HandleUpdateAsync(ITelegramBotClient client, Update update, CancellationToken token)
        {
            var message = update.Message;
            int DungLevel = 1;

            ReplyKeyboardMarkup StartMenu = new(new[] { new KeyboardButton[] { "💰магазин💰" }, new KeyboardButton[] { "🧟Спуск🧟" } })
            {
                ResizeKeyboard = true
            };

            InlineKeyboardMarkup LevelCaves = new(new[]
                {
                    new []
                    {
                        _ = InlineKeyboardButton.WithCallbackData(text: $"1 уровень", callbackData: $"clvl1" ), 
                    },
                    new []
                    {
                        _ = InlineKeyboardButton.WithCallbackData(text: $"2 уровень", callbackData: $"clvl2"),
                    },
                    new []
                    {
                        _ = InlineKeyboardButton.WithCallbackData(text: $"3 уровень", callbackData: $"clvl3"),
                    },
                });

            InlineKeyboardMarkup ShopGood = new(new[]
                {
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData(text: "Выйти из магазина", callbackData: "lobbyback"),
                    },
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData(text: $"АРБУЗ", callbackData: "TocnoBuy"),
                    },
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData(text: $"Великое ничего", callbackData: "TocnoBuy"),
                    },
                });

            InlineKeyboardMarkup YesOrNo = new(new[]
                {
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData(text: "Да", callbackData: "nextMove"),
                    },
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData(text: "Нет", callbackData: "lobbyback"),
                    },
                });
            string leftblock = "-------------------------------------------------------------\n";
            string rightblock = "\n-------------------------------------------------------------";

            switch (update.CallbackQuery?.Data)
            {
                case "lobbyback":
                    await client.SendPhotoAsync(update.CallbackQuery.From.Id, InputFile.FromUri("https://img.freepik.com/premium-photo/cool-stylish-british-hipster-cat-with-fashionable-vintage-round-sunglasses-black-hat-studio-gray-background-creative-idea-fashion_338491-12633.jpg?w=826"), caption: $"{leftblock}Вы вернулись в лобби!{rightblock}", replyMarkup: StartMenu, cancellationToken: token);
                    break;
                case "TocnoBuy":
                    await client.SendTextMessageAsync(update.CallbackQuery.From.Id, $"{leftblock}Вы точно хотите купить {message} за {message} монет?{rightblock}", replyMarkup: YesOrNo, cancellationToken: token);
                    break;
                case "clvl1":
                    DungLevel = 1;
                    await client.SendTextMessageAsync(update.CallbackQuery.From.Id, $"{leftblock}Вы точно хотите спуститься в шахту {DungLevel} уровня?{rightblock}", replyMarkup: YesOrNo, cancellationToken: token);
                    break;
                case "clvl2":
                    DungLevel = 2;
                    await client.SendTextMessageAsync(update.CallbackQuery.From.Id, $"{leftblock}Вы точно хотите спуститься в шахту {DungLevel} уровня?{rightblock}", replyMarkup: YesOrNo, cancellationToken: token);
                    break;
                case "clvl3":
                    DungLevel = 3;
                    await client.SendTextMessageAsync(update.CallbackQuery.From.Id, $"{leftblock}Вы точно хотите спуститься в шахту {DungLevel} уровня?{rightblock}", replyMarkup: YesOrNo, cancellationToken: token);
                    break;
            }

            
            switch (update.Message?.Text?.ToLower())
            {
                case "/start":
                    await client.SendTextMessageAsync(message.Chat.Id, "Приветствую!" +
                            "\nДанный бот является МИНИ РПГ игрой где вам предстоит убивать монстров, исследовать подземелья и прокачивать" +
                            " собственного персонажа! " +
                            "\nВ данной игре не будет классов, вы можете быть кем угодно и прокачивать какие угодно навыки" +
                            "\n\nЗа помощью писать в этот чат - https://t.me/+WKfhhZfDpLRhOTky" +
                            "\n\nДля начала вам надо будет выбрать имя своего персонажа, введите ваше имя", replyMarkup: StartMenu);
                        break;

                case "💰магазин💰":
                    await client.SendTextMessageAsync(message.Chat.Id, $"{leftblock}Вы зашли в магазин, выберите товар!{rightblock}", replyMarkup: ShopGood);
                    break;
                case "🧟спуск🧟":
                    await client.SendTextMessageAsync(message.Chat.Id, $"{leftblock}Выберите уровень, куда хотите спуститься{rightblock}", replyMarkup: LevelCaves);
                    break;
            }
            Console.WriteLine($"Received a '{message?.Text}' message in chat {message?.Chat.Id}. From " +
                $"{message?.Chat.FirstName} {message?.Chat.LastName}");
        }

    }
}
