using UnityEngine;
using UnityEngine.UI;

public class CharactorSelection : MonoBehaviour
{
    [SerializeField] private Button leftButton;
    [SerializeField] private Button rightButton;
    private int currentCharacter;

    // 添加一个标志来跟踪是否已经初始化角色选择
    private bool hasInitialized = false;

    private void Awake()
    {
        // 只在第一次初始化时调用
        if (!hasInitialized)
        {
            SelectCharacter(0);
            hasInitialized = true;
        }
    }

    private void SelectCharacter(int _index)
    {
        // 确保索引在有效范围内
        _index = Mathf.Clamp(_index, 0, transform.childCount - 1);
        
        // 保存当前选择的角色索引
        currentCharacter = _index;
        
        leftButton.interactable = (_index != 0);
        rightButton.interactable = (_index != transform.childCount - 1);

        // 在激活新角色前，确保所有角色都被禁用
        for (int i = 0; i < transform.childCount; i++)
        {
            // 只修改状态变化的对象，避免不必要的SetActive调用
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
    
    // 添加这个方法，在ControlsImage关闭时调用，确保维持当前角色选择
    public void MaintainCurrentCharacter()
    {
        // 重新应用当前角色选择，而不是默认回到第一个
        SelectCharacter(currentCharacter);
    }
    
    // 用于在脚本启用时维持当前选择的角色
    private void OnEnable()
    {
        if (hasInitialized)
        {
            // 确保使用当前选择的角色，而不是默认的第一个
            SelectCharacter(currentCharacter);
        }
    }
}

