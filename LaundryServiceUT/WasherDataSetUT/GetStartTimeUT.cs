using System;
using LaundryService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit.Sdk;

namespace LaundryServiceUT
{
	[TestClass]
	public class GetStartTimeUT : LaundryBaseUT
	{
		private void TestStartNotBeforeStart(WasherDataSet dataSet, DateTime targetAfterPoint)
		{
			int thresholdMinutes = 2;
			var maxStartTime = targetAfterPoint.AddMinutes(thresholdMinutes);
			var startTime = dataSet.GetStartTime();
			Assert.IsTrue(maxStartTime > startTime);
		}

		[TestMethod]
		public void TestGetStartNotBeforeStartNormal13()
		{
			var acceptableStartTime = new DateTime(2021, 2, 19, 16, 2, 0);
			TestStartNotBeforeStart(normal13FullSet, acceptableStartTime);
		}

		[TestMethod]
		public void TestGetStartNotBeforeStartBedding14()
		{
			var acceptableStartTime = new DateTime(2021, 2, 19, 17, 20, 0);
			TestStartNotBeforeStart(bedding14FullSet, acceptableStartTime);
		}

		[TestMethod]
		public void TestGetStartNotBeforeStartNormal15()
		{
			var acceptableStartTime = new DateTime(2021, 2, 19, 18, 28, 0);
			TestStartNotBeforeStart(normal15FullSet, acceptableStartTime);
		}

		[TestMethod]
		public void TestGetStartNotBeforeStartDarks16()
		{
			var acceptableStartTime = new DateTime(2021, 2, 19, 19, 47, 0);
			TestStartNotBeforeStart(darks16FullSet, acceptableStartTime);
		}

		[TestMethod]
		public void TestGetStartNotBeforeStartQuickWash17()
		{
			var acceptableStartTime = new DateTime(2021, 2, 21, 12, 25, 0);
			TestStartNotBeforeStart(quickWash17FullSet, acceptableStartTime);
		}

		[TestMethod]
		public void TestGetStartNotBeforeStartHandWash18()
		{
			var acceptableStartTime = new DateTime(2021, 2, 21, 13, 14, 0);
			TestStartNotBeforeStart(normal15FullSet, acceptableStartTime);
		}

		[TestMethod]
		public void TestWasherStartNeverHappens()
		{
			var startTime = new DateTime(2021, 2, 19, 15, 33, 0);
			var endTime = new DateTime(2021, 2, 19, 15, 39, 0);
			var dataSet = normal13FullSet.GetSubSet(startTime, endTime);

			var washerStart = dataSet.GetStartTime();
			Assert.IsNull(washerStart);
		}

		[TestMethod]
		public void TestWasherStartBeforeDataStart()
		{
			var startTime = new DateTime(2021, 2, 19, 16, 16, 0);
			var endTime = new DateTime(2021, 2, 19, 16, 30, 0);
			var dataSet = normal13FullSet.GetSubSet(startTime, endTime);

			var maxStartTime = startTime.AddMinutes(1);
			var washerStart = dataSet.GetStartTime();
			Assert.IsTrue(maxStartTime > washerStart);
		}
	}
}
