using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance { get; private set; }
    
    public CarTypes carTypes ;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }
}
