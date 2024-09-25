using CultCity.Scripts.Interfaces;
using UnityEngine;

namespace CultCity.Scripts.Player
{
	public class Act : MonoBehaviour
	{
        [SerializeField] private Transform _actOrigin;
        [SerializeField] private float _radius = 2f;
        [SerializeField] private LayerMask _layer;

        private IInteractable _interactable;

        private void Update()
        {
            if (!gameObject.activeInHierarchy) return;

            var hit = Physics2D.CircleCast(_actOrigin.position, _radius, transform.position, 0, _layer);

            if (hit)
            {
                _interactable = hit.collider.GetComponent<IInteractable>();
            }
            else
            {
                _interactable = null;
            }
        }

        public void ActFithObject()
		{
            if (!gameObject.activeInHierarchy) return;
            if (_interactable == null) return;

            _interactable.Interact();
        }
	} 
}
