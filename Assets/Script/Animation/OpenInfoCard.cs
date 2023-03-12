using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenInfoCard : MonoBehaviour
{
    public Vector3 position;
    
    void Start()
    {
        position = new Vector3(815, 0, 0);
    }

    void Update()
    {
        transform.localPosition = Vector3.MoveTowards(
            transform.localPosition,
            position,
            Time.deltaTime * 4000f);
    }
}
