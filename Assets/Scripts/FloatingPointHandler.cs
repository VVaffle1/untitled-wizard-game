using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingPointHandler : MonoBehaviour
{
    public float waitTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyPoint());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DestroyPoint()
    {
        yield return new WaitForSeconds(waitTime);
        Destroy(gameObject);
    }
}
