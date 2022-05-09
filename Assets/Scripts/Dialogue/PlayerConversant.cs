using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using TMPro;
namespace Isekai
{
    public class PlayerConversant : MonoBehaviour
    {
        Dialogue currentDialogue;
        DialogueNode currentNode = null;
        bool isChoosing = false;
        InputUI inputUI;
        public GameObject dialoguePostProcess;
        PlayerMovement playerMovement;
        [SerializeField] TextMeshProUGUI npcText;

        public event Action onConversationUpdated;
        private void Awake()
        {
        //    currentNode = currentDialogue.GetRootNode();
            inputUI = GetComponent<InputUI>();
            playerMovement = GetComponent<PlayerMovement>();
        }

        public void StartDialogue(Dialogue newDialogue)
        {
            currentDialogue = newDialogue;
            currentNode = currentDialogue.GetRootNode();
            onConversationUpdated();
            DialogueEffects();
        }


        private void DialogueEffects()
        {
            inputUI.dialogueEnabled = true;
            inputUI.EnableCursor();
            dialoguePostProcess.SetActive(true);
            playerMovement.walkSpeed = 0.05f;
            playerMovement.runSpeed = 0.05f;
        }

        public void SetNPCName(string name)
        {
            npcText.text = name;
        }
        private void DeOffEffects()
        {
            inputUI.dialogueEnabled = false;
            inputUI.DisableCursor();
            dialoguePostProcess.SetActive(false);
            playerMovement.walkSpeed = 6.6f;
            playerMovement.runSpeed = 14f;
        }
        public void Quit()
        {
            currentDialogue = null;
            currentNode = null;
            isChoosing = false;
            onConversationUpdated();
            DeOffEffects();
        }
        public bool IsActive()
        {
            return currentDialogue != null;
        }

        public string GetText()
        {
            if (currentNode == null) return "";
            return currentNode.GetText();
        }
        public bool IsChoosing()
        {
            return isChoosing;
        }
        public IEnumerable<DialogueNode> GetChoices()
        {
            return currentDialogue.GetPlayerChildren(currentNode);
        }
        public void SelectChoice(DialogueNode chosenNode)
        {
            currentNode = chosenNode;
            isChoosing = false;
            Next(); 

        }
        public void Next()
        {
            int numPlayerResponses = currentDialogue.GetPlayerChildren(currentNode).Count();
            if(numPlayerResponses > 0)
            {
                isChoosing=true;
                onConversationUpdated();
                return;
            }
            DialogueNode[] children = currentDialogue.GetAIChildren(currentNode).ToArray();
            int randomIndex = UnityEngine.Random.Range(0, children.Count());
            currentNode = children[randomIndex];
            onConversationUpdated();
        }

        public bool HasNext()
        {
            DialogueNode[] children = currentDialogue.GetAllChildren(currentNode).ToArray();
            return children.Count() > 0;
        }
    }
}