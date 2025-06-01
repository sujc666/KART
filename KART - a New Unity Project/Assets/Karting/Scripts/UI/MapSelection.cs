using UnityEngine;
using UnityEngine.UI;

public class MapSelection : MonoBehaviour
{
    [SerializeField] private Button leftButton;
    [SerializeField] private Button rightButton;
    [SerializeField] public int currentMap; // 改为public

    private void Awake()
    {
        SelectMap(0);
    }

    private void SelectMap(int _index)
    {
        currentMap = _index; // 确保更新currentMap
        leftButton.interactable = (_index != 0);
        rightButton.interactable = (_index != transform.childCount - 1);

        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(i == _index);
        }
    }

    public void ChangeMap(int _change)
    {
        currentMap += _change;
        SelectMap(currentMap);
    }
}


