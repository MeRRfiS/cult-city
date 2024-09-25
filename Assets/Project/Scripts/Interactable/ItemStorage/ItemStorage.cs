using CultCity.Scripts.Interfaces;
using UnityEngine;
using Zenject;

namespace CultCity.Scripts.Interactable
{
    public class ItemStorage : MonoBehaviour, IInteractable
    {
        [SerializeField] protected GameObject _storage;

        protected IStorageInput _storageInput;
        protected IGameManager _gameManager;

        [Inject]
        private void Construct(IStorageInput storageInput,
                               IGameManager gameManager)
        {
            _storageInput = storageInput;
            _gameManager = gameManager;
        }

        public virtual void Interact()
        {
            _gameManager.OpenStorage();

            _storageInput.Input.Storage.Close.performed += x => DisableStorage();

            _storage.SetActive(true);
        }

        private void DisableStorage()
        {
            _storage.SetActive(false);
            _gameManager.CloseStorage();
        }
    }
}
