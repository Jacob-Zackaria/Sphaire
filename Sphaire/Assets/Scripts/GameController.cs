using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject player;
    private Vector3 lastCheckpoint;
    public GameObject gameOverScreen;

    private void Start()
    {
        lastCheckpoint = player.transform.position;
    }

    //Load last checkpoint.
    public void LoadCheckpoint()
    {
        player.SetActive(true);
        player.transform.position = lastCheckpoint;
        gameOverScreen.SetActive(false);
    }

    //Create new checkpoint.
    public void ChangeCheckpoint(Vector3 changeCheckpoint)
    {
        lastCheckpoint = changeCheckpoint;
    }

    //Restart level.
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //Exit to main menu.
    public void ExitGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("LoadScreen");
    }

}
