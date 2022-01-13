using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//this is a ui related class, essentially its the button/icon the player sees
//in the reserve special orders list, or the list of orders the player can do 
//whenever they want
public class SpecialOrderButton : MonoBehaviour
{
    //every button must have a corresponding watch property so when
    //the player clicks on it, we know which watch were talking about
    private WatchProperties watchProperties;

    //text for basic info such as difficulty/rewards
    public Text infoText;

    //a grid for the required items to spawn
    public Transform grid;

    //a button reference
    private Button button
    {
        get
        {
            return GetComponent<Button>();
        }
    }

    //method for setting up the button, essentially assigns all the variables and adds a onclick event to the attached button
    public void Setup(string difficulty, int reward, WatchProperties watchProperties, SpecialOrdersManager ordersManager)
    {
        //assign the watch property
        this.watchProperties = watchProperties;

        //set the info text to a string containing all info
        infoText.text = string.Format("{0} / {1} WATCHES", difficulty, reward.ToString());

        //if the assigned orders manager is not null
        if (ordersManager != null)
        {
            //then add a listener method to the onclick event on the button
            button.onClick.AddListener(delegate { ordersManager.BuildWatch(this.watchProperties); } );
        }
    }
}
