using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    [SerializeField] GameObject image;

    int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Flash());
    }

   IEnumerator Flash()
    {
        image.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        i++;
        image.SetActive(false);
        while(i < 3)
        {
            StartCoroutine(Flash());
        }
    }
}
