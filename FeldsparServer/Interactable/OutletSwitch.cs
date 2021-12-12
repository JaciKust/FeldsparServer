using FeldsparServer.DataObjects;
using FeldsparServer.Messaging;

namespace FeldsparServer.Interactable
{
	public class OutletSwitch
	{
		public static readonly double OneHighTime = 0.00015;
		public static readonly double OneLowTime = 0.00062;
		public static readonly double ZeroHighTime = 0.00054;
		public static readonly double ZeroLowTime = 0.00023;
		public static readonly double IntervalTime = 0.00614;

		public OutletSwitch(int id, string name, string onCode, string offCode, IMessageBus messageBus)
		{
			Id = id;
			Name = name;

			OnCode = onCode;
			OffCode = offCode;

			MessageBus = messageBus;
		}

		public IMessageBus MessageBus { get; set; }

		public string OnCode { get; }
		public string OffCode { get; }

		public int Id { get; }
		public string Name { get; }

		private bool isOn;

		public bool IsOn => isOn;

		public void SetOn()
		{
			if (isOn)
			{
				return;
			}

			ForceSetOn();
		}

		public void ForceSetOn()
		{
			Send(OnCode);
			isOn = true;
		}

		public void SetOff()
		{
			if (!isOn)
			{
				return;
			}

			ForceSetOff();
		}

		public void ForceSetOff()
		{
			Send(OffCode);
			isOn = false;
		}

		private void Send(string code)
		{
			var data = new DataObjectTransmitterCode(code, OneHighTime, OneLowTime, ZeroHighTime, ZeroLowTime, IntervalTime);
			MessageBus.Send(data);
		}

	}
}
