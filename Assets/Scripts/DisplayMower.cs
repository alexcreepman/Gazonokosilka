using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayMower : MonoBehaviour
{
    public MowerController parent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        Grass grass = other.gameObject.GetComponent<Grass>();
        if (grass != null)
        {
            Destroy(other.gameObject);
        }
        parent.AddScoreGrass();

    }
}
