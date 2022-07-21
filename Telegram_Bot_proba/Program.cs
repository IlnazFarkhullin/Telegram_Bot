using System;
using Telegram.Bot;

namespace Telegram_Bot_proba
{
    class Program
    {
        //Мой первый простой ТЕЛЕГРАММ БОТ
        // Для начала устанавливаем NuGet пакет : Telegram.Bot версия 15.7.1
        private static string token { get; set; } = "5534709509:AAFdzjbX7Dv3QBPi9GFVuqtK2Pz0vd8jjVY"; //Токен для из бота в котором мы зарегистрировали бота 
        private static TelegramBotClient client;//поле для работы с клиентом    
      
        static void Main(string[] args)
        {
          client = new TelegramBotClient(token); // инициализируем бота используя наш токен
          client.StartReceiving(); //начало приёма сообщений
            client.OnMessage += OnMessageHeadler();// привязка к событию OnMessage и метод где будет происходить все действия с ботомж; 
          Console.ReadLine();
          client.StopReceiving(); //конец приёма сообщений
           
        }
    }
}
