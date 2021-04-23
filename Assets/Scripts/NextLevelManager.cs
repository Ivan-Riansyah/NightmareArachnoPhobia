using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelManager : MonoBehaviour
{
    public int killTarget = 10;
    public GameObject NextLevelUI;
    Scene currentScene;

    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
    }

    void Update()
    {
        if (TotalKill.totalKill == killTarget)
        {
            StartCoroutine(NextLevel());
        }
    }

    public IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(2);
        Cursor.lockState = CursorLockMode.None;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        NextLevelUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void NextLvl()
    {
        SceneManager.LoadScene(currentScene.buildIndex + 1);
        Time.timeScale = 1f;
    }
}
