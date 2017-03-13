using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SwitchBrushes : MonoBehaviour
{
    [SerializeField]
    public UnityEvent myEvent;

    public void Switch()
    {
        myEvent.Invoke();
    }
}
