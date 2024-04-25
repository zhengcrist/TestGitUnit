using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Trigger : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI interText;

    [SerializeField] string[] text;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if collision with player, player gets damage
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(triggerCoroutine());
        }
    }

    IEnumerator triggerCoroutine()
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
