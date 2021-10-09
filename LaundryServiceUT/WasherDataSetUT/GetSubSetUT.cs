using System;
using System.Collections.Generic;
using System.Linq;
using LaundryService;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LaundryServiceUT
{
	[TestClass]
	public class GetSubSetUT
	{
		protected static readonly DateTime time0 = new DateTime(2021, 01, 01, 10, 10, 0);
		protected static readonly DateTime time1 = new DateTime(2021, 01, 01, 10, 11, 0);
		protected static readonly DateTime time2 = new DateTime(2021, 01, 01, 10, 12, 0);
		protected static readonly DateTime time3 = new DateTime(2021, 01, 01, 10, 13, 0);
		protected static readonly DateTime time4 = new DateTime(2021, 01, 01, 10, 14, 0);
		protected static readonly DateTime time5 = new DateTime(2021, 01, 01, 10, 15, 0);
		protected static readonly DateTime time6 = new DateTime(2021, 01, 01, 10, 16, 0);
		protected static readonly DateTime time7 = new DateTime(2021, 01, 01, 10, 17, 0);
		protected static readonly DateTime time8 = new DateTime(2021, 01, 01, 10, 18, 0);
		protected static readonly DateTime time9 = new DateTime(2021, 01, 01, 10, 19, 0);

		protected static readonly AxisReading reading0 = new AxisReading(1, 2, 3, time1);
		protected static readonly AxisReading reading1 = new AxisReading(11, 12, 13, time0);
		protected static readonly AxisReading reading2 = new AxisReading(21, 22, 23, time2);
		protected static readonly AxisReading reading3 = new AxisReading(31, 32, 33, time3);
		protected static readonly AxisReading reading4 = new AxisReading(41, 42, 43, time4);
		protected static readonly AxisReading reading5 = new AxisReading(51, 52, 53, time5);
		protected static readonly AxisReading reading6 = new AxisReading(61, 62, 63, time6);
		protected static readonly AxisReading reading7 = new AxisReading(71, 72, 73, time7);
		protected static readonly AxisReading reading8 = new AxisReading(81, 82, 83, time8);
		protected static readonly AxisReading reading9 = new AxisReading(91, 92, 93, time9);

		protected static readonly WasherDataSet washerDataSet = new WasherDataSet(new List<AxisReading>() {
			reading0,
			reading1,
			reading2,
			reading3,
			reading4,
			reading5,
			reading6,
			reading7,
			reading8,
			reading9
		});

		[TestMethod]
		public void TestGetSubSetReturnsExpectedSet()
		{
			var startTime = time4;
			var endTime = time6;

			var data = washerDataSet.GetSubSet(startTime, endTime);

			Assert.AreEqual(3, data.Data.Count());
			Assert.AreSame(reading4, data.Data.First());
			Assert.AreSame(reading6, data.Data.Last());
		}

		[TestMethod]
		public void TestGetSubSetReturnsFromBeginningIfNoStartTimeSupplied()
		{
			var endTime = time6;
			var data = washerDataSet.GetSubSet(endTime: endTime);
			Assert.AreEqual(6, data.Data.Count());
			Assert.AreSame(reading0, data.Data.First());
			Assert.AreSame(reading6, data.Data.Last());
		}

		[TestMethod]
		public void TestGetSubSetReturnsToEndIfNoStartTimeSupplied() 
		{
			var startTime = time4;
			var data = washerDataSet.GetSubSet(startTime: startTime);
			Assert.AreEqual(6, data.Data.Count());
			Assert.AreSame(reading4, data.Data.First());
			Assert.AreSame(reading9, data.Data.Last());
		}

		[TestMethod]
		public void TestGetSubSetThrowsExceptionWhenStartTimeAfterEndTime()
		{
			var startTime = time3;
			var endTime = time1;

			var dataSet = new WasherDataSet(new List<AxisReading>());

			try
			{
				dataSet.GetSubSet(startTime, endTime);
			}
			catch (ArgumentException)
			{
				// Do nothing. This is the pass condition. 
				return;
			}
			catch (Exception e)
			{
				Assert.Fail($"Expected exception of type {nameof(ArgumentException)}. Message:" + e.Message);
			}
		}
	}
}
