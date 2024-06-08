using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    [SerializeField] GameObject[] NPCs;
    [SerializeField] GameObject PortalPosition;
    [SerializeField] GameObject TablePosition;
    [SerializeField] int nbClients;
    [SerializeField] float moveDuration = 5f;
    [SerializeField] float waitDuration = 10f;
    [SerializeField] float cooldown = 4f;

    private float Timer = 0f;
    private System.Random rnd = new();
    private GameObject[] Spawned;

    // Start is called before the first frame update
    void Start()
    {
        Spawned = new GameObject[nbClients];

        for (int i = 0; i < Spawned.Length; i++)
        {
            Spawned[i] = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Timer);
        Timer += Time.deltaTime;
        if (Timer <= cooldown)
        {
            return;
        }

        Timer = 0f;
        for (int i = 0; i < Spawned.Length; i++)
        {
            if (Spawned[i] == null || Spawned[i].gameObject.IsDestroyed())
            {
                Debug.Log("Spawn");
                Spawned[i] = Instantiate(NPCs[rnd.Next(nbClients)]);
                Spawned[i].transform.position = PortalPosition.transform.position;
                Spawned[i].transform.LookAt(TablePosition.transform.position);
                MovementManager movementScript = Spawned[i].GetComponent<MovementManager>();

                if (movementScript != null)
                {
                    // Set the movement parameters
                    movementScript.firstTargetPosition = TablePosition.transform.position;
                    movementScript.secondTargetPosition = PortalPosition.transform.position;
                    movementScript.moveDuration = moveDuration;
                    movementScript.waitDuration = waitDuration;

                    // Start the movement coroutine
                    StartCoroutine(movementScript.MoveAndWaitCoroutine());
                }

                break;
            }
        }
    }
}
