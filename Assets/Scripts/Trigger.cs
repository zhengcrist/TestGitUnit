using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Trigger : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI interText;

    [SerializeField] string[] textgp; // for gamepad
    [SerializeField] string[] textfr; // for azerty
    [SerializeField] string[] texten; // for qwerty

    [SerializeField] int times = 0;
    [SerializeField] int requiredtime;

    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!ChangeScene.gamend)
        {
            // if collision with player, player gets damage
            if (collision.gameObject.tag == "Player")
            {
                times++;
                if (times == requiredtime)
                {
                    if (MainMenu.gamepad)
                    {
                        StartCoroutine(triggerCoroutine(textgp));
                    }
                    else if (Application.systemLanguage == SystemLanguage.French)
                    {
                        StartCoroutine(triggerCoroutine(textfr));
                    }
                    else
                    {
                        StartCoroutine(triggerCoroutine(texten));
                    }
                }

            }
        }
        
    }

    IEnumerator triggerCoroutine(string[] text)
    {
        int i = 0;
        while (i < text.Length)
        {
            interText.text = text[i];
            yield return new WaitForSeconds(2f);
            i++;
        }
        interText.text = "";
    }

}
