namespace FeldsparServer.DataObjects
{
	public interface IDataObject
	{
		public string Name { get; set; }
		public string Topic { get; set; }

		public string ToJsonString();
	}
}
