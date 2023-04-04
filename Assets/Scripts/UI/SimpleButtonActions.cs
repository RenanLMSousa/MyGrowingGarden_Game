using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleButtonActions : MonoBehaviour
{
    public GameObject target;
    public GameEvent gameEvent;
    public void ChangeEnableState()
    {
        target.SetActive(!target.activeSelf);
        gameEvent?.Raise();
    }
}
