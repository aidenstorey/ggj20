using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walking_dinosaur : MonoBehaviour
{
    public float speed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = this.transform.position + new Vector2(this.speed * Time.deltaTime, 0.0f);
        this.
    }
}
