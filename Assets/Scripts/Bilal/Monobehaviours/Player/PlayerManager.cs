using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class gathers input and delegates to the currentGamemode based on input
public class PlayerManager : MonoBehaviour
{
    //The players money
    public int playerWatches;
    //the amount of watches monkeys make
    public int playerMonkeys;
    //The player's camera
    Camera mainCamera;
    //reference to the game manager
    GameManager gameManager;
    //reference to the canvas manager
    CanvasManager canvas;
    //reference to the watch manager
    PlayerWatchManager watchManager;
    //reference to the game time
    GameTime gameTime;
    //refernece to special order
    SpecialOrdersManager specialOrderManager;

    PlayerInventory inventory
    {
        get
        {
            return FindObjectOfType<PlayerInventory>();
        }
    }

    //refence to the ui element group watches
    UIElementGroup specialWatch;
    UIElement difficultyText;
    UIElement timeText;
    UIElement gameTimer;

    int correctWatchHands;

    //Input actions thingy for the new input system
    InputActions inputActions;

    //Current gamemode the player is in
    public IGamemode currentGamemode;

    public IGamemode[] gameModes;

    bool firstWatch;
    Vector2 currentMousePosition;

    //Initializing and cleaning up the inputActions
    private void OnEnable() => inputActions.Enable();

    private void OnDisable() => inputActions.Disable();

    private void Start()
    {
        gameModes = GetComponents<IGamemode>();
        gameManager = FindObjectOfType<GameManager>();
        canvas = FindObjectOfType<CanvasManager>();
        watchManager = GetComponent<PlayerWatchManager>();
        gameTime = FindObjectOfType<GameTime>();
        specialOrderManager = FindObjectOfType<SpecialOrdersManager>();

        //Setting some variables
        currentGamemode = gameModes[0];
        mainCamera = Camera.main;

        specialWatch = canvas.FindElementGroupByID("NewSpecialOrderGroup");
        gameTimer = canvas.FindElementGroupByID("GameGroup").FindElement("gametimer");

        difficultyText = specialWatch.FindElement("difficultytext");
        timeText = specialWatch.FindElement("timetext");
    }

    private void Awake()
    {
        //Creates a new inputActions
        inputActions = new InputActions();
        //Whenever the player moves their mouse
        inputActions.PCMap.MousePosition.performed += ctx =>
        {
            currentMousePosition = mainCamera.ScreenToWorldPoint(ctx.ReadValue<Vector2>());
            currentGamemode.OnMoveMousePosition(currentMousePosition);
        };

        //Whenever the player left clicks
        inputActions.PCMap.LeftClick.performed += ctx => currentGamemode.OnLeftClick(inputActions.PCMap.LeftClick.triggered && ctx.ReadValue<float>() > 0);

        //Whenever the player right clicks
        inputActions.PCMap.RightClick.performed += ctx => currentGamemode.OnRightClick();

        inputActions.PCMap.Space.performed += ctx => OnSpacePress();

        //loop throhgh the size of the inventory so we can add input corresponding to the slot #
        inputActions.PCMap._1.performed += ctx => inventory.SelectSlot(0);
        inputActions.PCMap._2.performed += ctx => inventory.SelectSlot(1);
        inputActions.PCMap._3.performed += ctx => inventory.SelectSlot(2);
        inputActions.PCMap._4.performed += ctx => inventory.SelectSlot(3);
        inputActions.PCMap._5.performed += ctx => inventory.SelectSlot(4);
        inputActions.PCMap._6.performed += ctx => inventory.SelectSlot(5);

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

    public void IncrementCorrectWatchHands()
    {
        correctWatchHands++;

        if(correctWatchHands >= 2)
        {
            GameManager.WatchBuildEndEvent.Invoke(watchManager.currentWatchProperties, true);
        }
    }

    private void OnSpacePress()
    {
        GameManager.GameLoadEvent.Invoke();
    }

    public bool CanBuildWatch(ComponentRequirement[] components)
    {
        for(int i = 0; i < components.Length; i++)
        {
            if (inventory.HasItem(components[i].itemRequirement, components[i].itemAmount))
                return true;
        }

        return false;
    }

    public void AddItem(Item item, int amount)
    {
        if (item.itemName.Contains("Monkey"))
            playerMonkeys++;

        inventory.AddItem(item, amount);
    }

    public void UpdateGamemode(GameObject watchObj)
    {
        for (int i = 0; i < gameModes.Length; i++)
            gameModes[i].SetCurrentWatch(watchObj.transform);

        correctWatchHands = 0;
    }

    public bool CanBuyItem(int cost) => (playerWatches - cost) >= 0;

    public void BuildWatch(int type) => watchManager.ResetWatch((WatchTypes)type);
}
