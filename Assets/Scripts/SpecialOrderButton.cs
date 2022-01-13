using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpecialOrderButton : MonoBehaviour
{
    private WatchProperties watchProperties;
    public Text infoText;

    public Transform grid;

    private Button button
    {
        get
        {
            return GetComponent<Button>();
        }
    }


    public void Setup(string difficulty, int reward, WatchProperties watchProperties, SpecialOrdersManager ordersManager)
    {
        this.watchProperties = watchProperties;

        infoText.text = string.Format("{0} / {1} WATCHES", difficulty, reward.ToString());

        if (ordersManager != null)
        {
            button.onClick.AddListener(delegate { ordersManager.BuildWatch(this.watchProperties); } );
        }
    }
}
