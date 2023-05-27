using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpTextManager : MonoBehaviour
{
    [SerializeField] private GameObject textContainer;
    [SerializeField] private GameObject textPrefab;

    private List<GameObject> popUpTexts = new List<GameObject>();

    private void Update()
    {
        foreach(GameObject txt in popUpTexts)
        {
            txt.GetComponent<PopUpText>().UpdatePopUpText();
        }
    }

    public void show(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        GameObject popUpText = getPopUpText();
        PopUpText put = popUpText.GetComponent<PopUpText>();

        put.txt.text = msg;
        put.txt.fontSize = fontSize;
        put.txt.color = color;
        put.transform.position = Camera.main.WorldToScreenPoint(position);
        put.motion = motion;
        put.duration = duration;

        put.Show();
    }

    private GameObject getPopUpText()
    {
        GameObject txt = popUpTexts.Find(t => !t.activeSelf);

        if(txt == null)
        {
            txt = Instantiate(textPrefab);
            txt.transform.SetParent(textContainer.transform);

            popUpTexts.Add(txt);
        }

        return txt;
    }
}
