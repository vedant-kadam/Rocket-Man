using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[ExecuteInEditMode]

public class WorldGen : MonoBehaviour
{
    public GameObject _cube;

    public int scalex, scaley;
    public Transform Origin;


    private void Start()
    {
       
       // GenrateHollow();
    }

    private void Update()
    {
       if(Input.GetKeyDown(KeyCode.Escape))
        {
            //ClearMesh();
           // GenrateHollow();
        }
    }
    

     void ClearMesh()
    {
         for(int i=0;i<transform.childCount;i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }
    void GenrateHollow()
    {
        int xmid = scalex / 2;
        int ymid = scaley / 2;
        int temp1 = 0, temp2 = 0, xtemp = 0; ;
        for (int x = 0; x < scalex; x++)
        {

            for (int y = 0; y < scaley; y++)
            {
                Vector3 newpos;
                newpos.x = Origin.position.x + x;

                newpos.y = Origin.position.y + y;


                newpos.z = Origin.position.z + temp2;
                if (y < ymid)
                {
                    if (temp2 < temp1)
                    {
                        temp2++;
                    }
                }
                else
                {
                    if (scaley - 1 - y <= temp1)
                    {
                        temp2--;
                    }
                }




                GameObject newBlock = Instantiate(_cube, newpos, Quaternion.identity);
                newBlock.transform.parent = this.transform;
            }
            temp2 = 0;
            if (x < xmid)
            {
                temp1++;
                xtemp = temp1;
            }
            else
            {
                temp1--;
                xtemp = temp1;
            }

        }

    }
    
}
