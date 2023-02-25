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
        public T value;
    }
	#endregion
}