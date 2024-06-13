using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering;

public class DialoguController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI NPCNameText;
    [SerializeField] private TextMeshProUGUI NPCDialogueText;
    private Queue<string> paragraphs = new Queue<string>();
    private bool conversationEnded;
    private string p;
    public void DisplayNextParagraph(DialogueText dialogueText)
    {
        if (paragraphs.Count == 0)
        {
            if (!conversationEnded)
            {
                StartConversation(dialogueText);
            }else
            {
                EndConversation();
                return;
            }
        }
        p = paragraphs.Dequeue();
        NPCDialogueText.text = p;
        if(paragraphs.Count == 0)
        {
            conversationEnded = true;
        }
    }
    private void StartConversation(DialogueText dialogueText)
    {
        if(!gameObject.activeSelf)
        {
            gameObject.SetActive(true);
        }

        NPCNameText.text = dialogueText.speakerName;

        for (int i = 0; i < dialogueText.paragraphs.Length; i++)
        {
            paragraphs.Enqueue(dialogueText.paragraphs[i]);
        }
    }
    private void EndConversation()
    {
        conversationEnded = false;
        if(gameObject.activeSelf)
        {
            gameObject.SetActive(false);
        }
    }
}
