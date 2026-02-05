using UnityEngine;
using UnityEngine.InputSystem;

public class Interactable : MonoBehaviour
{
    [SerializeField] private CharacterController player;
    [SerializeField] private MaskManager maskmanager;
    [SerializeField] private VIDE_Assign videAssign;
    [SerializeField] private Template_UIManager templateUI;
    [SerializeField] private GameObject mask;
    [SerializeField] private GameObject interact;

    private bool Enter;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            interact.SetActive(true);
            Enter = true;
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
            Mask currentMask = maskmanager?.GetCurrentMask();
            if (this.transform.parent.name == "Lion")
            {
                MusicManager.Instance.SetCharacterLion();
                if (currentMask == null || currentMask.gameObject != mask.gameObject)
                {
                    videAssign.overrideStartNode = 4;
                }
                else if (currentMask.gameObject == mask.gameObject)
                {
                    videAssign.overrideStartNode = 5;
                }
                
            }
            else if (this.transform.parent.name == "Ox")
            {
                MusicManager.Instance.SetCharacterOx();
                if (currentMask == null || currentMask.gameObject != mask.gameObject)
                {
                    videAssign.overrideStartNode = 0;
                }
                else if (currentMask.gameObject == mask.gameObject)
                {
                    videAssign.overrideStartNode = 1;
                }
            }
            else if (this.transform.parent.name == "Deer")
            {
                MusicManager.Instance.SetCharacterStag();
                if (currentMask == null || currentMask.gameObject != mask.gameObject)
                {
                    videAssign.overrideStartNode = 33;
                }
                else if (currentMask.gameObject == mask.gameObject)
                {
                    videAssign.overrideStartNode = 0;
                }
            }

            FMODUnity.RuntimeManager.PlayOneShot("event:/Interact");
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("SucceedDialogue", 0);

            if (player != null)
            {
                CharacterController controller = player;
                if (controller != null)
                {
                    controller.enabled = false;
                }
            }

            templateUI.Interact(videAssign);
            templateUI.enabled = true;
            interact?.SetActive(false);

            Cursor.visible = true;
        }
    }

    public void ResetPlayer()
    {
        player.enabled = true;
        FMODUnity.RuntimeManager.PlayOneShot("event:/Fail");


        Cursor.visible = false;
    }

    public void CompletDialoguePlayer() {
        player.enabled = true;
        FMODUnity.RuntimeManager.PlayOneShot("event:/Succeed");
        Cursor.visible = false;
    }

}
