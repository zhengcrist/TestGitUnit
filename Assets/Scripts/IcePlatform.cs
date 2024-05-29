using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IcePlatform : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    [SerializeField] Player_Script1 player;

    [SerializeField] SpriteRenderer sr;
    [SerializeField] Color m_NewColor;

    RawImage m_RawImage;
    [SerializeField] Sprite newSprite;
    [SerializeField] Sprite originSprite;
    //Select a Texture in the Inspector to change to
    // public Texture m_Texture;

    // Start is called before the first frame update
    void Awake()
    {
        rigidbody.isKinematic = true;
        rigidbody.simulated = false;
        // rigidbody.detectCollisions = false;

        //Fetch the RawImage component from the GameObject
        sr = GetComponentInChildren<SpriteRenderer>();
        originSprite = sr.GetComponent<Sprite>();
        // m_TextureOrigin = m_RawImage.texture;

        m_NewColor = new Color(0f, 0.5f, 1f, 0.5f);
        sr.color = m_NewColor;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ice"))
        {
            rigidbody.isKinematic = false;
            rigidbody.simulated = true;
            sr.color = new Color(1, 1, 1);
            //Change the Texture to be the one you define in the Inspector
            sr.sprite = newSprite;

            Debug.Log("Simulated");
            // rigidbody.detectCollisions = true;
            StartCoroutine(ReActivate());
        }
        if (col.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player sunk");
            player.life = 0;
        }
    }

    IEnumerator ReActivate()
    {
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(15);
        rigidbody.isKinematic = true;
        rigidbody.simulated = false;
        // get back to old
        sr.color = m_NewColor;
        sr.sprite = originSprite;
        Debug.Log("NOT simulated");
        // rigidbody.detectCollisions = false;
    }
}
