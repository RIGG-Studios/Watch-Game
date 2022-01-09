using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeTest : MonoBehaviour
{
    public Gradient timeGradient;
    public Text text;

    float time = 20;
    bool playedAnim;
    Vector3 rotationVector;
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        time -= Time.deltaTime;

        if (time > 15)
        {
            int min = Mathf.FloorToInt(time / 60);
            int sec = Mathf.FloorToInt(time % 60);

            text.text = min.ToString("00") + ":" + sec.ToString("00");
        }
        else
        {

            text.color = timeGradient.Evaluate(time / 15);
            text.text = ((int)time).ToString();

            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(rotationVector), Time.deltaTime * 5f);

        }

        if(time < 6)
        {
            if (!playedAnim)
            {
                anim.SetTrigger("pulse");
                playedAnim = true;
            }
        }
    }
}
