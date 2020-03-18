using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPosSync : MonoBehaviour
{
    public GameObject[] syncObject;
    public Transform[] syncTransform;

    public bool isUpdated;
    public string objName;
    public Transform transferTrans;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < syncObject.Length; i++)
        {
            for(int j = 0; j < syncObject.Length; j++)
            {
                syncTransform[j] = syncObject[i].transform;
            }
            
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < syncObject.Length; i++)
        {
            if (syncObject[i].activeSelf == true)
            {
                if(syncTransform[i].position != syncObject[i].transform.position || syncTransform[i].rotation != syncObject[i].transform.rotation)
                {
                    syncTransform[i] = syncObject[i].transform;

                    objName = syncObject[i].name;
                    transferTrans = syncTransform[i];
                    isUpdated = true;
                }
            }            
        }
    }



}
