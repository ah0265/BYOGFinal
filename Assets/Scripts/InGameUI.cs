using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    [SerializeField] Image[] images;
    [SerializeField]
    Sprite[] sprites;
    // Start is called before the first frame update
    void Start()
    {
        InputManager.SpellEvent += DisplaySpells;
    }

    void DisplaySpells(string[] s)
    { 
        int count = 0;
        for (int i=0; i < s.Length; i++)
        {
            if (s[i] == "j")
            {
                images[count].sprite = sprites[0];
                images[count].enabled = true;
                count++;
            }
            else if (s[i] == "i")
            {
                images[count].sprite = sprites[1];
                images[count].enabled = true;
                count++;
            }
            else if (s[i] == "l")
            {
                images[count].sprite = sprites[2];
                images[count].enabled = true;

                count++;
            }
        }
        count = 0;
        StartCoroutine(DisableSpellImage());
    }
    
    IEnumerator DisableSpellImage()
    {
        yield return new WaitForSeconds(3);
        foreach (var image in images)
        {
            image.enabled = false;
        }
    }
}
