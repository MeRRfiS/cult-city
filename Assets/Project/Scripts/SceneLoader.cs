using CultCity.Scripts.Interfaces;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CultCity.Scripts
{
	public class SceneLoader : MonoBehaviour, ISceneLoader
	{
        private string _newScene = "";
        private string _previousScene = "";
		private List<string> _scenes = new List<string>();

        private const string MainScene = "Street"; 

        private void Awake()
        {
            if(SceneManager.GetActiveScene().name != MainScene)
            {
                SceneManager.LoadSceneAsync(MainScene).completed += (AsyncOperation op) =>
                {
                    _scenes.Add(SceneManager.GetActiveScene().name);
                };
            }
            else
            {
                _scenes.Add(MainScene);
            }
        }

        public void LoadNewScene(string newScene)
        {
            _newScene = newScene;
            _previousScene = _scenes.Last();

            SceneManager.LoadScene(newScene, LoadSceneMode.Additive);

            SceneManager.sceneLoaded += SceneLoaded;
        }

        public void LoadPreviosScene()
        {
            SceneManager.UnloadSceneAsync(_scenes.Last()).completed += (AsyncOperation op) =>
            {
                Scene scene = SceneManager.GetSceneByName(_previousScene);
                
                SceneManager.SetActiveScene(scene);
                foreach (GameObject obj in scene.GetRootGameObjects())
                {
                    obj.SetActive(true);
                }

                _scenes.Remove(_scenes.Last());
                if(_scenes.Count != 1)
                {
                    _previousScene = _scenes[_scenes.Count - 2];
                }
            };
        }

        private void SceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if (scene.name == _newScene)
            {
                Scene previousScene = SceneManager.GetSceneByName(_previousScene);

                SceneManager.SetActiveScene(scene);
                foreach (GameObject obj in previousScene.GetRootGameObjects())
                {
                    obj.SetActive(false);
                }

                _scenes.Add(_newScene);

                SceneManager.sceneLoaded -= SceneLoaded;
            }
        }
    } 
}
