using Cinemachine;
using UnityEngine;

public class PlayerCharacterActivator : MonoBehaviour
{
    [Tooltip("��ɫ�����壨��PlayerActive�ļ��У�")]
    public Transform characterRoot;
    public int selectedIndex;
    [Tooltip("�����е�Cinemachine���������")]
    public CinemachineVirtualCamera virtualCamera;
    private void Awake()
    {
        // ��ȡ��һ����������Ľ�ɫ����
        selectedIndex = PlayerPrefs.GetInt("SelectedCharacter", 0);

        // �������������壬ֻ����ѡ�еĽ�ɫ
        for (int i = 0; i < characterRoot.childCount; i++)
        {
            characterRoot.GetChild(i).gameObject.SetActive(i == selectedIndex);
        }

        // ����Cinemachine�����������Follow��LookAtΪ��ǰ�����ɫ
        if (virtualCamera != null && characterRoot.childCount > selectedIndex)
        {
            Transform target = characterRoot.GetChild(selectedIndex);
            virtualCamera.Follow = target;
            virtualCamera.LookAt = target;
        }
    }
}