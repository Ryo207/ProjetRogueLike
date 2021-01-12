using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightFlik : MonoBehaviour
{
    Light2D lumiere;
    float ran;
    float ran2;
    // Start is called before the first frame update
    void Start()
    {
        lumiere = GetComponent<Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        ran = Random.Range(0, 1);
        ran2 = Random.Range(1, 3);
        
    }
   /* IEnumerator lightFlik()
    {
        yield return new  WaitForSeconds(ran);
        lumiere.volumeOpacity(ran);

        yield return 0f;
    }*/
}
