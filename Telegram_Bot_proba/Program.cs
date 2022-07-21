using System;
using Telegram.Bot;
using Telegram.Bot.Args;

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
                await client.SendTextMessageAsync(msg.Chat.Id, msg.Text, replyToMessageId: msg.MessageId);//ответ бота
            }
        }
    }
}
