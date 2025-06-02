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

        // 遍历所有子物体，只激活选中的角色
        for (int i = 0; i < characterRoot.childCount; i++)
        {
            characterRoot.GetChild(i).gameObject.SetActive(i == selectedIndex);
        }

        // 设置Cinemachine虚拟摄像机的Follow和LookAt为当前激活角色
        if (virtualCamera != null && characterRoot.childCount > selectedIndex)
        {
            Transform target = characterRoot.GetChild(selectedIndex);
            virtualCamera.Follow = target;
            virtualCamera.LookAt = target;
        }
    }
}