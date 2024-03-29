using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;




public class Light_flicker : MonoBehaviour
{
    // LIGHT
    public Light2D myLight;
    [SerializeField] private float intens = 8;

    // TIMER
    [SerializeField] float StartTime = 3;
    [SerializeField] float CurrentTime = 0f;

    [SerializeField] Mob1_Script mob;

    // Start is called before the first frame update
    void Start()
    {
        // GET LIGHT
        myLight = GetComponent<Light2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (mob.BurnTime > 0 && CurrentTime < 0)
        {
            // RESTART TIMER
            CurrentTime = StartTime;
        }
        
        Timer();
    }

   
    private void Timer()
    {
        if ((CurrentTime > 0 && CurrentTime < 0.1) || (CurrentTime > 1 && CurrentTime < 1.1) || (CurrentTime > 2 && CurrentTime < 2.1) )
        {
            // LIGHT ON
            myLight.intensity = intens;
        }
        else
        {
            // LIGHT OFF
            myLight.intensity = 0;
        }

        // COUNT DOWN TIMER
        CurrentTime -= 1 * Time.deltaTime;

       
    }

    /*IEnumerator Light(float intens)
   {
       myLight.intensity = intens;
       yield return new WaitForSeconds(2);

   }*/

}
