using UnityEngine;
using Cinemachine; 

public class DialogueActivator : MonoBehaviour, IInteractable
{

    [SerializeField] private DialogueData dialogueData;
    [SerializeField] private CinemachineVirtualCamera npcCam; // NPC�� �޷��ִ� ī�޶��Դϴ�.
    [SerializeField] private CinemachineVirtualCamera playerCam; // �÷��̾ �޷��ִ� ī�޶��Դϴ�. ���̾˷αװ� ������ playerCam���� �����մϴ�.

    public void UpdateDialogueData(DialogueData dialogueData)
    {
        this.dialogueData = dialogueData;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && other.TryGetComponent(out Player player))
        {
            player.Interactable = this;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && other.TryGetComponent(out Player player))
        {
            if (player.Interactable is DialogueActivator dialogueActivator && dialogueActivator == this)
            {
                player.Interactable = null;

            }
        }
    }

    public void Interact(Player player)
    {
        foreach (DialogueResponseEvents responseEvents in GetComponents<DialogueResponseEvents>())
        {
            if (responseEvents.DialogueData == dialogueData)
            {
                player.Dialogue.AddResponseEvents(responseEvents.Events);
                break;
            }
        }

        /*
        if (TryGetComponent(out DialogueResponseEvents responseEvents) && responseEvents.DialogueData == dialogueData)
        {
            player.Dialogue.AddResponseEvents(responseEvents.Events);
        }
        */

        player.Dialogue.ShowDialogue(dialogueData);

        if (CameraSwitcher.ActiveCamera != npcCam) CameraSwitcher.SwitchCamera(npcCam); //
    }
}
