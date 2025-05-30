using UnityEngine;
using UnityEngine.UI;

public class CharactorSelection : MonoBehaviour
{
    [SerializeField] private Button leftButton;
    [SerializeField] private Button rightButton;
    private int currentCharacter;

    private void Awake()
    {
        SelectCharacter(0);
    }

    private void SelectCharacter(int _index)
    {
        leftButton.interactable = (_index != 0);
        rightButton.interactable = (_index != transform.childCount - 1);

        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(i == _index);
        }
    }

    public void ChangeCharacter(int _change)
    {
        currentCharacter += _change;
        SelectCharacter(currentCharacter);
    }
}

