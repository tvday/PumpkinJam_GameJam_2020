using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonControl : MonoBehaviour
{
    public string sceneName; 
    
    // Start is called before the first frame update
    public Button start;
    void Start()
    {
        start.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void TaskOnClick()
    {
        //Output this to console when Button1 or Button3 is clicked
        Debug.Log("You have clicked the button!");
        SceneManager.LoadScene(sceneName);
    }
}
