using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FeldsparServer.DataObjects;

namespace FeldsparServer.State
{
	public class AsleepLightsOffState : BaseState
	{
		public override IState HandleMessage(ButtonPressedDataObject buttonPressData)
		{
			throw new NotImplementedException();
		}

		public override void OnStateEnter(IState oldState)
		{
			throw new NotImplementedException();
		}

		public override void OnStateLeave(IState newState)
		{
			throw new NotImplementedException();
		}

		public override void OnTick(DateTime currentTime)
		{
			throw new NotImplementedException();
		}
	}
}
