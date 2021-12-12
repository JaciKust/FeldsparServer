using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Communication.DataObject;

namespace Communication.MessageBus
{
	public interface IMessageBus
	{
		event EventHandler<ButtonPressEventArgs> OnRecieve;

		void Send(IDataObject dataObject);
		void StartReceive();
		void StopReceive();
	}
}
