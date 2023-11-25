using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Cinemachine;

public class Dialogue : MonoBehaviour
{

    public NPCdata npc;

    public Player player;

    //int index;
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text textLabel;
    [SerializeField] private GameObject Container;
    [SerializeField] private GameObject MainUI;
    [SerializeField] private GameObject NpcUI;
    [SerializeField] private CinemachineVirtualCamera dialogueCam;
    [SerializeField] private PlayerInputsManager playerInputsManager;

    public bool IsOpen { get; private set; }

    private ResponseHandler responseHandler;

     void Start()
    {
        player.input = playerInputsManager;//GetComponent<PlayerInputsManager>();

        responseHandler = GetComponent<ResponseHandler>();

        CloseDialogueBox();
    }

    
    void Update()
    {

    }

    [SerializeField]
    private float typewriterSpeed = 20f;

    public bool IsRunning { get; private set; }

    private readonly List<Punctuation> punctuations = new List<Punctuation> ()
    {
        new Punctuation(punctuations: new HashSet<char>() {'.', '!', '?'}, waitTime: 0.6f),
        new Punctuation(punctuations: new HashSet<char>() {',', ';', ':'}, waitTime: 0.3f)
    };

    private Coroutine typingCoroutine;

    public void Run(string textToType, TMP_Text textLabel)
    {
        typingCoroutine = StartCoroutine(routine: TypeText(textToType, textLabel));
    }

    public void Stop()
    {
        StopCoroutine(typingCoroutine);
        IsRunning = false;
    }


    private IEnumerator TypeText(string textToType, TMP_Text textLabel)
    {
        IsRunning = true;
        textLabel.text = string.Empty;

        float t = 0f;
        int charIndex = 0;

        while(charIndex < textToType.Length)
        {
            int lastCharIndex = charIndex;

            t += Time.deltaTime * typewriterSpeed;
            charIndex = Mathf.FloorToInt(t);
            charIndex = Mathf.Clamp(value: charIndex, min: 0, max: textToType.Length);

            for (int i = lastCharIndex; i < charIndex; i++)
            {
                bool isLast = i >= textToType.Length - 1;
                
                textLabel.text = textToType.Substring(startIndex: 0, length: i + 1);

                if (IsPunctuation(textToType[i], out float waitTime) && !isLast && !IsPunctuation(textToType[i + 1], out _))
                {
                    yield return new WaitForSeconds(waitTime);
                }
            }

            //textLabel.text = textToType.Substring(startIndex: 0, length: charIndex);

            yield return null;
        }

        IsRunning = false;
        //textLabel.text = textToType;
    }


    public void ShowDialogue(DialogueData dialogueData)
    {
        IsOpen = true;
        player.input.move = Vector2.zero;
        //MainUI.SetActive(false);

        dialogueBox.SetActive(true);
        Debug.Log("?");
        StartCoroutine(routine: StepThroughDialogue(dialogueData));
    }

    private IEnumerator StepThroughDialogue(DialogueData dialogueData)
    {
        for (int i = 0; i < dialogueData.Dialogue.Length; i++)
        {
            string dialogue = dialogueData.Dialogue[i];
            //yield return Run(dialogue, textLabel);
            yield return RunTypingEffect(dialogue);

            textLabel.text = dialogue;

            if (i == dialogueData.Dialogue.Length - 1 && dialogueData.HasResponses) break;

            yield return null;
            yield return new WaitUntil(() => player.input.dialogueTap);
            player.input.dialogueTap = false;
        }

        if (dialogueData.HasResponses)
        {
            responseHandler.ShowResponses(dialogueData.Responses);
        }
        else
        {
            CloseDialogueBox();
        }
    }

    public void AddResponseEvents(ResponseEvent[] responseEvents)
    {
        responseHandler.AddResponseEvents(responseEvents);
    }

    public void CloseDialogueBox()
    {
        IsOpen = false;

        //MainUI.SetActive(true);

        dialogueBox.SetActive(false);
        textLabel.text = string.Empty;
    }

    private bool IsPunctuation(char character, out float waitTime)
    {
        foreach (Punctuation punctuationCategory in punctuations)
        {
            if (punctuationCategory.Punctuations.Contains(character))
            {
                waitTime = punctuationCategory.WaitTime;
                return true;
            }
        }

        waitTime = default;
        return false;
    }

    private IEnumerator RunTypingEffect(string dialogue)
    {
        Run(dialogue, textLabel);

        while (IsRunning)
        {
            yield return null;

            if (player.input.dialogueTap)
            {
                player.input.dialogueTap = false;
                Stop();
            }
        }
    }

    private readonly struct Punctuation
    {
        public readonly HashSet<char> Punctuations;
        public readonly float WaitTime;

        public Punctuation(HashSet<char> punctuations, float waitTime)
        {
            Punctuations = punctuations;
            WaitTime = waitTime;
        }
    }
}
