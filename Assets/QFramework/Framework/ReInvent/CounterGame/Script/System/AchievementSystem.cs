using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;
namespace CountGame { 

    public interface IAchievementSystem:ISystem { 
	}
	public class AchievementSystem : AbstractSystem, IAchievementSystem
	{

         protected override void OnInit()
		{
			
		}
	}
}
