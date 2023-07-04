using UnityEngine;
using UnityEngine.SceneManagement;

public class UIHandler : MonoBehaviour
{
    //ABSTRACTION
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    //ABSTRACTION
    public void ChooseCar(int choice)
    {
        MainManager.Instance.carTypes = (CarTypes)choice;
    }

    //ABSTRACTION
    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
