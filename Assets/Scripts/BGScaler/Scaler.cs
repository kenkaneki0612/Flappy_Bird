using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();

        Vector3 tempScale = transform.localScale;

        float height = sprite.bounds.size.y;
        float width = sprite.bounds.size.x;

        float worldHeight = Camera.main.orthographicSize * 2f; //10
        float worldWidth = worldHeight * Screen.width / Screen.height; //10 * 203/399

        tempScale.y = worldHeight / height;
        tempScale.x = worldWidth / width;

        transform.localScale = tempScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
