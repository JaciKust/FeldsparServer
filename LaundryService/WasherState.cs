using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundryService
{
	public class WasherState
	{
		public static WasherState Idle = new WasherState(false, nameof(Idle));
		public static WasherState Washing = new WasherState(true, nameof(Washing));
		public static WasherState Spinning = new WasherState(true, nameof(Spinning));

		private WasherState(bool isMoving, string name)
		{
			IsMoving = isMoving;
			Name = name;
		}

		public bool IsMoving { get; }
		public string Name { get; }

		public override string ToString()
		{
			return $"WasherState {Name} is moving: {IsMoving}";
		}

		public override bool Equals(object obj)
		{
			return obj is WasherState state &&
				   IsMoving == state.IsMoving &&
				   Name == state.Name;
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(IsMoving, Name);
		}
	}
}
