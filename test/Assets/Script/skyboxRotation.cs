using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skyboxRotation : MonoBehaviour
{
    public float skyboxRotationSpeed = 2f;
    public Material newSkybox;

    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * skyboxRotationSpeed);
    }
}
