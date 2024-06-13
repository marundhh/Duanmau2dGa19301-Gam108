using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wraith : NPC, ITalkable
{
    [SerializeField] private DialogueText dialogueText;
    [SerializeField] private DialoguController dialoguController;
    public override void Interact()
    {
        Talk(dialogueText);
    }
    public void Talk(DialogueText dialoguetext)
    {
        dialoguController.DisplayNextParagraph(dialoguetext);
    }
}
