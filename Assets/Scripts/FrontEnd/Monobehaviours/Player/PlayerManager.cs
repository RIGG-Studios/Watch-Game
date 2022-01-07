using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class gathers input and delegates to the currentGamemode based on input
public class PlayerManager : MonoBehaviour
{
    //The players money
    public int playerMoney;

    //The player's camera
    Camera mainCamera;

    //Input actions thingy for the new input system
    InputActions inputActions;

    //Current gamemode the player is in
    public IGamemode currentGamemode;

    public IGamemode[] gameModes;

    //Initializing and cleaning up the inputActions
    private void OnEnable() => inputActions.Enable();

    private void OnDisable() => inputActions.Disable();

    private void Start()
    {
        gameModes = GetComponents<IGamemode>();

        //Setting some variables
        currentGamemode = gameModes[0];
        mainCamera = Camera.main;
    }

    public void TransitionGamemode(bool backToDefault)
    {
        if (!backToDefault)
        {
            currentGamemode = gameModes[1];
        }
        else
        {
            currentGamemode = gameModes[0];
        }
    }

    private void Awake()
    {
        //Creates a new inputActions
        inputActions = new InputActions();

        //Whenever the player moves their mouse
        inputActions.PCMap.MousePosition.performed += ctx => currentGamemode.OnMoveMousePosition(mainCamera.ScreenToWorldPoint(ctx.ReadValue<Vector2>()));

        //Whenever the player left clicks
        inputActions.PCMap.LeftClick.performed += ctx => currentGamemode.OnLeftClick();

        //Whenever the player right clicks
        inputActions.PCMap.RightClick.performed += ctx => currentGamemode.OnRightClick();

    }
}
