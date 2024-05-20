using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionAvailable : MonoBehaviour
{
    [SerializeField] private GameObject Potion;

    // [SerializeField] Inventory_Script inventory;

    RawImage m_RawImage;
    public Texture m_TextureOrigin;
    //Select a Texture in the Inspector to change to
    public Texture m_Texture;

    // Start is called before the first frame update
    void Start()
    {
        // inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory_Script>();
        //Fetch the RawImage component from the GameObject
        m_RawImage = GetComponent<RawImage>();
        m_TextureOrigin = m_RawImage.texture;
    }

    // Update is called once per frame
    void Update()
    {
        if (Potion.CompareTag("Green"))
        {
            if (Inventory_Script.MedNum >= 1 && Inventory_Script.OilNum >= 1 && Inventory_Script.ToadNum >= 1)
            {
                //Change the Texture to be the one you define in the Inspector
                m_RawImage.texture = m_Texture;
            }
            else
            {
                m_RawImage.texture = m_TextureOrigin;
            }
        }
        

        if (Potion.CompareTag("Red"))
        {
            if (Inventory_Script.OilNum >= 2)
            {
                //Change the Texture to be the one you define in the Inspector
                m_RawImage.texture = m_Texture;
            }
            else
            {
                m_RawImage.texture = m_TextureOrigin;
            }
        }

        if (Potion.CompareTag("Blue"))
        {
            if (Inventory_Script.ToadNum >= 2)
            {
                //Change the Texture to be the one you define in the Inspector
                m_RawImage.texture = m_Texture;
            }
            else
            {
                m_RawImage.texture = m_TextureOrigin;
            }
        }
    }
}
