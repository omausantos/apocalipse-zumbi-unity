using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorZumbi : MonoBehaviour
{
    public GameObject Zumbi;
    float ContadorTempo = 0;
    public float TempoGerarZumbi = 1;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ContadorTempo += Time.deltaTime;
        if(ContadorTempo >= TempoGerarZumbi)
        {
            Instantiate(Zumbi, transform.position, transform.rotation);
            ContadorTempo = 0;
        }
    }
}
