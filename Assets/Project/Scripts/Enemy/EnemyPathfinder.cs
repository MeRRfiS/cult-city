using UnityEngine;
using UnityEngine.AI;

namespace CultCity.Scripts.Enemy
{
	public class EnemyPathfinder : MonoBehaviour
	{
		[SerializeField] private Transform _target;
        private NavMeshAgent _agent;

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
            _agent.updateRotation = false;
            _agent.updateUpAxis = false;
        }

        private void Update()
        {
            _agent.SetDestination(_target.position);
        }
    } 
}
