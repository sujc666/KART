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

        // ֻ����ѡ�н�ɫǰ����ȫ�����ã��ȴ�һ֡�ټ������GUID��ͻ
        for (int i = 0; i < characterRoot.childCount; i++)
        {
            characterRoot.GetChild(i).gameObject.SetActive(false);
        }

        // �ӳټ��ȷ��Unity�ڲ��������ɷ�ע��
        StartCoroutine(ActivateSelectedCharacterNextFrame());
    }

    private System.Collections.IEnumerator ActivateSelectedCharacterNextFrame()
    {
        yield return null; // �ȴ�һ֡

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