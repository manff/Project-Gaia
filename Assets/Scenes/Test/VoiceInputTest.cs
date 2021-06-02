using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceInputTest : MonoBehaviour
{
    public Transform target;

    public bool shouldShow = true;

    void Update()
    {
        if (!shouldShow)
        {
            target.localScale = Vector3.Lerp(target.localScale, Vector3.zero, Time.deltaTime * 10);
        } else
        {
            target.localScale = Vector3.Lerp(target.localScale, Vector3.one, Time.deltaTime * 10);
        }
    }

    public void Show()
    {
        shouldShow = true;
    }

    public void Hide()
    {
        shouldShow = false;
    }
}
