using System.Collections;
using UnityEngine;

//INHERITANCE
public class Ambulance : CarController
{
    [SerializeField] private GameObject redLight;
    [SerializeField] private GameObject blueLight;
    [SerializeField] private float waitTime = 0.5f;

    private bool _isLightsOn;
    
    //POLYMORPHISM
    protected override void ActivateSpecial()
    {
        _isLightsOn = !_isLightsOn;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            ActivateSpecial();
        }
    }

    private void Start()
    {
        StartCoroutine(FlashLights());
    }

    IEnumerator FlashLights()
    {
        while (_isLightsOn)
        {
            redLight.SetActive(true);
            blueLight.SetActive(false);
            yield return new WaitForSeconds(waitTime);
            redLight.SetActive(false);
            blueLight.SetActive(true);
            yield return new WaitForSeconds(waitTime);
        }

        if (!_isLightsOn)
        {
            redLight.SetActive(false);
            blueLight.SetActive(false);
        }

        yield return new WaitForSeconds(waitTime);
        StartCoroutine(FlashLights());
    }
}
