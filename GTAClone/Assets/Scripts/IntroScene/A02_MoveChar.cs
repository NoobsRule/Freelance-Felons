using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A02_MoveChar : MonoBehaviour
{
    public AudioSource leftFoot;
    public AudioSource rightFoot;
    public bool steppingLeft = true;
    public GameObject mainChar;
    public int stepsTacken;

    void Start()
    {
        StartCoroutine(WalkSequence());
    }

    void Update()
    {
        mainChar.transform.Translate(0, 0, 0.01f * Time.timeScale);
    }

    IEnumerator WalkSequence()
    {
        yield return new WaitForSeconds(0.4f);
        while (stepsTacken < 10)
        {
            yield return new WaitForSeconds(0.5f);
            if (steppingLeft == true)
            {
                leftFoot.Play();
                steppingLeft = false;
            }
            else
            {
                rightFoot.Play();
                steppingLeft = true;
            }
            stepsTacken += 1;
        }
        mainChar.SetActive(false);
    }
}
