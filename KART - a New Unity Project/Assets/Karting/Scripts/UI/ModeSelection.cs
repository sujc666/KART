using UnityEngine;
using UnityEngine.UI;

public class ModeSelection : MonoBehaviour
{
    [SerializeField] private Button leftButton;
    [SerializeField] private Button rightButton;
    [SerializeField] public int currentMode; // 改为public

    private void Awake()
    {
        SelectMode(0);
    }

    private void SelectMode(int _index)
    {
        currentMode = _index; // 确保更新currentMode
        leftButton.interactable = (_index != 0);
        rightButton.interactable = (_index != transform.childCount - 1);

        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(i == _index);
        }
    }

    public void ChangeMode(int _change)
    {
        currentMode += _change;
        SelectMode(currentMode);
    }
}


