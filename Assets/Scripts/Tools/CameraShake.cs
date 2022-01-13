using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : EventBase
{
    public float duration;
    public float magnitude;
    private IEnumerator Shake()
    {
        Vector3 originalPos = transform.localPosition;

        float t = 0.0f;

        while(t < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(x, y, originalPos.z);

            t += Time.deltaTime;

            yield return null;
        }
    }

    public override void ObjectInsertedCallback()
    {
        StartCoroutine(Shake());
    }

}
