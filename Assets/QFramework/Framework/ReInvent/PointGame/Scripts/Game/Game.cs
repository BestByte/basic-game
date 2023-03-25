using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;
namespace Point { 
	/// <summary>
	/// controller 
	/// </summary>
public class Game : MonoBehaviour,IController
{
		public IArchitecture GetArchitecture()
		{
			return Point.Interface; 
		}

		
		private void OnGameStart(GameStartEvent gameStartEvent)
		{

		}

		private void Awake()
		{
			//register  event 
			this.RegisterEvent<GameStartEvent>(OnGameStart);
		}
	}
}