using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public float spawnInterval;
    [SerializeField] float xRange;
    [SerializeField] float negativeYRange;
    [SerializeField] float positiveYRange;
    public Transform parentTransform;
    public GameObject spaceBlockPrefab;
    public Collider[] colliders;
    public float radius;

    public LayerMask noSpawnMask;

    bool canSpawnAgain = true;
    [SerializeField] float maxChildcount;


    private void Update()
    {
       if(canSpawnAgain)
        {
            canSpawnAgain = !canSpawnAgain;
            Spawn();
        }
       
    }
    void Spawn()
    {
        int safetyNet = 0;
        
        float xSpanPoint = Random.Range(-xRange, xRange);
        float ySpawnPoint = Random.Range(negativeYRange, positiveYRange);
        Vector3 newSpawnPosition = new Vector3(xSpanPoint, ySpawnPoint, 5f);
        bool canSpawn = CanWeSpawnHere(newSpawnPosition);
        while(!canSpawn)
        {
             xSpanPoint = Random.Range(-xRange, xRange);
             ySpawnPoint = Random.Range(negativeYRange, positiveYRange);
             newSpawnPosition = new Vector3(xSpanPoint, ySpawnPoint, 5f);
             canSpawn = CanWeSpawnHere(newSpawnPosition);
            safetyNet++;
            if(safetyNet>100)
            {
                Debug.Log("noSex");
                break;
            }

        }
        if(parentTransform.childCount>maxChildcount)
        {
            canSpawnAgain = true;
            canSpawn = false;
            return;

        }
       
       
            GameObject spawnedObj = Instantiate(spaceBlockPrefab, newSpawnPosition, Quaternion.identity);
            spawnedObj.transform.parent = parentTransform;
            Invoke("canSpawnAgingTrue", spawnInterval);
       
        
         

    }
   bool CanWeSpawnHere(Vector3 spawnPosition)
    {
        bool isQkToSpawn = false;
        colliders = Physics.OverlapSphere(spawnPosition, radius,noSpawnMask);
        ///Debug.Log(colliders.Length);
        if(colliders.Length >0)
        {
            isQkToSpawn = false;
        }
        else
        {
            isQkToSpawn = true;
        }

    
        return isQkToSpawn;
    }
   void canSpawnAgingTrue()
    {
        canSpawnAgain = true;
    }

   

}
