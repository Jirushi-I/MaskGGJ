using UnityEngine;
using UnityEngine.InputSystem;

public class Starteractable : MonoBehaviour
{
    public GameObject player;
    public GameObject interact;
    bool Enter;
    GameObject maskmanager;
    public GameObject mask;
    public GameObject getMask;
    public GameObject[] others;
    public WinCondition win;
    public SignalManager signalManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Interact();
    }

    public void Interact()
    {
            player.GetComponent<CharacterController>().enabled = true;
            Cursor.visible = true;
    }

    public void ResetPlayer()
    {
        player.GetComponent<CharacterController>().enabled = true;

        Cursor.visible = false;
    }
}
