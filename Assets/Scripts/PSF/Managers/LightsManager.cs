using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsManager : MonoBehaviour
{

    [Header("Lights")]
    public bool pathLightsOn;
    public bool monorailLightsOn;
    public bool otherLightsOn;

    public float pathLightsTime;
    public float monorailLightsTime;
    public float otherLightsTime;

    public GameObject pathLights;
    public GameObject monorailLights;
    public GameObject otherLights;

    private void Awake()
    {
        pathLightsOn = true;
        monorailLightsOn = true;
        otherLightsOn = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        PathLightsControl();
        MonorailLightsControl();
        OtherLightsControl();
    }

    private void PathLightsControl()
    {
        StartCoroutine("PathLights");
    }

    private void MonorailLightsControl()
    {
        StartCoroutine("MonorailLights");
    }

    private void OtherLightsControl()
    {
        StartCoroutine("OtherLights");
    }

    private IEnumerator PathLights()
    {
        yield return new WaitForSeconds(pathLightsTime);

        if (pathLightsOn == true)
        {
            pathLights.SetActive(false);
            pathLightsOn = false;
            PathLightsControl();
        }
        else
        {
            pathLights.SetActive(true);
            pathLightsOn = true;
            PathLightsControl();
        }
    }

    private IEnumerator MonorailLights()
    {
        yield return new WaitForSeconds(monorailLightsTime);

        if (monorailLightsOn == true)
        {
            monorailLights.SetActive(false);
            monorailLightsOn = false;
            MonorailLightsControl();
        }
        else
        {
            monorailLights.SetActive(true);
            monorailLightsOn = true;
            MonorailLightsControl();
        }
    }

    private IEnumerator OtherLights()
    {
        yield return new WaitForSeconds(otherLightsTime);

        if (otherLightsOn == true)
        {
            otherLights.SetActive(false);
            otherLightsOn = false;
            OtherLightsControl();
        }
        else
        {
            otherLights.SetActive(true);
            otherLightsOn = true;
            OtherLightsControl();
        }
    }
}
