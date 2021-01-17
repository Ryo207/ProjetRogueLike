using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YT_DialogueTrigger : MonoBehaviour
{
    public YT_Dialogues dialogues;
    bool showText;

    private void Awake()
    {
        showText = false;
    }
    private void Update()
    {
        TextShow();
    }

    void TextShow()
    {
        if (Input.GetKeyDown(KeyCode.P) && showText == true )
        {
            FindObjectOfType<YT_DialoguesManager>().StartDialogue(dialogues);
        }

        else{}

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            showText = true;
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            showText = false;
            FindObjectOfType<YT_DialoguesManager>().EndDialogues();
        }
    }

    public void TriggerDialogue()
    {
    }
}
