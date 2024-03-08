using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraShake : MonoBehaviour
{

    public float power = 0.7f;
    public float duration = 1.0f;
    public float slowDownAmount = 1.0f;

    public static bool shouldShake = false;

    private Transform cameraTransform;

    Vector3 startPos;
    float initialDuration;

    void Start()
    {
        cameraTransform = Camera.main.transform;
        startPos = cameraTransform.localPosition;
        initialDuration = duration;
    }

    void Update()
    {
        if (shouldShake)
        {
            if (duration > 0)
            {
                cameraTransform.localPosition = startPos + Random.insideUnitSphere * power;
                duration -= Time.deltaTime * slowDownAmount;
            }
            else
            {
                shouldShake = false;
                duration = initialDuration;
                cameraTransform.localPosition = startPos;
            }
        }
    }
}
