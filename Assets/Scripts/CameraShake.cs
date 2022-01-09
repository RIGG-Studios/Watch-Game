using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private float timeRemaining;
    private float shakePower;
    private float fadeTimer;

    private void LateUpdate()
    {
        if(timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;

            float x = Random.Range(-1f, 1f) * shakePower;
            float y = Random.Range(-1f, 1f) * shakePower;

            transform.position += new Vector3(x, y, 0);

            shakePower = Mathf.MoveTowards(shakePower, 0f, fadeTimer * Time.deltaTime);
        }
    }

    public void StartShaking(float duration, float shakePower)
    {
        timeRemaining = duration;
        fadeTimer = shakePower / duration;

        this.shakePower = shakePower;
    }
}
