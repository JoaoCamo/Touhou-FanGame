using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1SetupNormal : StageController
{
    private void Start()
    {
        InvokeRepeating("bruh",1f,10f);
    }

    private void bruh()
    {
        StartCoroutine(LTRRow(3f, 1, 5, 1, 0.9f, "doubleHalfMoon", 5, true, 1.25f));
        StartCoroutine(RTLRow(4f, 2, 2, 0, 0.7f, "doubleRoundShot16", 6));
        StartCoroutine(TLRow(10f, 0, 1, 0, -0.7f, "roundShotProgressive", 8));
    }
}
