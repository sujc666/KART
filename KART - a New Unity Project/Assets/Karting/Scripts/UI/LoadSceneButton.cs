using UnityEngine;
using UnityEngine.SceneManagement;


namespace KartGame.UI
{
    public class LoadSceneButton : MonoBehaviour
    {
        [Header("场景角色构建配置")]
        [SerializeField] private MapSelection mapSelection; 
        [SerializeField] private ModeSelection modeSelection;
        [SerializeField] private CharacterSelection characterSelection;

        [SerializeField] private string[] mapNames = { "CandyScene", "CityScene" };
        [SerializeField] private string[] modeNames = { "Lap", "Checkpoint", "Crash" };

        [Tooltip("如果设置，将覆盖动态生成的场景名称")]
        public string SceneName;

        [Header("调试信息")]
        [SerializeField]
        [Tooltip("只读，显示当前选择的地图")]
        private string currentMapName;

        [SerializeField]
        [Tooltip("只读，显示当前选择的模式")]
        private string currentModeName;

        private void Update()
        {
            // 在编辑器中显示当前选择（调试用）
            if (mapSelection != null && mapSelection.currentMap < mapNames.Length)
                currentMapName = mapNames[mapSelection.currentMap];

            if (modeSelection != null && modeSelection.currentMode < modeNames.Length)
                currentModeName = modeNames[modeSelection.currentMode];
        }

        // 获取要加载的场景名称
        private string GetTargetSceneName()
        {
            // 如果指定了SceneName，则使用它
            if (!string.IsNullOrEmpty(SceneName))
                return SceneName;

            // 否则根据选择构建场景名称
            string mapName = GetSelectedMapName();
            string modeName = GetSelectedModeName();
            SceneName = $"{mapName}_{modeName}";
            return SceneName;
        }

        // 获取当前选择的地图名称
        public string GetSelectedMapName()
        {
            if (mapSelection == null || mapSelection.currentMap >= mapNames.Length)
                return "CandyScene"; // 默认地图

            return mapNames[mapSelection.currentMap];
        }

        // 获取当前选择的模式名称
        public string GetSelectedModeName()
        {
            if (modeSelection == null || modeSelection.currentMode >= modeNames.Length)
                return "Lap"; // 默认模式

            return modeNames[modeSelection.currentMode];
        }

        public void LoadTargetScene()
        {
            // 保存角色选择
            if (characterSelection != null)
            {
                PlayerPrefs.SetInt("SelectedCharacter", characterSelection.GetCurrentCharacterIndex());
            }
            string targetScene = GetTargetSceneName();
            Debug.Log($"加载场景: {targetScene}");
            SceneManager.LoadSceneAsync(targetScene);
        }
    }
}
