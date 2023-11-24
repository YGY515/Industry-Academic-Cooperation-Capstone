using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float force = 1.0f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * force);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("miniGameItem")) // ���� ȭ���� �����̶� ������.
        {
            rb.velocity = Vector3.zero;
            rb.isKinematic =true;
            // �Լ� ȣ��
            StartCoroutine(InteractToActing());// -> ���� ���߰� ���� �Ŀ� �Ͼ ��.  
        }
    }

    IEnumerator InteractToActing()
    {
        // 0.2��
        yield return new WaitForSeconds(1.0f);
        gameObject.SetActive(false); // ȭ�� ��Ȱ��ȭ.

           MiniGame3Manager.Instance.GetScore();

        if(MiniGame3Manager.Instance.shootCount == 5)
        {
            MiniGame3Manager.Instance.GameOver();
            yield break;
        }

       // ȭ��ǥ �ӵ� ����.
        MiniGame3Manager.Instance.arrowOnBar.ChangeSpeed();
        MiniGame3Manager.Instance.arrowOnBar.move = true; // ȭ��ǥ�� �������� �Ǵ���.
        MiniGame3Manager.Instance.stopbutton.pushButton.interactable = true; // ��ư Ȱ��ȭ
    }
}
