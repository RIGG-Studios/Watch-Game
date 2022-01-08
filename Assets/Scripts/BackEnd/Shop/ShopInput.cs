using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopInput : MonoBehaviour
{
    public CanvasManager canvas;

    InputActions inputActions;
    private void OnEnable() => inputActions.Enable();

    private void OnDisable() => inputActions.Disable();

    private bool shopShown;

    private void Awake()
    {
        inputActions = new InputActions();

        inputActions.PCMap.Escape.performed += ctx => ToggleShop();
    }


    private void ToggleShop()
    {
        if (GameManager.instance.gameState != GameStates.InGame)
            return;

        if (!shopShown)
        {
            canvas.ShowElementGroup(canvas.FindElementGroupByID("ShopGroup"), false);          
            shopShown = true;
        }
        else if (shopShown)
        {

            canvas.HideElementGroup(canvas.FindElementGroupByID("ShopGroup"));
            shopShown = false;
        }
    }
}
