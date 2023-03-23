using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;
using QFramework.PointGame;

namespace Point {
	public class Point : Architecture<Point>
	{
		protected override void Init()
		{

			this.RegisterModel<IGameModel>(new PointModel());

			this.RegisterUtility<IStorage>(new PlayerPrefsStorage());
		}
	}
}