using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMover : MonoBehaviour
{
    public float speed;
    private void Update()
    {
        transform.Translate(new Vector3(speed, 0, 0)*Time.deltaTime);
        if (transform.position.x < -5f)
        {
            Destroy(this.gameObject);
        }
    }
    
}
