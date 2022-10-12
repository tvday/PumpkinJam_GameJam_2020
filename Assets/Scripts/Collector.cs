using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collector : MonoBehaviour
{
    public Text score;
    DisplayScore scoreObj;
    void Start() {
        scoreObj = score.GetComponent<DisplayScore>();
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Collectable")) {
            other.gameObject.SetActive(false);
            scoreObj.ChangeCount(-1);
        }
    }
}
