using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Achivements : MonoBehaviour
{
    public GameObject achivementWindow;
    public GameObject Holder;
    private Image image;
    private Text Nadpis, Popis;

    public Sprite[] Images;
    public string[] Names;
    public string[] Descritions;
    private void Awake()
    {
        if (PlayerPrefs.GetInt("Achivment") == 1)
        {
            GameObject go = Instantiate(achivementWindow, Holder.transform);
            image = go.transform.Find("Image").GetComponent<Image>();
            Nadpis = go.transform.Find("Text").GetComponent<Text>();
            Popis = go.transform.Find("Popis").GetComponent<Text>();
            image.sprite = Images[0];
            Nadpis.text = Names[0];
            Popis.text = Descritions[0];
            Destroy(go, 5f);
        }
    }
    public void Smurin()
    {
        if (PlayerPrefs.GetInt("Smurfing") == 1)
        {
            GameObject go = Instantiate(achivementWindow, Holder.transform.position, Holder.transform.rotation, Holder.transform);
            image = go.transform.Find("Image").GetComponent<Image>();
            Nadpis = go.transform.Find("Text").GetComponent<Text>();
            Popis = go.transform.Find("Popis").GetComponent<Text>();
            image.sprite = Images[1];
            Nadpis.text = Names[1];
            Popis.text = Descritions[1];
            Destroy(go, 5f);
        }
    }
}
