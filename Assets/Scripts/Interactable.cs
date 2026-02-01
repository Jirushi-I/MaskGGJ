using UnityEngine;
using UnityEngine.InputSystem;

public class Interactable : MonoBehaviour
{
    public GameObject player;
    public GameObject interact;
    bool Enter;
    GameObject maskmanager;
    public GameObject mask;
    public GameObject[] others;
    public WinCondition win;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        maskmanager = GameObject.Find("MaskManager");
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
            others[0].SetActive(false);
            others[1].SetActive(false);
            win = GameObject.Find("winCondition").GetComponent<WinCondition>();


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
        others[0].SetActive(true);
        others[1].SetActive(true);
    }

    public void Interact()
    {
        if (Enter == true && player != null)
        {
            if (maskmanager == null) return;
            MaskManager maskManagerComponent = maskmanager?.GetComponent<MaskManager>();

            if (maskManagerComponent == null) return;
            Mask currentMask = maskManagerComponent?.GetCurrentMask();
            if (this.transform.parent.name == "Lion")
            {
                if (currentMask == null || currentMask.gameObject != mask.gameObject)
                {
                    this.gameObject.GetComponent<VIDE_Assign>().overrideStartNode = 4;
                }
                else if (currentMask.gameObject == mask.gameObject)
                {
                    this.gameObject.GetComponent<VIDE_Assign>().overrideStartNode = 5;
                }
            }
            else if (this.transform.parent.name == "Ox")
            {
                if (currentMask == null || currentMask.gameObject != mask.gameObject)
                {
                    this.gameObject.GetComponent<VIDE_Assign>().overrideStartNode = 0;
                }
                else if (currentMask.gameObject == mask.gameObject)
                {
                    this.gameObject.GetComponent<VIDE_Assign>().overrideStartNode = 1;
                }
            }
            else if (this.transform.parent.name == "Deer")
            {
                if (currentMask == null || currentMask.gameObject != mask.gameObject)
                {
                    this.gameObject.GetComponent<VIDE_Assign>().overrideStartNode = 33;
                }
                else if (currentMask.gameObject == mask.gameObject)
                {
                    this.gameObject.GetComponent<VIDE_Assign>().overrideStartNode = 0;
                }
            }

            if (player != null)
            {
                CharacterController controller = player.GetComponent<CharacterController>();
                if (controller != null)
                {
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

}
