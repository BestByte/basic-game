using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QFramework.ArcinHeart
{
    public class ArcInHeart : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
		private void OnGUI()
		{
			if (GUILayout.Button("+"))
			{
				new IncreaseCountCommand().Execute();
			}
			if (GUILayout.Button("-"))
			{
				new DecreaseCountCommand().Execute();
			}
		}
	}

	#region ���
    public interface ICommand
    {
        void Execute();
    }

    public class BindableProperty<T>
    {
        private T mValue = default;
        public T Value
        {
            get => mValue;
            set
            {
                if (mValue!=null&&mValue.Equals(value))
                {
                    return;
                }
                mValue = value;

               OnValueChanged?.Invoke(mValue);
            }
        }

        public event Action<T> OnValueChanged = _ => { };
    }
	#endregion

	#region  ����model
    public static class CounterModel
    {
        public static BindableProperty<int> Counter = new BindableProperty<int> ()
        { Value = 0};
    }
	#endregion

	#region ����command
    public struct IncreaseCountCommand : ICommand
    {
        public void Execute() { CounterModel.Counter.Value++; }
    }

    public struct DecreaseCountCommand : ICommand
    {
        public void Execute() { CounterModel.Counter.Value--;}
    }
	#endregion
  
}