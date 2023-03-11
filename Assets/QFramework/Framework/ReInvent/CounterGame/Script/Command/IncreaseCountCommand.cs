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
			{ Debug.Log("���� ������� �ɾ�"); }
			else if (model.Count == 10)
			{
				Debug.Log("���� ���ר�Ҿ�");
			}
			
		}
	}
}