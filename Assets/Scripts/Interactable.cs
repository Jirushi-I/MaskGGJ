using UnityEngine;
using UnityEngine.InputSystem;

public class Interactable : MonoBehaviour
{
    private GameObject player;
    public GameObject interact;
    bool Enter;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //other.GetComponent<CharacterController>().enabled = false;
            interact.SetActive(true);
            player = other.gameObject;
            Enter = true;

            if (Input.GetKeyDown(KeyCode.Space))
            {
               /* other.GetComponent<CharacterController>().enabled = false;
                this.gameObject.GetComponent<Template_UIManager>().Interact(this.GetComponent<VIDE_Assign>());
                this.gameObject.GetComponent<Template_UIManager>().enabled = true;
                interact.SetActive(false);*/
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        interact.SetActive(false);

        Enter = false;
    }

    public void Interact()
    {
        if (Enter == true)
        {
            player.GetComponent<CharacterController>().enabled = false;
            this.gameObject.GetComponent<Template_UIManager>().Interact(this.GetComponent<VIDE_Assign>());
            this.gameObject.GetComponent<Template_UIManager>().enabled = true;
            interact.SetActive(false);
            
            Cursor.visible = true;
        }
    }

    public void ResetPlayer()
    {
        player.GetComponent<CharacterController>().enabled = true;

        Cursor.visible = false;
    }


}
