using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyRotator : MonoBehaviour
{
    public float _speedOfRotation;

    private void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * _speedOfRotation);
    }
}
