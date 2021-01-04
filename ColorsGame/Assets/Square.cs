using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{
    public Color Color;
    private int order = -1;
    private GameController controller;

    private void Start()
    {
        controller = FindObjectOfType<GameController>();
    }

    public void SetOrder(int value)
    {
        order = value;
    }
    public int GetOrder() => order;

    private void OnMouseDown()
    {
        controller.SendSquareClicked(order);
    }
}
