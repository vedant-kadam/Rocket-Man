
using UnityEngine;

public class RocketMovement : MonoBehaviour
{
    public Transform target;
    public float rocketSpeed;
    public float rocketRotationSpeed;
   
    private void Start()
    {
       
    }

    private void Update()
    {

       
        Vector3 directionVector = target.position - transform.position;
        float zRotation = Vector3.SignedAngle(Vector3.up, directionVector,Vector3.forward);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, 0f, zRotation), Time.deltaTime * rocketRotationSpeed);//Quaternion.Euler(0f, 0f, zRotation);

        transform.Translate(Vector3.up * Time.deltaTime * rocketSpeed);



    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.transform.tag == "Player")
        {
            Debug.Log("i love you khaire mavshi");
        }
    }

}
