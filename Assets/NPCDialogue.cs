using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogue : MonoBehaviour
{
    public string[] NPCSentences = new string[]{"Enter", "Hi", "How are you?"};
    public string message;
    public int index = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        message = NPCSentences[index];
    }

    // Update is called once per frame
    void Update()
    {
      if(Input.GetKeyDown(KeyCode.Return)){
        message = NPCSentences[index];
        Debug.Log(message);
        index += 1;
        if(index == NPCSentences.Length){
          index = 0;
        }
      }
        // displayMessage();
    }

    void displayMessage(){

    }

}
