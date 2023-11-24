using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransferMap : MonoBehaviour
{
    public string transferMapName; // 이동할 맵 이름

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Player")
        {
            Debug.Log("Player");
            SceneManager.LoadScene(transferMapName);
        }
    }


}

