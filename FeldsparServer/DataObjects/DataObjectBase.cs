namespace FeldsparServer.DataObjects
{
	public abstract class DataObjectBase : IDataObject
	{
		public DataObjectBase(string name, string topic)
		{
			Name = name;
			Topic = topic;
		}

		public string Name { get; set; }

		public string Topic { get; set; }

		public abstract string ToJsonString();
	}
}
