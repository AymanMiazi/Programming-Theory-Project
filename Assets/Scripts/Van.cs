using UnityEngine;

//INHERITANCE
public class Van : CarController
{
    private bool _isBoostActive;
    [SerializeField] private ParticleSystem boostParticles;

    [SerializeField] private int boostFactor;
    
    //POLYMORPHISM
    protected override void ActivateSpecial()
    {
        if (!_isBoostActive)
        {
            _isBoostActive = true;
            MaxMotorTorque *= boostFactor;
            boostParticles.Play();
        }
        else
        {
            _isBoostActive = false;
            MaxMotorTorque /= boostFactor;
            boostParticles.Stop();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            ActivateSpecial();
        }
    }
}
