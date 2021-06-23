using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBehaviour : MonoBehaviour
{
    [SerializeField] Animator blockAnimator;
     [SerializeField] ParticleSystem boost;
    [SerializeField] float DeacticationTime;
    private void Start()
    {
        blockAnimator = GetComponentInParent<Transform>().GetComponentInParent<Animator>();
      //blockAnimator = GetComponentInParent<Animator>();
        boost = transform.GetChild(0).GetComponent<ParticleSystem>();
    }
    private void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
       if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Rigidbody>().AddForce(transform.up * Time.deltaTime * 50, ForceMode.Impulse);
            LaunchTheBlock();
            Destroy(transform.parent.transform.parent.gameObject, 5f);
        }
    }
    void LaunchTheBlock()
    {
        blockAnimator.enabled = true;
        boost.Play();
        Invoke("DeactivateGameObject", DeacticationTime);
    }
    void DeactivateGameObject()
    {
        blockAnimator.enabled = false;
        transform.parent.gameObject.SetActive(false);
       
    }
}
