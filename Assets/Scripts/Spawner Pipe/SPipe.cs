using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPipe : MonoBehaviour
{

    [SerializeField]

    private GameObject pipeHolder;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawner());
    }

    // Update is called once per frame
    IEnumerator Spawner()
    {
        yield return new WaitForSeconds(1);
        Vector3 temp = pipeHolder.transform.position;
        temp.y = Random.Range(-1.5f, 1.5f);

        Instantiate(pipeHolder, temp, Quaternion.identity);
        StartCoroutine(Spawner());
    }
}
