using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaScript : MonoBehaviour
{
    // Start is called before the first frame update
    private Image manaImage;
    private Text manaText;
    private float maximumMana = 0;
    private float currentMana = 0;
    void Start()
    {
        manaImage=gameObject.transform.GetChild(1).GetComponent<Image>();
        manaText= gameObject.transform.GetChild(2).GetComponent<Text>();
        maximumMana = currentMana = 50;
    }

    public void updateMana(float mana) 
    {
        currentMana = mana;
        manaImage.fillAmount = currentMana / maximumMana;
        manaText.text = (((float)currentMana / maximumMana)*100).ToString("f2")+"%";
    }

}
