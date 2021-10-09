using System;
using System.Collections.Generic;
using System.IO;
using LaundryService;

namespace LaundryServiceUT
{
	public class LaundryBaseUT
	{
		private static WasherDataSet ReadFromCsv(string csvName)
		{
			List<AxisReading> data = new();
			using (var reader = new StreamReader(csvName))
			{
				while (!reader.EndOfStream)
				{
					var line = reader.ReadLine();
					var values = line.Split(',');

					double timeAsDouble = Double.Parse(values[0]);
					double x = Double.Parse(values[1]);
					double y = Double.Parse(values[2]);
					double z = Double.Parse(values[3]);

					DateTime time = DateTime.FromOADate(timeAsDouble);
					AxisReading a = new AxisReading(x, y, z, time);
					data.Add(a);
				}
			}

			return new WasherDataSet(data);
		}

		protected static WasherDataSet normal13FullSet = ReadFromCsv("13 - Normal.csv");
		protected static WasherDataSet bedding14FullSet = ReadFromCsv("14 - Bedding.csv");
		protected static WasherDataSet normal15FullSet = ReadFromCsv("15 - Normal.csv");
		protected static WasherDataSet darks16FullSet = ReadFromCsv("16 - Darks.csv");
		protected static WasherDataSet quickWash17FullSet = ReadFromCsv("17 - Quick Wash.csv");
		protected static WasherDataSet handWash18FullSet = ReadFromCsv("18 - Hand Wash.csv");
	}
}
