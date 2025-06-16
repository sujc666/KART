using Cinemachine;
using UnityEngine;

public class PlayerCharacterActivator : MonoBehaviour
{
    [Tooltip("角色父物体（如PlayerActive文件夹）")]
    public Transform characterRoot;
    public int selectedIndex;
    [Tooltip("场景中的Cinemachine虚拟摄像机")]
    public CinemachineVirtualCamera virtualCamera;

    private void Awake()
    {
        // 读取上一个场景保存的角色索引
        selectedIndex = PlayerPrefs.GetInt("SelectedCharacter", 0);

        // 只激活选中角色前，先全部禁用，等待一帧再激活，避免GUID冲突
        for (int i = 0; i < characterRoot.childCount; i++)
        {
            characterRoot.GetChild(i).gameObject.SetActive(false);
        }

        // 延迟激活，确保Unity内部组件先完成反注册
        StartCoroutine(ActivateSelectedCharacterNextFrame());
    }

    private System.Collections.IEnumerator ActivateSelectedCharacterNextFrame()
    {
        yield return null; // 等待一帧

        if (selectedIndex >= 0 && selectedIndex < characterRoot.childCount)
        {
            var target = characterRoot.GetChild(selectedIndex);
            target.gameObject.SetActive(true);

            if (virtualCamera != null)
            {
                virtualCamera.Follow = target;
                virtualCamera.LookAt = target;
            }
        }
    }
}