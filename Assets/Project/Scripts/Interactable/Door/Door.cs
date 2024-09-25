using CultCity.Scripts.Interfaces;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace CultCity.Scripts.Interactable
{
    public class Door : MonoBehaviour, IInteractable
    {
        public enum Rooms
        {
            None = 0,
            MainRoom = 1,
            Kitchen = 2
        }

        protected ISceneLoader _sceneLoader;

        [Inject]
        private void Construct(ISceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        public virtual void Interact() { }

        protected string GetRoomName(Rooms room)
        {
            switch (room)
            {
                case Rooms.MainRoom:
                    return "Main Room";
                case Rooms.Kitchen:
                    return "Kitchen";
                default:
                    return String.Empty;
            }
        }
    }
}
