﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
	public class Car
	{
		string color = "red";
		string model = "red";

		public Car()
		{

		}
		static void Test(string[] args)
		{
			Car myObj = new Car();
			Console.WriteLine(myObj.color);
		}
	}
}
