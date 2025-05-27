using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KartGame.UI;
public class Swipe_Controller : MonoBehaviour
{
   [SerializeField] private int maxPage;
   [SerializeField]
    int currentPage;
    private Vector3 targetPos;
    [SerializeField] private Vector3 pageStep;
    [SerializeField] private RectTransform levelPagesRect;
    [SerializeField] private LoadSceneButton loadSceneButton;
    [SerializeField] private float tweenTime;
    [SerializeField] LeanTweenType tweenType;

    private void Awake()
    {
        currentPage = 1;
        targetPos = levelPagesRect.localPosition;
    }
    public void Next()
    {
        if (currentPage < maxPage)
        {
            currentPage++;
            targetPos += pageStep;
            MovePage();
        }
    }

    public void Previous()
    {
        if (currentPage > 1)
        {
            currentPage--;
            targetPos -= pageStep;
            MovePage();
        }
    }

    public void Update()
    {
        if (loadSceneButton != null)
        {
            loadSceneButton.MapName = "Map" + currentPage;
        }
    }
    void MovePage()
    {
        levelPagesRect.LeanMoveLocal(targetPos, tweenTime).setEase(tweenType);
    }

}
