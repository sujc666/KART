using UnityEngine;
using UnityEngine.UI;

public class CharactorSelection : MonoBehaviour
{
    [SerializeField] private Button leftButton;
    [SerializeField] private Button rightButton;
    private int currentCharacter;

    // ���һ����־�������Ƿ��Ѿ���ʼ����ɫѡ��
    private bool hasInitialized = false;

    private void Awake()
    {
        // ֻ�ڵ�һ�γ�ʼ��ʱ����
        if (!hasInitialized)
        {
            SelectCharacter(0);
            hasInitialized = true;
        }
    }

    private void SelectCharacter(int _index)
    {
        // ȷ����������Ч��Χ��
        _index = Mathf.Clamp(_index, 0, transform.childCount - 1);
        
        // ���浱ǰѡ��Ľ�ɫ����
        currentCharacter = _index;
        
        leftButton.interactable = (_index != 0);
        rightButton.interactable = (_index != transform.childCount - 1);

        // �ڼ����½�ɫǰ��ȷ�����н�ɫ��������
        for (int i = 0; i < transform.childCount; i++)
        {
            // ֻ�޸�״̬�仯�Ķ��󣬱��ⲻ��Ҫ��SetActive����
            if (transform.GetChild(i).gameObject.activeSelf != (i == _index))
            {
                transform.GetChild(i).gameObject.SetActive(i == _index);
            }
        }
    }

    public void ChangeCharacter(int _change)
    {
        currentCharacter += _change;
        SelectCharacter(currentCharacter);
    }
    
    // ��������������ControlsImage�ر�ʱ���ã�ȷ��ά�ֵ�ǰ��ɫѡ��
    public void MaintainCurrentCharacter()
    {
        // ����Ӧ�õ�ǰ��ɫѡ�񣬶�����Ĭ�ϻص���һ��
        SelectCharacter(currentCharacter);
    }
    
    // �����ڽű�����ʱά�ֵ�ǰѡ��Ľ�ɫ
    private void OnEnable()
    {
        if (hasInitialized)
        {
            // ȷ��ʹ�õ�ǰѡ��Ľ�ɫ��������Ĭ�ϵĵ�һ��
            SelectCharacter(currentCharacter);
        }
    }
}

