using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1SetupNormal : StageController
{
    private void Start()
    {
        stage1Start();
    }

    private void stage1Start()
    {
        StartCoroutine(LTRRow(4f,1.5f,5,1,2,0.7f,"singleShot",10,true,1.25f));
        StartCoroutine(RTLRow(5f,2,2,0,2,0.9f,"roundShot16",10,true,1.5f));
        StartCoroutine(TLRow(10f,7.5f,2,2,25,0.5f,"doubleRoundShot16",5,true,1.5f));
        StartCoroutine(TRRow(12.5f,7.5f,2,2,25,-1.7f,"doubleRoundShot16",5,true,1.5f));
        StartCoroutine(RTLRow(12.5f,1.25f,7,0,2,0.8f,"singleShot",10,true,1.25f));
    }
}