using System;
using System.Threading;
using StackExchange.Redis;

namespace client
{
    class Program
    {
        static ConnectionMultiplexer RedisClient = ConnectionMultiplexer.Connect("localhost:6378");
        static IDatabase RedisDB;
        static void Main(string[] args)
        {
	    while(true)
	    {
		Thread.Sleep(200);
		try
		{
	           var RedisDB = RedisClient.GetDatabase();
		    var value = RedisDB.StringGet("g");
	     	    Console.Write(value);
		}
		catch(Exception exc)
		{
			continue;
		}
	    }
        }
    }
}
