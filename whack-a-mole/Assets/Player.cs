using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            RaycastHit hit; // variable of type raycasthit (info of what we hit if we hit something) 
            if (Physics.Raycast(transform.position, transform.forward, out hit))
            {
                Debug.Log(hit.transform.name); 
                if(hit.transform.GetComponent<Mole>() != null)
                {
                    Mole mole = hit.transform.GetComponent<Mole>();
                    mole.OnHit(); 
                }
            }

        }
        
    }
}
