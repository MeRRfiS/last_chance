using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCardAppearence : MonoBehaviour
{
    private Vector3 position;

    private void Start()
    {
        position = new Vector3(transform.localPosition.x, 230, transform.localPosition.z);
    }

    void Update()
    {
        transform.localPosition = Vector3.MoveTowards(
            transform.localPosition,
            position,
            Time.deltaTime * 2000f);
        if (transform.localPosition.y == position.y)
        {
            Destroy(GetComponent<EnemyCardAppearence>());
        }
    }
}
