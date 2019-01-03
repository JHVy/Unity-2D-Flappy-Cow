using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerPipe : MonoBehaviour
{
   // private const float Max = 2.5f;
    [SerializeField]
    private GameObject pipeHolder;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawner());
    }

    IEnumerator Spawner() // delay 1 khoang tgian sau do moi thuc hien (sinh ra 1 pipe holder)
    {
        yield return new WaitForSeconds(1.5f); // cho 1s
        Vector3 temp = pipeHolder.transform.position;
        temp.y = Random.Range(-2.2f, max: 2.5f);
        Instantiate(pipeHolder, temp, Quaternion.identity);
        StartCoroutine(Spawner());
    }
}
