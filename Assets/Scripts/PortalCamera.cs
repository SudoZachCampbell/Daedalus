using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour
{
    private GameObject sun;
    private Portal portal;
    // Start is called before the first frame update
    void Start()
    {
        sun = GameObject.Find("Sun");
        portal = transform.parent.GetComponent<Portal>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Turn off the bit using an AND operation with the complement of the shifted int:
    private void Hide()
    {
    }


}
