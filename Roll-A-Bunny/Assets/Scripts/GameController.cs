using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class GameController : MonoBehaviour
{

    public GameObject moleContainer;
    public float spawnDuration = 1.5f;
    public float spawnDecrement = 0.1f; 
    public float minimumSpawnDuration = 0.5f;

    private Mole[] moles;
    private float spawnTimer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        moles = moleContainer.GetComponentsInChildren<Mole>();
        //Debug.Log(moles.Length); 
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime; 
        if(spawnTimer <= 0f)
        {
            int random_mol = Random.Range(0, moles.Length);
            moles[random_mol].Rise();

            spawnDuration -= spawnDecrement; 
            if (spawnDuration < minimumSpawnDuration)
            {
                spawnDuration = minimumSpawnDuration; 
            }

            spawnTimer = spawnDuration; 
        }
    }
}
