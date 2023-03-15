using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;


namespace Point { 

    public interface IGameModel : IModel
    {
        BindableProperty<int> Score { get; }
    }
	public class PointModel : AbstractModel, IGameModel
	{
		public BindableProperty<int> Score { get; } =new BindableProperty<int>()
		{
			Value = 0
		};

		protected override void OnInit()
		{
			
		}
	}

}