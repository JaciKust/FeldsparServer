using System;
using LaundryService;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LaundryServiceUT.WasherDataSetUT
{
	[TestClass]
	public class GetStateUT : LaundryBaseUT
	{
		public void CheckCurrentStateOfWasher(DateTime[] points, WasherDataSet dataSet, WasherState expectedOutcome)
		{
			foreach (var p in points)
			{
				var state = dataSet.GetState(p);
				Assert.AreEqual(expectedOutcome, state);
			}
		}

		[TestMethod]
		public void TestGetStateRutrnsIdleWhenIdleBedding14()
		{
			DateTime[] points = new DateTime[] {
				new DateTime(2021, 2, 19, 18, 15, 0),
				new DateTime(2021, 2, 19, 18, 19, 0),
				new DateTime(2021, 2, 19, 17, 20, 0),
			};

			CheckCurrentStateOfWasher(points, bedding14FullSet, WasherState.Idle);
		}

		[TestMethod]
		public void TestGetStateReturnsWashingWhenWashingBedding14()
		{
			DateTime[] points = new DateTime[] {
				new DateTime(2021, 2, 19, 17, 23, 0),
				new DateTime(2021, 2, 19, 17, 30, 0),
				new DateTime(2021, 2, 19, 17, 34, 0),
				new DateTime(2021, 2, 19, 17, 35, 0),
				new DateTime(2021, 2, 19, 17, 43, 0),
				new DateTime(2021, 2, 19, 17, 45, 0),
				new DateTime(2021, 2, 19, 17, 47, 0),
				new DateTime(2021, 2, 19, 17, 57, 0)
			};

			CheckCurrentStateOfWasher(points, bedding14FullSet, WasherState.Washing);
		}

		[TestMethod]
		public void TestGetStateReturnsSpinningWhenSpinningBedding14()
		{
			DateTime[] points = new DateTime[] {
				new DateTime(2021, 2, 19, 17, 50, 0),
				new DateTime(2021, 2, 19, 17, 52, 0),
				new DateTime(2021, 2, 19, 18, 1, 0),
				new DateTime(2021, 2, 19, 18, 5, 0),
				new DateTime(2021, 2, 19, 18, 11, 0),
				new DateTime(2021, 2, 19, 18, 12, 0),
			};

			CheckCurrentStateOfWasher(points, bedding14FullSet, WasherState.Spinning);
		}

		[TestMethod]
		public void TestGetStateReturnsIdleWhenIdleDarks16()
		{
			DateTime[] points = new DateTime[] {
				new DateTime(2021, 2, 19, 19, 48, 0),
				new DateTime(2021, 2, 19, 20, 55, 0),
				new DateTime(2021, 2, 19, 21, 4, 0),
			};

			CheckCurrentStateOfWasher(points, darks16FullSet, WasherState.Idle);
		}

		[TestMethod]
		public void TestGetStateReturnsWashingWhenWashingDarks16()
		{
			DateTime[] points = new DateTime[] {
				new DateTime(2021, 2, 19, 19, 54, 0),
				new DateTime(2021, 2, 19, 20, 1, 0),
				new DateTime(2021, 2, 19, 20, 6, 0),
				new DateTime(2021, 2, 19, 20, 12, 0),
				new DateTime(2021, 2, 19, 20, 16, 0),
				new DateTime(2021, 2, 19, 20, 20, 0),
				new DateTime(2021, 2, 19, 20, 23, 0),
				new DateTime(2021, 2, 19, 20, 25, 0),
				new DateTime(2021, 2, 19, 20, 27, 0),
				new DateTime(2021, 2, 19, 20, 35, 0),
				new DateTime(2021, 2, 19, 20, 37, 0),
				new DateTime(2021, 2, 19, 20, 40, 0),
				new DateTime(2021, 2, 19, 20, 42, 0),
			};

			CheckCurrentStateOfWasher(points, darks16FullSet, WasherState.Washing);
		}

		[TestMethod]
		public void TestGetStateReturnsSpinningWhenSpinningDarks16()
		{
			DateTime[] points = new DateTime[] {
				new DateTime(2021, 2, 19, 20, 29, 0),
				new DateTime(2021, 2, 19, 20, 30, 0),
				new DateTime(2021, 2, 19, 20, 32, 0),
				new DateTime(2021, 2, 19, 20, 47, 0),
				new DateTime(2021, 2, 19, 20, 48, 0),
				new DateTime(2021, 2, 19, 20, 50, 0),
			};

			CheckCurrentStateOfWasher(points, darks16FullSet, WasherState.Spinning);
		}

		[TestMethod]
		public void TestGetStateReturnsIdleWhenIdleHandWash18()
		{
			DateTime[] points = new DateTime[] {
				new DateTime(2021, 2, 21, 13, 6, 0),
				new DateTime(2021, 2, 21, 13, 10, 0),
				new DateTime(2021, 2, 21, 13, 13, 0),
				new DateTime(2021, 2, 21, 13, 15, 0),
				new DateTime(2021, 2, 21, 13, 53, 0),
				new DateTime(2021, 2, 21, 13, 57, 0),
			};

			CheckCurrentStateOfWasher(points, handWash18FullSet, WasherState.Idle);
		}

		[TestMethod]
		public void TestGetStateReturnsWashingWhenWashingHandWash18()
		{
			DateTime[] points = new DateTime[] {
				new DateTime(2021, 2, 21, 13, 23, 0),
				new DateTime(2021, 2, 21, 13, 32, 0),
				new DateTime(2021, 2, 21, 13, 39, 0),
				new DateTime(2021, 2, 21, 13, 45, 0),
				new DateTime(2021, 2, 21, 13, 48, 0),
			};

			CheckCurrentStateOfWasher(points, handWash18FullSet, WasherState.Washing);
		}

		[TestMethod]
		public void TestGetStateReturnsSpinningWhenSpinningHandWash18()
		{
			DateTime[] points = new DateTime[] {
				// None. This cycle doesn't go super heavy on the spin cycle. Therefore it never reaches
				// what I classify as a spin. Don't need the data to accuratly predict a done load though. 
			};

			CheckCurrentStateOfWasher(points, handWash18FullSet, WasherState.Spinning);
		}

		[TestMethod]
		public void TestGetStateReturnsIdleWhenIdleNormal13()
		{
			DateTime[] points = new DateTime[] {
				new DateTime(2021, 2, 19, 16, 1, 2, 0),
				new DateTime(2021, 2, 19, 15, 55, 41, 0),
				new DateTime(2021, 2, 19, 15, 50, 7, 0),
			};

			CheckCurrentStateOfWasher(points, normal13FullSet, WasherState.Idle);
		}

		[TestMethod]
		public void TestGetStateReturnsWashingWhenWashingNormal13()
		{
			DateTime[] points = new DateTime[] {
				new DateTime(2021, 2, 19, 16, 5, 1, 0),
				new DateTime(2021, 2, 19, 16, 11, 9, 0),
				new DateTime(2021, 2, 19, 16, 18, 36, 0),
				new DateTime(2021, 2, 19, 16, 23, 37, 0),
				new DateTime(2021, 2, 19, 16, 29, 24, 0),
			};

			CheckCurrentStateOfWasher(points, normal13FullSet, WasherState.Washing);
		}

		[TestMethod]
		public void TestGetStateReturnsSpinningWhenSpinningNormal13()
		{
			DateTime[] points = new DateTime[] {
				new DateTime(2021, 2, 19, 16, 32, 20, 0),
				new DateTime(2021, 2, 19, 16, 34, 36, 0),
				new DateTime(2021, 2, 19, 16, 35, 28, 0),
				new DateTime(2021, 2, 19, 16, 44, 4, 0),
				new DateTime(2021, 2, 19, 16, 49, 23, 0),
				new DateTime(2021, 2, 19, 16, 54, 35, 0),
			};

			CheckCurrentStateOfWasher(points, normal13FullSet, WasherState.Spinning);
		}

		[TestMethod]
		public void TestGetStateReturnsIdleWhenIdleNormal15()
		{
			DateTime[] points = new DateTime[] {
				new DateTime(2021, 2, 19, 18, 24, 0),
				new DateTime(2021, 2, 19, 18, 27, 0),
				new DateTime(2021, 2, 19, 19, 27, 0),
				new DateTime(2021, 2, 19, 19, 31, 0),
				new DateTime(2021, 2, 19, 19, 37, 0),
				new DateTime(2021, 2, 19, 19, 43, 0),
			};

			CheckCurrentStateOfWasher(points, normal15FullSet, WasherState.Idle);
		}

		[TestMethod]
		public void TestGetStateReturnsWashingWhenWashingNormal15()
		{
			DateTime[] points = new DateTime[] {
				new DateTime(2021, 2, 19, 18, 32, 0),
				new DateTime(2021, 2, 19, 18, 36, 0),
				new DateTime(2021, 2, 19, 18, 41, 0),
				new DateTime(2021, 2, 19, 18, 45, 0),
				new DateTime(2021, 2, 19, 18, 49, 0),
				new DateTime(2021, 2, 19, 18, 55, 0),
				new DateTime(2021, 2, 19, 18, 58, 0),
				new DateTime(2021, 2, 19, 19, 7, 0),
				new DateTime(2021, 2, 19, 19, 8, 0),
			};

			CheckCurrentStateOfWasher(points, normal15FullSet, WasherState.Washing);
		}

		[TestMethod]
		public void TestGetStateReturnsSpinningWhenSpinningNormal15()
		{
			DateTime[] points = new DateTime[] {
				new DateTime(2021, 2, 19, 19, 2, 0),
				new DateTime(2021, 2, 19, 19, 11, 0),
				new DateTime(2021, 2, 19, 19, 15, 0),
				new DateTime(2021, 2, 19, 19, 20, 0),
				new DateTime(2021, 2, 19, 19, 22, 0),
			};

			CheckCurrentStateOfWasher(points, normal15FullSet, WasherState.Spinning);
		}

		[TestMethod]
		public void TestGetStateReturnsIdleWhenIdleQuickWash17()
		{
			DateTime[] points = new DateTime[] {
				new DateTime(2021, 2, 21, 12, 16, 0),
				new DateTime(2021, 2, 21, 12, 18, 0),
				new DateTime(2021, 2, 21, 12, 26, 0),
				new DateTime(2021, 2, 21, 13, 2, 0),
				new DateTime(2021, 2, 21, 13, 4, 0),
			};

			CheckCurrentStateOfWasher(points, quickWash17FullSet, WasherState.Idle);
		}

		[TestMethod]
		public void TestGetStateReturnsWashingWhenWashingQuickWash17()
		{
			DateTime[] points = new DateTime[] {
				new DateTime(2021, 2, 21, 12, 27, 0),
				new DateTime(2021, 2, 21, 12, 30, 0),
				new DateTime(2021, 2, 21, 12, 33, 0),
				new DateTime(2021, 2, 21, 12, 37, 0),
				new DateTime(2021, 2, 21, 12, 46, 0),
				new DateTime(2021, 2, 21, 12, 49, 0),
				new DateTime(2021, 2, 21, 12, 52, 0),
			};

			CheckCurrentStateOfWasher(points, quickWash17FullSet, WasherState.Washing);
		}

		[TestMethod]
		public void TestGetStateReturnsSpinningWhenSpinningQuickWash17()
		{
			DateTime[] points = new DateTime[] {
				new DateTime(2021, 2, 21, 12, 40, 0),
				new DateTime(2021, 2, 21, 12, 54, 0),
				new DateTime(2021, 2, 21, 12, 57, 0),
				new DateTime(2021, 2, 21, 12, 58, 0),
			};

			CheckCurrentStateOfWasher(points, quickWash17FullSet, WasherState.Spinning);
		}
	}
}
