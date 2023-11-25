using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Response
{
    [SerializeField] private string responseText;
    [SerializeField] private DialogueData dialogueData;

    public string ResponseText => responseText;
    public DialogueData DialogueData => dialogueData;
}
