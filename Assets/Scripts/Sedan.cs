using UnityEngine;

//INHERITANCE
public class Sedan : CarController
{

    [SerializeField] private GameObject trail;
    private bool _isTrailActive;
    
    //POLYMORPHISM
    protected override void ActivateSpecial()
    {
        if(!_isTrailActive)
        {
            trail.SetActive(true);
            _isTrailActive = true;
        }
        else
        {
            trail.SetActive(false);
            _isTrailActive = false;
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            ActivateSpecial();
        }
    }
    
}
