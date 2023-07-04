using UnityEngine;

public class PoliceCar : CarController
{
    private AudioSource _audioSource;

    private bool _isSirenActive;
    protected override void ActivateSpecial()
    {
        if (!_isSirenActive)
        {
            _audioSource.Play();
            _isSirenActive = true;
        }
        else
        {
            _audioSource.Stop();
            _isSirenActive = false;
        }
    }

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            ActivateSpecial();
        }
    }
}
