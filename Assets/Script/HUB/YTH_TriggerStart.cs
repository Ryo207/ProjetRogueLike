using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YTH_TriggerStart : MonoBehaviour
{
    public Animator startTransition;
    // Start is called before the first frame update
    void Start()
    {
        startTransition = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            startTransition.SetBool("Start", true);
            StartCoroutine(nameof(waitOneSec));
        }

    }

    IEnumerator waitOneSec()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(0);
    }
}
