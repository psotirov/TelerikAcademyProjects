using System;
using io.iron.ironmq;
using io.iron.ironmq.Data;
using System.Threading;

class IronMQChat
{
    private static Client client;
    private static Queue queue;
    private const string ironMQToken = "E5oN25bwR3******mKOji05_ays"; // enter your Iron MQ Token Here
    private const string ironMQProjectId = "5210fadf******000d000016"; // enter your Iron MQ Project Id Here
    private const string ironMQQueueName = "SimpleChatQueue";

    public static void Main()
    {
        if (ironMQToken.IndexOf('*') > 0 || ironMQProjectId.IndexOf('*') > 0)
        {
            Console.WriteLine("Please setup your Iron MQ Token into the code");
            return;
        }

        // prepare chat
        client = new Client(ironMQProjectId, ironMQToken);
        queue = client.queue(ironMQQueueName);
        Console.WriteLine("Welcome to the SimpleChat Service\n\n");

        // arrange receiver as separate thread
        Thread receiver = new Thread(new ThreadStart(Receiver));
        receiver.Start();

        Sender();

        receiver.Abort();
    }
    
    private static void Sender()
	{
		Console.WriteLine("Enter your messages [Empty line to finish]:\n");
		while (true)
		{            
            Console.Write("Msg> ");
            // let receiver works until waiting for input
            // the drawback is that message entering could be split by the incoming message 
            // TODO: move the console buffer area of current Sender loop after the incoming message
			string msg = Console.ReadLine().Trim();
            if (msg.Length == 0)
            {
                return;
            }

			queue.push(msg);
			Console.WriteLine("Message sent.");
		}
	}

    private static void Receiver()
    {
         while (true)
        {
            Message msg = queue.get();
            if (msg != null)
            {
                Console.WriteLine("\nMessage received: " + msg.Body);
            }
            Thread.Sleep(1000);
        }
    }
}
