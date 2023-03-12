using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceScript : MonoBehaviour
{

    public static Rigidbody rb;
    public static Vector3 diceVelocity;

    [SerializeField]
    private List<Vector3> spawnPositions = new List<Vector3>();

    [SerializeField]
    private GameObject dice;

    private readonly int forge = 150;

    public static bool canThrow = true;

    void Start()
    {
        rb = dice.GetComponent<Rigidbody>();   
    }

    void Update()
    {
        if (SystemControl.blockUI) return;
        if (Input.GetKeyDown(KeyCode.Space) && SystemControl.madeBid && canThrow && !SystemControl.readDialog)
        {
            canThrow = false;
            foreach (Vector3 spawnPosition in spawnPositions)
            {
                float dirX = Random.Range(0, forge);
                float dirY = Random.Range(0, forge);
                float dirZ = Random.Range(0, forge);
                var newDice = Instantiate(dice, new Vector3(spawnPosition.x, 8, spawnPosition.z), Quaternion.identity);
                newDice.GetComponent<DiceProperties>().canCountDot = true;
                rb = newDice.GetComponent<Rigidbody>();
                diceVelocity = rb.velocity;
                rb.AddForce(transform.up * 50);
                rb.AddTorque(dirX, dirY, dirZ);
                StartCoroutine(DestroyDice(newDice));
            }
        }
    }

    private IEnumerator DestroyDice(GameObject dice)
    {
        if(SystemControl.educationOn)
            GameObject.Find("MainCamera").GetComponent<EduDialog>().TurnOffHint();
        yield return new WaitForSeconds(3f);
        if (EduDialog.numberDialog == 4)
        {
            EduDialog.numberReplic = 0;
            GameObject.Find("MainCamera").GetComponent<EduDialog>().TurnOnDialog();
        }
        yield return new WaitForSeconds(2f);
        Destroy(dice);
    }
}
