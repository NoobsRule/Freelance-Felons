using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalHints : MonoBehaviour
{
    public GameObject hintText;
    public GameObject hintBox;
    public static int hintNumber;

    void Update()
    {
        if (hintNumber == 1)
        {
            StartCoroutine(Hintbox());
            hintNumber = 0;
            hintText.GetComponent<Text>().text = "Mission Start Points Can Be Found At The Glowing Orange Points Around the Map";
            hintText.GetComponent<Animator>().Play("HintFade");
        }
    }

    IEnumerator Hintbox()
    {
        hintBox.SetActive(true);
        yield return new WaitForSeconds(9);
        hintBox.SetActive(false);
    }
}
