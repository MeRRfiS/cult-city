using CultCity.Scripts.Interfaces;
using UnityEngine;

namespace CultCity.Scripts.Inputs
{
	public class StorageInput : Input, IStorageInput
    {
        public StorageInputAction Input { get; set; }

        private void Awake()
        {
            Input = new();

            Input.Enable();
        }

        private void OnDestroy()
        {
            Input.Disable();
        }
    } 
}
