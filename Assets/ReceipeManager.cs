using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ReceipeManager : MonoBehaviour
{
    [SerializeField] int ingredientCount = 4;
    [SerializeField] TMP_Text CauldronText;
    [SerializeField] TMP_Text ScoreText;
    [SerializeField] GameObject spawnerObject;

    private Spawner spawner;
    private System.Random rnd = new();
    private List<string> mixture = new List<string>();
    private int score = 0;

    private void OnCollisionEnter(Collision collision)
    {
        mixture.Add(collision.gameObject.name);
        Destroy(collision.gameObject);
    }

    public void Complete()
    {
        mixture = new List<string>();
        score += 100;
        ScoreText.text = $"Score: {score.ToString()}";
    }

    public bool CompareMixture(List<string> receipe)
    {
        List<string> tmp = new List<string>(mixture);

        foreach (var ingredient in receipe)
        {
            if (tmp.Contains(ingredient))
            {
                tmp.Remove(ingredient);
            } else
            {
                return false;
            }
        }

        return tmp.Count == 0;
    }

    public List<string> GetRandomReceipe()
    {
        int size = rnd.Next(3) + 1;
        List<string> newReceipe = new List<string>();

        for (int i = 0; i < size; i++)
        {
            newReceipe.Add(spawner.GetRandomIngredient());
        }

        return newReceipe;
    }

    private void Awake()
    {
        spawner = spawnerObject.GetComponent<Spawner>();
        ScoreText.text = $"Score: {score.ToString()}";
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        string receipeText = "Cauldron: \n";
        for (int i = 0; i < mixture.Count; i++)
        {
            receipeText += $"{mixture[i]} ";
        }

        CauldronText.text = receipeText;
    }
}
