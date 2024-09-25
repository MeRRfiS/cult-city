using CultCity.Scripts.Interfaces;
using System;
using UnityEngine;

namespace CultCity.Scripts
{
    public class GameManager : MonoBehaviour, IGameManager
    {
        public event Action OnStorageOpen;
        public event Action OnStorageClose;

        public void CloseStorage()
        {
            OnStorageClose?.Invoke();
        }

        public void OpenStorage()
        {
            OnStorageOpen?.Invoke();
        }
    } 
}
