using UnityEngine;

public class BGManager : MonoBehaviour
{
    public GameObject bg;
    private Vector2 oofset;

    void Start()
    {
        bg.GetComponent<Renderer>();
    }

    void Update()
    {
        if (SettingsManager.check_Music == true)
        {
            oofset = new Vector2(Time.time * -0.5f, Time.time * 0.5f);
        }
        else
        {
            oofset = new Vector2(Time.time * 0.5f, Time.time * -0.5f);
        }
        bg.GetComponent<Renderer>().material.mainTextureOffset = oofset;
    }
}