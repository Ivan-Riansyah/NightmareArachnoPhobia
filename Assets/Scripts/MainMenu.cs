using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Story1");
    }

    public void Village()
    {
        SceneManager.LoadScene("Village_day");
    }

    public void Railway()
    {
        SceneManager.LoadScene("Railway_day");
    }

    public void Forest()
    {
        SceneManager.LoadScene("Forest_day");
    }

    public void CastleOne()
    {
        SceneManager.LoadScene("Castle_1");
    }

    public void CastleTwo()
    {
        SceneManager.LoadScene("Castle_2");
    }

    public void HowToPlay()
    {
        SceneManager.LoadScene("HowToPlayScene");
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }

}
