using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;

public class SubtitleBehaviour : PlayableBehaviour
{
    public string subtitleText;

    [SerializeField]
    private float R=0.0f;
    [SerializeField]
    private float G=0.0f;
    [SerializeField]
    private float B=0.0f;


    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        TextMeshProUGUI text = playerData as TextMeshProUGUI;
        text.text = subtitleText;
        text.color = new Color(R, G, B, 1);
    }
}
