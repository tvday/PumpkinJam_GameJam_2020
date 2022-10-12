using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour
{
    // Start is called before the first frame update
    int count;
    Text countText;
    void Start()
    {
        count = GameObject.FindGameObjectsWithTag("Collectable").Length;
        countText = GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        countText.text = "Chores Remaining: " + count.ToString();
    }

    public void ChangeCount(int delta) {
        count += delta;
    }

    public int GetCount() {
        return count;
    }
}
