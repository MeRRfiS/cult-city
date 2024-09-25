using UnityEngine;

namespace CultCity.Scripts.Interactable
{
    public class DoorExit : Door
    {
        [ContextMenu("Act")]
        public override void Interact()
        {
            _sceneLoader.LoadPreviosScene();
        }
    } 
}
