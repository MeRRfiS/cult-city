using CultCity.Scripts.Interfaces;
using System;
using UnityEngine;

namespace CultCity.Scripts.Interactable
{
    public class DoorEnter : Door
    {
        [SerializeField] private int _houseNumber = 0;
        [SerializeField] private Rooms _room;

        [ContextMenu("Act")]
        public override void Interact()
        {
            string place = _houseNumber != 0 ? $"House {_houseNumber}" : "Street";
            string room = GetRoomName(_room) != String.Empty ? " " + GetRoomName(_room) : String.Empty;
            var newScene = $"{place}{room}";

            _sceneLoader.LoadNewScene(newScene);
        }
    } 
}
