using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultCollider : MonoBehaviour
{
    // Start is called before the first frame update
    public MowerController parent;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Grass grass = other.gameObject.GetComponent<Grass>();
        if (grass != null)
        {
            Destroy(other.gameObject);
        }

        Debug.Log("Quick!");
        parent.quickerMult();
    }
}
