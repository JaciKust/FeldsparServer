namespace Communication.DataObject
{
	public interface IDataObject
	{
		public string Name { get; set; }
		public string Topic { get; set; }

		public string ToJsonString();
	}
}
