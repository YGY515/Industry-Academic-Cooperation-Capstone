using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class EndCard : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler
{
    [SerializeField] private int matchId;
    
    public Transform point;

    public int Get_ID()
    {
        return matchId;
    }

 
    public void OnPointerEnter(PointerEventData eventData)
    {  
        MiniGame2Manager.Instance.EndCardEnterd(this);
    }


    public void OnPointerExit(PointerEventData eventData)
    {
        MiniGame2Manager.Instance.EndCardExit();
    }
}
