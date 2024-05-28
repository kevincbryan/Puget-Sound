using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SimpleHealthBar : MonoBehaviour
{

    public GameObject player;
    private Health pHealth;
    private PC pPC;
    public Slider slider;
    public bool healthStarted;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
        if (player)
        {
            pPC = player.GetComponent<PC>();
            StartCoroutine(waitStart(.1f));
           
        }

    }

    IEnumerator waitStart (float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        LateStart();
    }

    void LateStart ()
    {
        pHealth = pPC.player.health;
        Debug.Log ("PHealth has been defined" + pHealth);
        healthStarted = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (healthStarted)
        {
            if (slider)
            {
                
                slider.value = pHealth.Value / pHealth.MaxValue;
            }
        }
    }
}
