using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeldsparServer.State.Rainbow
{
	internal class RainbowControl
	{
		private readonly RainbowSetting[] _settings;
		private int _index;
		public RainbowControl(RainbowSetting[] settings, int startingIndex){
			_settings = settings;
			_index = startingIndex;
		}

		public void Increment(){
			_index++;
			_index %= _settings.Length;
		}

		public void Decrement(){
			_index--;
			if (_index < 0){
				_index = _settings.Length - 1;
			}
		}

		public RainbowSetting Value => _settings[_index];
	}
}
