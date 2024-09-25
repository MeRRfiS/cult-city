using CultCity.Scripts.Inputs;
using CultCity.Scripts.Interfaces;
using UnityEngine;
using Zenject;

namespace CultCity.Scripts.Installers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private SceneLoader _sceneLoader;
        [SerializeField] private StorageInput _storageInput;
        [SerializeField] private GameManager _gameManager;

        public override void InstallBindings()
        {
            BindSceneLoader();
            BindStorageInput();
            BindGameManager();
        }

        private void BindGameManager()
        {
            Container.Bind<IGameManager>().FromInstance(_gameManager).AsSingle();
        }

        private void BindStorageInput()
        {
            Container.Bind<IStorageInput>().FromInstance(_storageInput).AsSingle();
        }

        private void BindSceneLoader()
        {
            Container.Bind<ISceneLoader>().FromInstance(_sceneLoader).AsSingle();
        }
    } 
}