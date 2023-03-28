using QFramework;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Point { 
public class GamePassPanel : MonoBehaviour,IController
{
		public IArchitecture GetArchitecture()
		{
			return Point.Interface;
		}

		
	
}
}