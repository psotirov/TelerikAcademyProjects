using System;
using System.Threading.Tasks;

public class PubnubChat
{
    private const string pubNubPublishKey = "pub-c-********-32d6-4665-95a9-c14a7ca8b7fa";
    private const string pubNubSubscribeKey = "sub-c-********-082f-11e3-8f37-02ee2ddab7fe";
    private const string pubNubSecretKey = "sec-c-********NzMtMzE3YS00ZWU4LWFiYzEtZTM0YmU3MGE5YzFi";
    private const string pubNubChannel = "chat-channel";

	static void Main()
	{
        if (pubNubPublishKey.IndexOf('*') > 0 ||
            pubNubSubscribeKey.IndexOf('*') > 0 ||
            pubNubSecretKey.IndexOf('*') > 0)
        {
            Console.WriteLine("Please setup your PubNub Keys into the code");
            return;
        }

		PubnubAPI pubnub = new PubnubAPI(pubNubPublishKey, pubNubSubscribeKey, pubNubSecretKey, true /* SSL on */);
        Console.WriteLine("Welcome to the SimpleChat Service\n\n");

		// Subscribe for receiving messages (in a background task to avoid blocking)
		Task receiver = new Task(() => 
            pubnub.Subscribe(
                pubNubChannel,
				delegate(object message)
				{
					Console.WriteLine("Message Received: " + message);
					return true;
				}
			)
		);

		receiver.Start();

		// Read messages from the console and publish them to Pubnub
		while (true)
		{
			Console.Write("Msg> ");
			string message = Console.ReadLine().Trim();
            if (message.Length == 0)
            {
                return;
            }

            pubnub.Publish(pubNubChannel, message);
			Console.WriteLine("Message sent.");
		}
	}
}