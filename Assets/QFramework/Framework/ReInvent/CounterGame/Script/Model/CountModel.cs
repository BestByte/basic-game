using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;
namespace CountGame { 
    public interface ICountModel : IModel
    {
        BindableProperty<int> Count { get; }
    }
	public class CountModel : AbstractModel, ICountModel
	{
		/// <summary>
		/// count
		/// </summary>
		public BindableProperty<int> Count { get; } =new BindableProperty<int>();

		protected override void OnInit()
		{
			
		}
	}


}