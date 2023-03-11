using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using QFramework;

namespace CountGame {
	public class IncreaseCountCommand : AbstractCommand
	{

		protected override void OnExecute()
		{
			var model=this.GetModel<ICountModel>();
			model.Count.Value++;

			if (model.Count == 5)
			{ Debug.Log("触发 点击达人 成就"); }
			else if (model.Count == 10)
			{
				Debug.Log("触发 点击专家就");
			}
			
		}
	}
}