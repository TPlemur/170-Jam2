using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floater : MonoBehaviour
{
    public float amplitude = 0.5f;
    public float frequency = 1f;
    public GameObject cube;

    // Position Storage vars
    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();

    Transform cubeTF;

    // Start is called before the first frame update
    void Start()
    {
        posOffset = transform.position;
        cubeTF = cube.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        // float up/down with a sin()
        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;
        cubeTF.Rotate(0, 0.5f, 0.6f);

        transform.position = tempPos;
    }
}
