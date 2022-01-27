using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public bool canFocus = true;
    [SerializeField]
    private GameObject[] spotLights;
    [SerializeField]
    private float focusRange = 60;
    [SerializeField]
    private float focusSpotAngle = 20;
    private float normalRange = 10;
    private float normalSpotAngle = 93;
    private Dictionary<LightType, List<Color>> colours = new Dictionary<LightType, List<Color>>() {
        {   LightType.Standard, new List<Color>() { new Color(0.6f, 0.62f, 0.3f), new Color(1.0f, 0.72f, 0.51f), new Color(0.67f, 0.36f, 0.16f) } },
        {   LightType.UV, new List<Color>() { new Color(0.58f, 0f, 1.0f), new Color(0.78f, 0f, 1.0f), new Color(0.06f, 0f, 1.0f) } }
    };
    // Start is called before the first frame update
    void Start()
    {
        normalRange = spotLights[0].GetComponent<Light>().range;
        normalSpotAngle = spotLights[0].GetComponent<Light>().spotAngle;
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

    public void FocusBeam(bool focus)
    {
        if (canFocus)
        {
            foreach (var light in spotLights.Select(x => x.GetComponent<Light>()))
            {
                if (focus)
                {
                    light.range = focusRange;
                    light.spotAngle = focusSpotAngle;
                }
                else
                {
                    light.range = normalRange;
                    light.spotAngle = normalSpotAngle;
                }
            }
        }
    }

    public enum LightType
    {
        Standard,
        UV
    }
}
