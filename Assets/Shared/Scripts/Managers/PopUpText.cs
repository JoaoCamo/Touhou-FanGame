using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpText : MonoBehaviour
{
    public bool active;
    public GameObject go;
    public TMPro.TMP_Text txt;
    public Vector3 motion;
    public float duration;
    public float lastShown;

    public void Show()
    {
        active = true;
        lastShown = Time.time;
        go.SetActive(active);
    }

    public void Hide()
    {
        active = false;
        go.SetActive(active);
    }

    public void UpdatePopUpText()
    {
        if(!active)
        {
            return;
        }

        if(Time.time - lastShown > duration)
        {
            Hide();
        }

        go.transform.position += motion * Time.deltaTime;
    }
}
