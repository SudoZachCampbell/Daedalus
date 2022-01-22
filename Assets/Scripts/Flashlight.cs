using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField]
    private GameObject[] spotLights;
    private Dictionary<LightType, List<Color>> colours = new Dictionary<LightType, List<Color>>() {
        {   LightType.Standard, new List<Color>() { new Color(0.6f, 0.62f, 0.3f), new Color(1.0f, 0.72f, 0.51f), new Color(0.67f, 0.36f, 0.16f) } },
        {   LightType.UV, new List<Color>() { new Color(0.58f, 0f, 1.0f), new Color(0.78f, 0f, 1.0f), new Color(0.06f, 0f, 1.0f) } }
    };
    private List<Light> spotLightLights = new List<Light>();
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetLightColours(LightType type)
    {
        var selectedColours = colours[type];
        for (int i = 0; i < spotLights.Length; i++)
        {
            spotLights[i].GetComponent<Light>().color = selectedColours[i];
        }
    }

    public enum LightType
    {
        Standard,
        UV
    }
}
