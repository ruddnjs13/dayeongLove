using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstcleMove : MonoBehaviour
{
    [SerializeField] private int _moveSpeed;

    private void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x-0.09f, transform.position.y,transform.position.z);
    }
}
