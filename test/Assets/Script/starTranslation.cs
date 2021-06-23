
using UnityEngine;

public class starTranslation : MonoBehaviour
{
    public float speedoTranslation;
    public float frequency;
    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speedoTranslation*Mathf.Sin(Time.time*frequency));
    }
}
