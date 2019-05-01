using UnityEngine;

public class WinScript : MonoBehaviour
{
    public GameObject winScreen;
    public GameObject gameView;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            gameView.SetActive(false);
            winScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
