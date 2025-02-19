using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;
    private void Start()
    {
        if(target == null)
        {
            return;
        }
    }

    private void Update()
    {
        if(target == null)
        {
            return;
        }
        Vector3 pos = transform.position;
        pos.x = target.position.x;
        pos.y = target.position.y;
        transform.position = pos;
    }
}
