﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freezer : MonoBehaviour
{
    [Range(0f, 1.5f)]
    public float duration = 1f;
    bool isFrozen = false;
    float pendingFreezeDuration = 0f;

    public int matchOver = 0; //false

    void Update()
    {
        if(pendingFreezeDuration > 0 && !isFrozen)
        {
            StartCoroutine(DoFreeze());
            Debug.Log("made it here should be freezeing");
            matchOver = 1;
        }
    }

    public void Freeze()
    {
        pendingFreezeDuration = duration;
        //matchOver = true;
    }

    IEnumerator DoFreeze()
    {
        isFrozen = true;
        var original = Time.timeScale;
        Time.timeScale = 0f;

        yield return new WaitForSecondsRealtime(duration);

        Time.timeScale = original;
        pendingFreezeDuration = 0;
        isFrozen = false;

        
    }

}
