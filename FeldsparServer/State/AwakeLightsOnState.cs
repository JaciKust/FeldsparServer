using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FeldsparServer.DataObjects;
using FeldsparServer.Interactable;

namespace FeldsparServer.State
{
	public class AwakeLightsOnState : BaseState
	{
		public override IState HandleMessage(ButtonPressedDataObject buttonPressData)
		{
			return new AwakeLightsOffState();
		}

		public override void OnStateEnter(IState oldState)
		{
			LifxBulbs.AllLamps.TurnOn(Colors.WhiteDaylight, 0.1);
		}

		public override void OnStateLeave(IState newState)
		{
			
		}

		public override void OnTick(DateTime currentTime)
		{
			// No-op
		}
	}
}
