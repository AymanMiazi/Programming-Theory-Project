using TMPro;
using UnityEngine;

public class ChooseCar : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playingAsText;
    private void Awake()
    {
        if (MainManager.Instance != null)
        {
            foreach (Transform child in transform)
            {
                if (child.gameObject.GetComponent<CarController>().type == MainManager.Instance.carTypes)
                {
                    child.gameObject.SetActive(true);
                    playingAsText.SetText($"Playing As: {MainManager.Instance.carTypes}");
                }
            }
        }
    }
}
