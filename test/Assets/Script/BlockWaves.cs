 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockWaves : MonoBehaviour
{
    public float amplitude, frequency;
    public float xOffset, yOffset;
    public Transform[] vBlocks;
    public Transform[] hBlocks;
    public float amplitudeModertaor;
    public float waveSpeed;

    private void Update()
    {
        foreach(Transform obj in hBlocks)
        {
           // Mathf.Sin(Time.time * obj.position.x * frequency) * amplitudeModertaor + amplitude


           // float yScale = Mathf.PerlinNoise(obj.position.x + Time.time*waveSpeed, obj.position.y + Time.time*waveSpeed) * amplitude;
           //yscale * xoffset;
            obj.localScale = new Vector3(1, Mathf.Cos(Time.time * obj.position.x * frequency) * amplitudeModertaor + amplitude * yOffset  , 1);
           
        }

        foreach(Transform obj in vBlocks)
        {
           // float xScale = Mathf.PerlinNoise(obj.position.x + Time.time * waveSpeed, obj.position.y + Time.time * waveSpeed) * amplitude;
           //xscale * yOfset
            obj.localScale = new Vector3(Mathf.Sin(Time.time * obj.position.y * frequency) * amplitudeModertaor + amplitude * xOffset,1, 1);
        }
    }

   
}
