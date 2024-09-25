using UnityEngine;

namespace CultCity.Scripts.Player
{
	[RequireComponent(typeof(Rigidbody2D))]
	public class Movement : MonoBehaviour
	{
		[SerializeField] private float _speed = 5;
		private Rigidbody2D _rb;

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        public void Move(Vector2 movement)
		{
            _rb.velocity = movement.normalized * _speed;
        }
	} 
}
