using System;
using System.Threading;
using StackExchange.Redis;

namespace client
{
    class Program
    {
        private const string uri = "localhost:6378";
        static ConnectionMultiplexer connection = null;
        static IDatabase redisDb;
        static bool isConnected = false;
        static void Main(string[] args)
        {
            while(true)
            {
                Thread.Sleep(200);
                try
                {
                    if(!isConnected)
                    {
                        Console.WriteLine("connecting");
                        connection = ConnectionMultiplexer.Connect(uri);
                        isConnected = true;
                    }
                    var redisDb = connection.GetDatabase();
                    var value = redisDb.StringGet("g");
                    Console.Write(value);
                }
                catch(Exception exc)
                {
                    Console.WriteLine(exc);
                    isConnected = false;
                    continue;
                }
            }
        }
    }
}
