using CultCity.Scripts.Interfaces;
using UnityEngine;
using Zenject;

namespace CultCity.Scripts.Inputs
{
    public class Input: MonoBehaviour
    {
        protected IGameManager _gameManager;

        [Inject]
        private void Construct(IGameManager gameManager)
        {
            _gameManager = gameManager;
        }
    }
}
