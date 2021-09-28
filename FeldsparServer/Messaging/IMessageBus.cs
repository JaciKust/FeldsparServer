using System;

namespace FeldsparServer.Messaging
{
	public interface IMessageBus
	{
		event EventHandler OnRecieve;

		void Send();
		void StartReceive();
		void StopReceive();
	}
}