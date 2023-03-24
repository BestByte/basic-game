using QFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Point
{

public interface IAchievementSystem : ISystem
{
   
}
	public class AchievementSystem : AbstractSystem, IAchievementSystem
	{
		protected override void OnInit()
		{
			
		}
	}
}