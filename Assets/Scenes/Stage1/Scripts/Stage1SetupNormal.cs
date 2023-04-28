using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1SetupNormal : StageController
{
    private void Start()
    {
        InvokeRepeating("stage1Start",0f,11f);
    }

    private void stage1Start()
    {
        StartCoroutine(LTRRow(4f, 1.5f, 5, 1, 0.9f, "doubleHalfMoon", 5, true, 0.75f));
        StartCoroutine(RTLRow(5f, 2, 2, 0, 0.7f, "roundShotPlusCone", 6));
        StartCoroutine(TLRow(11f, 0, 1, 0, -0.7f, "roundShotProgressive", 9));
    }
}