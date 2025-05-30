using UnityEngine;
using UnityEngine.UI;

public class MapSelection : MonoBehaviour
{
    [SerializeField] private Button leftButton;
    [SerializeField] private Button rightButton;
    private int currentMap;

    private void Awake()
    {
        SelectMap(0);
    }

    private void SelectMap(int _index)
    {
        leftButton.interactable = (_index != 0);
        rightButton.interactable = (_index != transform.childCount - 1);

        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(i == _index);
        }
    }

    public void ChangeMap(int _cahnge)
    {
        currentMap += _cahnge;
        SelectMap(currentMap);
    }
}


