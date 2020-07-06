using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject HpImage;
    [SerializeField]
    List<Image> hpImages=new List<Image>();
    float maximumHP = 0;
    float currentHP = 0;
    void Start()
    {
        maximumHP = currentHP = 75;
    }
    public void changeHealth(float HP)
    {
        currentHP = HP;
        float hpForImages = currentHP;
        for(int i = 0; i < hpImages.Count; i++)
        {
            if (hpForImages >= 25)
                hpImages[i].fillAmount = 1.0f;
            else
                hpImages[i].fillAmount = (float)hpForImages / 25;
            hpForImages -= 25;
        }
    }
    public void addNewHealth()
    {
        GameObject prefabImage = Instantiate(HpImage);
        prefabImage.transform.SetParent(transform);
        prefabImage.transform.localScale = new Vector3(1, 1, 1);
        hpImages.Add(prefabImage.transform.GetChild(1).GetComponent<Image>());
        maximumHP += 25;
        currentHP = maximumHP;
        changeHealth(0);
    }
}
