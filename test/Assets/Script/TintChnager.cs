using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TintChnager : MonoBehaviour
{
    

    public Material mat;  // assign via inspecto

    //color
    
    public Color colorEnd = Color.black;
    public Color[] color_pallet;
    Color tempColor;
    public float newColorChangeInterval;
    float timeleft;

    //exposure
    
    public float maxExpoure;
    public float exposureChangeDelay =50f;
    

    Color dc;
    float strttime;
    private void Start()
    {
        //new sybox colours
        mat.SetColor("_Tint", Color.white);
        mat.SetFloat("_Exposure", 0.8f);
      
    }
    private void Update()
    {   //exposure
        float exposureValur = Mathf.Abs(Mathf.Sin((Time.time / exposureChangeDelay)) * maxExpoure);
        float newExplosure = Mathf.Clamp(exposureValur, 0.7f, maxExpoure);
        mat.SetFloat("_Exposure", newExplosure);

        //color changer
        if(timeleft<=Time.deltaTime)
        {
            mat.SetColor("_Tint", colorEnd);
            tempColor = Random.ColorHSV(0f,1f,0.5f,1f,0.9f,1f,0.9f,1f);// color_pallet[Random.Range(0, color_pallet.Length)];
            timeleft = newColorChangeInterval;

        }
        else
        {
            colorEnd = Color.Lerp(colorEnd,tempColor,Time.deltaTime/timeleft);
           mat.SetColor("_Tint", colorEnd);
            timeleft -= Time.deltaTime;
        }
       
        
    }

    
}
