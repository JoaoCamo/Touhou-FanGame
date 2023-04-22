using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpTextManager : MonoBehaviour
{
    [SerializeField] private GameObject textContainer;
    [SerializeField] private GameObject textPrefab;

    private List<PopUpText> popUpTexts = new List<PopUpText>();

    private void Update()
    {
        foreach(PopUpText txt in popUpTexts)
        {
            txt.UpdatePopUpText();
        }
    }

    public void show(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        PopUpText popUpText = getPopUpText();

        popUpText.txt.text = msg;
        popUpText.txt.fontSize = fontSize;
        popUpText.txt.color = color;
        popUpText.go.transform.position = Camera.main.WorldToScreenPoint(position);
        popUpText.motion = motion;
        popUpText.duration = duration;

        popUpText.Show();
    }

    private PopUpText getPopUpText()
    {
        PopUpText txt = popUpTexts.Find(t => !t.active);

        if(txt == null)
        {
            txt = new PopUpText();
            txt.go = Instantiate(textPrefab);
            txt.go.transform.SetParent(textContainer.transform);
            txt.txt = txt.go.GetComponent<TMPro.TMP_Text>();

            popUpTexts.Add(txt);
        }

        return txt;
    }
}
