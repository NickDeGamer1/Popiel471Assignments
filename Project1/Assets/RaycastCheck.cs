using System;
using UnityEngine;

public class RaycastCheck : MonoBehaviour
{
    public bool CheckFloor()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 0.55f))
        {
            return true;
        }
        return false;
    }
}
