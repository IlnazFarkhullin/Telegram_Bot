using System;
using System.Collections.Generic;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;

namespace Telegram_Bot_proba
{
    class Program
    {
        //Мой первый простой ТЕЛЕГРАММ БОТ
        // Для начала устанавливаем NuGet пакет : Telegram.Bot версия 16.0.0 (использовался именно эта версия пакета из-за того что в последней версии нет того или иного метода)
        public static string token  = "5423160433:AAFlh4eOZBh3uilipEhvha98S8xHNQCn8Ck"; //Токен для из бота в котором мы зарегистрировали бота 
        private static TelegramBotClient client;//поле для работы с клиентом    

        [Obsolete] // озночает что тот или иной метод устарел
        static void Main(string[] args)
        {
            client = new TelegramBotClient(token); // инициализируем бота используя наш токен
            client.StartReceiving(); //начало приёма сообщений
            client.OnMessage += OnMessageHeadler;// привязка к событию OnMessage и метод где будет происходить все действия с ботомж; 
          Console.ReadLine();
          client.StopReceiving(); //конец приёма сообщений
           

        }

        
        private static async void  OnMessageHeadler(object sender, MessageEventArgs e)
        {
            var msg = e.Message;  //локальная переменная для записи полученного сообщения
            if (msg != null)// проверка на наличие сообщения
            {
                Console.WriteLine($"Пришло сообщение с текстом {msg.Text}");//вывод пришедшего сообщения на консоль
               //await client.SendTextMessageAsync(msg.Chat.Id, msg.Text, replyToMessageId: msg.MessageId);//ответ бота
              //var stic = await client.SendStickerAsync(chatId:msg.Chat.Id, sticker: "https://smailik.ucoz.com/_ph/84/2/680018678.jpg?1658488771", replyToMessageId: msg.MessageId);//отправка стикера
              // await client.SendTextMessageAsync(msg.Chat.Id, msg.Text, replyToMessageId: msg.MessageId, replyMarkup: GetButton());// тут реализована раота с кнопками(метод GetButton()). при нажатии на кпопку бот нам отвечает
                switch (msg.Text)
                {
                    case "Стикер":
                        var stic = await client.SendStickerAsync(chatId: msg.Chat.Id, sticker: "https://smailik.ucoz.com/_ph/84/2/680018678.jpg?1658488771", replyToMessageId: msg.MessageId); 
                        break;
                    
                    default:
                        await client.SendTextMessageAsync(msg.Chat.Id, "Выберите команду", replyMarkup: GetButton());
                        break;
                        //для отправки фото используется параметр SendPhotoAsync(photo:"путь к картинке") 
                        
                }
            }

        }

        private static IReplyMarkup GetButton()// данный метод возвращает клавиатуру который состоит из списка  кнопок
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>> // Создаём кнопки. Один список это  один ряд кнопок
                {
                       new List<KeyboardButton>{new KeyboardButton { Text="Стикер"}, new KeyboardButton {Text="Good" } }
                }
            };
        }
    }
}
