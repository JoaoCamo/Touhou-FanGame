using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpText : MonoBehaviour
{
    public TMPro.TMP_Text txt;
    public Vector3 motion;
    public float duration;
    public float lastShown;

    public void Show()
    {
        lastShown = Time.time;
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void UpdatePopUpText()
    {
        if(!this.gameObject.activeSelf)
        {
            return;
        }

        if(Time.time - lastShown > duration)
        {
            Hide();
        }

        gameObject.transform.position += motion * Time.deltaTime;
    }
}
