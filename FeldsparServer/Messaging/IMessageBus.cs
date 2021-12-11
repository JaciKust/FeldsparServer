﻿using System;
using FeldsparServer.DataObjects;
namespace FeldsparServer.Messaging
{
	public interface IMessageBus
	{
		event EventHandler<ButtonPressEventArgs> OnRecieve;

		void Send(IDataObject dataObject, string topic);
		void StartReceive();
		void StopReceive();
	}
}