using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_TextGenerator : MonoBehaviour
{
    public GameObject[] toText;
    public int i;
    public enum OptionToShow { ammo,health};
    public OptionToShow whatText;
    void Update()
    {
        switch (whatText)
        {
            case OptionToShow.ammo:
        gameObject.GetComponent<Text>().text = toText[i].GetComponent<PlayerShooting>().ammoAmount();
                break;
            case OptionToShow.health:
                gameObject.GetComponent<Text>().text = toText[i].GetComponent<Fire>().HealthLevel().ToString();
                break;
        }
    }
}
