using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField]
    private GameObject flashlightObj;
    private Flashlight flashlight;

    private bool clueMode = false;

    [SerializeField]
    private GameObject clues;
    // Start is called before the first frame update
    void Start()
    {
        CreateSingleton();
        flashlight = flashlightObj.GetComponent<Flashlight>();
        toggleClues(false);
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
            toggleClues(clueMode);
        }

        if (Input.GetButtonDown("FocusLight"))
        {
            flashlight.FocusBeam(true);
        }
        else if (Input.GetButtonUp("FocusLight"))
        {
            flashlight.FocusBeam(false);
        }
    }

    private void toggleClues(bool clueMode)
    {
        clues.SetActive(clueMode);
    }

}
