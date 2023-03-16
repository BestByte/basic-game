using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;
namespace Point {
	public class Point : Architecture<Point>
	{
		protected override void Init()
		{
			



			this.RegisterUtility<IStorage>(new PlayerPrefsStorage());
		}
	}
}