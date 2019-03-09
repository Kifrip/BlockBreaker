using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{

    // parameters
    [SerializeField] int breakableBlocks; //Serialized for debugging purposes
    [SerializeField] bool loadSuccessScreen;

    // cached reference
    SceneLoader sceneLoader;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public void CountBlocks()
    {
        breakableBlocks++;
    }

    public void BlockDestroyed()
    {
        breakableBlocks--;
        if (breakableBlocks <= 0)
        {
            if (loadSuccessScreen == true)
            {
                sceneLoader.LoadSuccessScene();
            }
            else
            {
                sceneLoader.LoadNextScene();
            }
        }
    }

    //// Start is called before the first frame update
    //void Start()
    //{
    //    Debug.Log(GameObject.FindGameObjectsWithTag("Block").Length);
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    if(GameObject.FindGameObjectsWithTag("Block").Length==0)
    //    {
    //        sceneLoader.LoadNextScene();
    //    }
    //}
}
