using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPC : MonoBehaviour
{
    public Transform playerPosition;
    public NPCdata npc;
    public GameObject dialogBox;
    public PlayerInputsManager input;
    public Dialogue dial;

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        input = GetComponent<PlayerInputsManager>();
        dial = GetComponent<Dialogue>();
    }
    private void Update()
    {
        
    }
}
