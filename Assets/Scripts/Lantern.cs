using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lantern : MonoBehaviour
{
    [SerializeField] private float minOffset;
    [SerializeField] private float maxOffset;
    [SerializeField] private int number;
    
    private void Update()
    {
        Vector3 diference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        if (diference.x < 0)
        {
            float rotateZ = Mathf.Atan2(diference.y * number, diference.x * -1) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, Mathf.Clamp(rotateZ, minOffset, maxOffset));
        }
        else
        {
            float rotateZ = Mathf.Atan2(diference.y * number, diference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, Mathf.Clamp(rotateZ, minOffset, maxOffset));
        }
    }
}
