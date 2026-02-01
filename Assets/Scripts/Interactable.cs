using UnityEngine;
using UnityEngine.InputSystem;

public class Interactable : MonoBehaviour
{
    public GameObject player;
    public GameObject interact;
    bool Enter;
    GameObject maskmanager;
    public GameObject mask;
    public GameObject getMask;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        maskmanager = GameObject.Find("MaskManager");
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
        if (Enter == true && player != null)
        {
            if (maskmanager == null) return;
            MaskManager maskManagerComponent = maskmanager?.GetComponent<MaskManager>();

            if (maskManagerComponent == null) return;
            Mask currentMask = maskManagerComponent?.GetCurrentMask();

            if (currentMask == null || currentMask.gameObject != mask.gameObject) {
                this.gameObject.GetComponent<VIDE_Assign>().overrideStartNode = 4;
            } else if (currentMask.gameObject == mask.gameObject) {
                this.gameObject.GetComponent<VIDE_Assign>().overrideStartNode = 5;
            }

            if (player != null) {
                CharacterController controller = player.GetComponent<CharacterController>();
                if (controller != null) {
                    controller.enabled = false;
                }
            }

            this.gameObject.GetComponent<Template_UIManager>().Interact(this.GetComponent<VIDE_Assign>());
            this.gameObject.GetComponent<Template_UIManager>().enabled = true;
            interact?.SetActive(false);

            Cursor.visible = true;
        }
    }

    public void ResetPlayer()
    {
        player.GetComponent<CharacterController>().enabled = true;

        Cursor.visible = false;
    }

    public void getMaskSound()
    {
        //getMask.gameObject.SetActive(true);
    }
}
