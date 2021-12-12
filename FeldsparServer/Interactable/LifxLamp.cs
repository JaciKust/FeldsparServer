namespace FeldsparServer.Interactable
{
	public class LifxLamp : ILight
	{
		LifxLightBulb[] LightBulbs { get; }
		public string Name { get; set; }
		public LifxLamp(LifxLightBulb[] lightBulbs, string name)
		{
			LightBulbs = lightBulbs;
			Name = name;
		}

		public void TurnOff(double transitionTime = 0.1)
		{
			foreach (var bulb in LightBulbs)
			{
				bulb.TurnOff(transitionTime);
			}
		}

		public void TurnOn(Color color, double transitionTime = 0.1)
		{
			foreach (var bulb in LightBulbs)
			{
				bulb.TurnOn(color, transitionTime);
			}
		}
	}
}
