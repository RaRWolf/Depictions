using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Fade : MonoBehaviour
{
    public Image me;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("FadeOut");
    }

    IEnumerator FadeOut()
    {
        for (float i = 1; i >= 0; i -= Time.deltaTime/3)
        {
            me.color = new Color(0, 0, 0, i);
            yield return null;
        }
    }

    public IEnumerator FadeIn()
    {
        for (float i = 0; i <= 1; i += Time.deltaTime/5)
        {
            me.color = new Color(0, 0, 0, i);
            yield return null;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
