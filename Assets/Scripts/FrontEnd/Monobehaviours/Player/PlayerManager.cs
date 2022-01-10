using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class gathers input and delegates to the currentGamemode based on input
public class PlayerManager : MonoBehaviour
{
    //The players money
    public float playerWatches;
    //the amount of watches monkeys make
    public float watchesPerMoney = 0.001f;

    //All of the monkeys the player will own, strings do nothing, I'll probably make this a list of interfaces later on
    public List<string> monkeys;

    //The player's camera
    Camera mainCamera;
    //reference to the game manager
    GameManager gameManager;
    //reference to the canvas manager
    CanvasManager canvas;
    //reference to the player inventory
    PlayerInventory inventory;
    //reference to the monkey manager
    MonkeyManager monkeyManager;
    //reference to the watch manager
    PlayerWatchManager watchManager;


    //refence to the ui element group watches
    UIElementGroup watchesGroup;
    UIElement watchesCountText;

    int correctWatchHands;

    //Input actions thingy for the new input system
    InputActions inputActions;

    //current watch
    GameObject currentWatch;

    //Current gamemode the player is in
    public IGamemode currentGamemode;

    public IGamemode[] gameModes;

    public GameObject prefabWatch;

    //Initializing and cleaning up the inputActions
    private void OnEnable() => inputActions.Enable();

    private void OnDisable() => inputActions.Disable();

    private void Start()
    {
        gameModes = GetComponents<IGamemode>();
        gameManager = FindObjectOfType<GameManager>();
        inventory = GetComponent<PlayerInventory>();
        canvas = FindObjectOfType<CanvasManager>();
        monkeyManager = FindObjectOfType<MonkeyManager>();
        watchManager = GetComponent<PlayerWatchManager>();
        monkeys = new List<string>();

        //Setting some variables
        currentGamemode = gameModes[0];
        mainCamera = Camera.main;

        if(canvas != null)
            watchesGroup = canvas.FindElementGroupByID("GameGroup");

        watchesCountText = watchesGroup.FindElement("watchesitemquantity");
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
           GameManager.WatchBuildEndEvent.Invoke();
        }
    }

    public void ResetWatch()
    {
        TransitionGamemode(true);

        GameObject watch = watchManager.CreateNewWatch();

        for(int i = 0; i < gameModes.Length; i++)
        {
            gameModes[i].SetCurrentWatch(watch.transform);
        }

        correctWatchHands = 0;
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

        inputActions.PCMap.Space.performed += ctx => OnSpacePress();
    }

    private void OnSpacePress()
    {
        if (gameManager.gameState != GameStates.PreGame)
            return;

        GameManager.GameLoadEvent.Invoke();
    }

    private void Update()
    {
        //Loops through the list and gives the player money based on how many monkeys they have

        if (monkeys.Count > 0)
        {
            for (int i = 0; i < monkeys.Count; i++)
                playerWatches += watchesPerMoney;

            watchesCountText.OverrideValue(string.Format("{0} WATCHES BUILT", (int)playerWatches));
        }

    }

    public bool CanBuyItem(int cost) => (playerWatches - cost) >= 0;

    public void AddItem(Item item)
    {
        if (item.itemName == "Monkey")
        {
            watchesGroup.FindElement("monkeyitemquantity").OverrideValue(string.Format("{0} MONKEYS BOUGHT", monkeys.Count + 1));
            monkeys.Add(string.Empty);

            monkeyManager.SpawnMonkey();
        }

        inventory.AddItem(item, 1);
    }
}
