using UnityEngine.SceneManagement;
using UnityEngine;

public class HowToPlay : MonoBehaviour
{
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
