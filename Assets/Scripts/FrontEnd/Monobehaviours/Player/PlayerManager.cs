using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class gathers input and delegates to the currentGamemode based on input
public class PlayerManager : MonoBehaviour
{
    //The players money
    public int playerWatches;
    //the amount of watches monkeys make

    //All of the monkeys the player will own, strings do nothing, I'll probably make this a list of interfaces later on
    [HideInInspector] public List<string> monkeys;

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
    UIElementGroup specialWatch;
    UIElement difficultyText;
    UIElement timeText;

    WatchProperties queuedWatch;

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
        inventory = GetComponent<PlayerInventory>();
        canvas = FindObjectOfType<CanvasManager>();
        monkeyManager = FindObjectOfType<MonkeyManager>();
        watchManager = GetComponent<PlayerWatchManager>();
        monkeys = new List<string>();

        //Setting some variables
        currentGamemode = gameModes[0];
        mainCamera = Camera.main;

        specialWatch = canvas.FindElementGroupByID("NewSpecialOrderGroup");

        difficultyText = specialWatch.FindElement("difficultytext");
        timeText = specialWatch.FindElement("timetext");
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

    public void ResetWatch(WatchTypes type)
    {
        if (type == WatchTypes.Special)
        {
            if (queuedWatch != null)
            {
                queuedWatch = null;
            }

            queuedWatch = watchManager.GetRandomWatchFromType(WatchTypes.Special);

            int min = Mathf.FloorToInt(queuedWatch.timeToComplete / 60);
            int sec = Mathf.FloorToInt(queuedWatch.timeToComplete % 60);

            timeText.OverrideValue(min.ToString("00") + ":" + sec.ToString("00"));
            difficultyText.OverrideValue(System.Enum.GetName(typeof(WatchProperties.WatchDifficulty), queuedWatch.watchDifficulty));
            canvas.ShowElementGroup(specialWatch, false);
        }
        else
        {
            TransitionGamemode(true);

            //call the watch manager to create a new watch
            GameObject g = watchManager.CreateNewWatch(WatchTypes.Normal);

            for (int i = 0; i < gameModes.Length; i++)
            {
                gameModes[i].SetCurrentWatch(g.transform);
            }

            correctWatchHands = 0;
        }
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
        inputActions.PCMap.LeftClick.performed += ctx => OnLeftClick();

        //Whenever the player right clicks
        inputActions.PCMap.RightClick.performed += ctx => currentGamemode.OnRightClick();

        inputActions.PCMap.Space.performed += ctx => OnSpacePress();
    }

    private void OnLeftClick()
    {
        currentGamemode.OnLeftClick();
    }

    public void SetCurrentTool(ITool newTool)
    {
        GetComponent<PlayerWatchBuildingMode>().SetTool(newTool);
    }

    private void OnSpacePress()
    {
        if (gameManager.gameState != GameStates.PreGame)
            return;

        GameManager.GameLoadEvent.Invoke();
    }


    public bool CanBuyItem(int cost) => (playerWatches - cost) >= 0;

    public void AddItem(Item item)
    {
        if (item.itemName == "Monkey")
        {
            monkeys.Add(string.Empty);

            monkeyManager.SpawnMonkey();
        }

        inventory.AddItem(item, 1);
    }
}
