using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ActionBarUI : MonoBehaviour
{

    [SerializeField] private Image icon;
    [SerializeField] private GameObject inactive;
    [SerializeField] private Text cost;


    public void isCastable (bool castable)
    {
        inactive.SetActive(!castable);
        isAffordable (castable);
    }

    public void isAffordable (bool affordable)
    {
        if (affordable)
        {
            cost.color = Color.white;
        }
        else
        {
            cost.color = Color.red;
        }
    }




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
