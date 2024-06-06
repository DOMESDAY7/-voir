using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ReceipeManager : MonoBehaviour
{
    public int ingredientCount = 4;
    public TMP_Text UI;

    private System.Random rnd = new();
    public string[] receipe;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        for (int i = 0; i < receipe.Length; i++)
        {
            if (receipe[i] == collision.gameObject.name)
            {
                receipe[i] = null;
                Destroy(collision.gameObject);
                return;
            }
        }
    }

    private void Awake()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        string receipeText = "Recette : ";
        for (int i = 0; i < receipe.Length; i++)
        {
            if (receipe[i] != null)
                receipeText += $"{receipe[i]} ";
        }

        UI.text = receipeText;
    }
}
