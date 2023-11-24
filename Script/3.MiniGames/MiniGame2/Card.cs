using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class Card : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    // Card�� �Ӵ� ID. ¦�� ���߱� ����.

    [SerializeField]
    private int matchId;
    [SerializeField]
    private string proverb;
    public Transform point;

    public int Get_ID()
    {
        return matchId;
    }
 
    public string Get_Proverb()
    {
        return proverb;
    }
   
    public GameObject linePreFab;
    private GameObject line;

    public GameObject Get_LINE()
    {
        return line;
    }

    // ���콺 ��ư�� ������ ��,
    public void OnPointerDown(PointerEventData eventData)
    {
        // ���⼭ ��ŸƮ ī�带 Ȯ��.
        MiniGame2Manager.Instance.StartCardClicked(this);
           
        // line prefab ����.
        line = Instantiate(linePreFab, point.position, Quaternion.identity,transform.parent);

        // world space�� ����.
        Vector3 SStoWS = Camera.main.ScreenToWorldPoint(eventData.position);
        UpdateLine(SStoWS); // eventData.postion�� ���콺 ���� ��ġ.
    }
    public void OnDrag(PointerEventData eventData)
    {
        Vector3 SStoWS = Camera.main.ScreenToWorldPoint(eventData.position);
        UpdateLine(SStoWS);
    }

    void UpdateLine(Vector3 position)
    {
        // Update direction
        // ���� �����ؾ� �Ѵ�. z�� ���� ī��� �����ϰ�
        Vector3 linePos = new Vector3(position.x, position.y, point.position.z);
        Vector3 direction = linePos - point.position;
        line.transform.right = direction;

        // update scale
        line.transform.localScale = new Vector3(direction.magnitude, 1, 1);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (MiniGame2Manager.Instance.CardMatchCheck()) 
            UpdateLine(MiniGame2Manager.Instance.GetEndCard().point.position);
    }

}
