using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectLV : MonoBehaviour
{
    public GameObject lockLV;
    public GameObject unlockLV;
    public bool donelv1;

    // Start is called before the first frame update
    void Start()
    {
        int lv1done = PlayerPrefs.GetInt("donelv1", 1);
        donelv1 = lv1done == 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (donelv1)
        {
            unlockLeVel();
        }
        else
        {
            lockLeVel();
        }    
    }

    void lockLeVel()
    {
        lockLV.SetActive(true);
        unlockLV.SetActive(false);
    }

    void unlockLeVel()
    {
        unlockLV.SetActive(true);
        lockLV.SetActive(false);
    }
}
