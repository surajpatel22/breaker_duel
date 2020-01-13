using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class difficultyMenu : MonoBehaviour
{
    public GameObject l1;
    public GameObject l2;
    public GameObject l3;
    bool lev = true;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.DeleteAll();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void dif()
    {
        if (!lev)
        {
            l1.SetActive(false);
            l2.SetActive(false);
            l3.SetActive(false);
            lev = true;
        }
        else
        {
            l1.SetActive(true);
            l2.SetActive(true);
            l3.SetActive(true);
            lev = false;
        }
    }
}
