using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField]
    private GameObject[] spotLights;
    private List<Light> lightColours;
    // Start is called before the first frame update
    void Start()
    {
        foreach(var spot in spotLights)
        {
            lightColours.Add(spot.GetComponent<Light>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
