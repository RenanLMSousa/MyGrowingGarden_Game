using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepDistanceRelativeTo : MonoBehaviour
{
    public GameObject target;

    private Vector3 fixedDistance;

    private void Awake()
    {
        fixedDistance = this.target.transform.position - this.transform.position;
    }
    void Update()
    {
        this.transform.position = target.transform.position - fixedDistance;
    }
}
