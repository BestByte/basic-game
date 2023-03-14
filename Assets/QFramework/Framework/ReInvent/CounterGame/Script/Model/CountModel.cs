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
		public BindableProperty<int> Count { get; } = new BindableProperty<int>()
			{
		Value=0};

		protected override void OnInit()
		{

			var storage =this .GetUtility <IStorage>();
			Count.SetValueWithoutEvent(storage.LoadInt(nameof(Count)));

			Count .Register(newcount=>
			{
				storage.SaveInt(nameof(Count),newcount);
			});

		}
	}


}