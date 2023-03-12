using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCharacter : MonoBehaviour
{
    //[SerializeField]
    //private GameObject character;

    [SerializeField]
    private List<Material> images = new List<Material>();
    [SerializeField]
    private Material image;

    private Vector3 position;

    private void Start()
    {
        position = gameObject.transform.position;
    }

    public void Change()
    {
        if (position.y == 8f)
        {
            position = new Vector3(
                transform.position.x,
                -8f,
                transform.position.z);
            image = images[1];
        }
            
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, position, Time.deltaTime * 50f);
        if (transform.position.y == -8f)
            StartCoroutine(ChangeImage());
    }

    private IEnumerator ChangeImage()
    {
        yield return new WaitForSeconds(1f);
        position = new Vector3(
                transform.position.x,
                8f,
                transform.position.z);
        gameObject.GetComponent<Renderer>().material = image;
    }
}
