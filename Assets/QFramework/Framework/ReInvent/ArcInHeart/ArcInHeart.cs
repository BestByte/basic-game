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
    }

	#region ¿ò¼Ü
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
}