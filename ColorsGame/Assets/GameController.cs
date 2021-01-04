using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private Square[] squares;

    [SerializeField]
    private GameObject winScreen;

    [SerializeField]
    private int nextScene;
    [SerializeField]
    private int lastLevel;

    private int lastClickedSquareOrder = 0;
    public bool IsCanClick = false;

    private void Awake()
    {
        for (int i = 0; i < squares.Length; i++)
        {
            squares[i].SetOrder(i + 1);
        }
    }

    private void Start()
    {
        StartCoroutine(ShowColors());
    }

    public void SendSquareClicked(int order)
    {
        if (!IsCanClick)
            return;

        if ((lastClickedSquareOrder < order) && (order - lastClickedSquareOrder) == 1) //click is valid
        {
            lastClickedSquareOrder = order;
            if (lastClickedSquareOrder == squares.Length)
            {
                if (nextScene == -1)
                {
                    winScreen.SetActive(true);
                }
                else
                {
                    SceneManager.LoadScene(nextScene);
                }
            }
        }
        else //missclick
        {
            Restart();
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    private IEnumerator ShowColors()
    {
        for (int i = 0; i < squares.Length; i++)
        {
            squares[i].GetComponent<SpriteRenderer>().color = squares[i].Color;
            yield return new WaitForSeconds(1.25f);
            squares[i].GetComponent<SpriteRenderer>().color = Color.white;
        }
        IsCanClick = true;
    }
}
