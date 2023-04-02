using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleButtonActions : MonoBehaviour
{
    public GameObject target;
    public void ChangeEnableState()
    {
        target.SetActive(!target.activeSelf);
    }
}
