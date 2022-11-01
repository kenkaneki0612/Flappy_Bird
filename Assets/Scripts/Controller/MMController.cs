using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MMController : MonoBehaviour
{
    // Start is called before the first frame update
    public void _PlayButton()
    {
        //Application.LoadLevel("SampleScene");
        SceneManager.LoadScene("SampleScene");
    }
}
