using System.Text.Json;

namespace FeldsparServer.DataObjects
{
	public class PanelStateDataObject : DataObjectBase
	{
		public PanelStateDataObject(string state) : base(nameof(PanelStateDataObject), DataTopic.ControlPanel)
		{
			State = state;
		}

		public string State { get; set; }

		public override string ToJsonString()
		{
			return JsonSerializer.Serialize(this);
		}
	}
}
