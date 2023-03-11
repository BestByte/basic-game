using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;
 namespace CountGame {


	public class DecreaseCountCommand : AbstractCommand
	{
		protected override void OnExecute()
		{
			this.GetModel<ICountModel>().Count.Value--;
		}
	}
}