using UnityEngine;
using UnityEngine.SceneManagement;

public class UIHandler : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ChooseCar(int choice)
    {
        MainManager.Instance.carTypes = (CarTypes)choice;
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
