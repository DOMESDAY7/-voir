using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BubbleManager : MonoBehaviour
{
    public TMP_Text UI;
    public GameObject player;

    public void SetText(string text)
    {
        UI.text = text;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));
        transform.Rotate(new Vector3(0, 180, 0));
    }
}
