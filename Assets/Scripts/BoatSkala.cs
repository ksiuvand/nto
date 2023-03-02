using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatSkala : MonoBehaviour
{
    [SerializeField] private GameObject losePanel;

    void OnCollisionEnter(Collision other){
        if (other.gameObject.CompareTag("Skala")){
            losePanel.SetActive(true);
            Time.timeScale = 0;
        }
    }


}
