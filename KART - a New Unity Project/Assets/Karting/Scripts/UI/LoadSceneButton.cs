using UnityEngine;
using UnityEngine.SceneManagement;

namespace KartGame.UI
{
    public class LoadSceneButton : MonoBehaviour
    {
        [SerializeField]
        public string MapName;
        [SerializeField]
        public string ModeName;
        [Tooltip("What is the name of the scene we want to load when clicking the button?")]
        public string SceneName;

        public void LoadTargetScene() 
        {
            SceneManager.LoadSceneAsync(SceneName);
        }
    }
}
