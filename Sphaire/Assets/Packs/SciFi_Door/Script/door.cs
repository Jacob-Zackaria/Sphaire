using UnityEngine;

public class door : MonoBehaviour {
	public GameObject thedoor;
    public GameObject greenTile;
    public GameObject blueTile;
    public GameObject keyCanvas;

    private bool _greenKey = false;
    private bool _blueKey = false;
    //private bool _redKey = false;

    //Open door.
    void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (_greenKey)
            {
                thedoor.GetComponent<Animation>().Play("open");
            }
            else
            {
                keyCanvas.SetActive(true);
            }
        }
    }

    //Close door.
    void OnTriggerExit (Collider other)
    {
        if (other.CompareTag("Player") && _greenKey && _blueKey)
            thedoor.GetComponent<Animation>().Play("close");

        keyCanvas.SetActive(false);
    }

    //Set Green Key.
    public void SetGreenKey(Material greenHealth)
    {
        _greenKey = true;
        greenTile.GetComponent<MeshRenderer>().material = greenHealth;
    }

    //Set Blue Key.
    public void SetBlueKey(Material bluePill)
    {
        _blueKey = true;
        blueTile.GetComponent<MeshRenderer>().material = bluePill;
    }
}