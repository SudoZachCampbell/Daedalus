using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField]
    private GameObject flashlightObj;
    [SerializeField]
    private Material safeSky;
    [SerializeField]
    private Material darkSky;
    private Flashlight flashlight;
    private bool clueMode = false;
    // Start is called before the first frame update
    void Start()
    {
        CreateSingleton();
        flashlight = flashlightObj.GetComponent<Flashlight>();
    }

    private void CreateSingleton()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("ToggleLight"))
        {
            clueMode = !clueMode;
            flashlight.SetLightColours(clueMode ? Flashlight.LightType.UV : Flashlight.LightType.Standard);
        }

        if (Input.GetButtonDown("FocusLight"))
        {
            flashlight.FocusBeam(true);
        }
        else if (Input.GetButtonUp("FocusLight"))
        {
            flashlight.FocusBeam(false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            RenderSettings.skybox = safeSky;
        }

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            RenderSettings.skybox = darkSky;
        }
    }

}
