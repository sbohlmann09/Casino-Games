using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blackjack : MonoBehaviour
{
    public int deckSize;
    public Sprite[] cardFaces;
    public GameObject cardPrefab;
    public List<string> deck;
    public static string[] suits = new string[] { "C", "D", "H", "S" };
    public static string[] values = new string[] { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };

    public void StartGame()
    {
        deck = GenerateDeck(deckSize);
        Shuffle(deck);
        for (int i = 0; i < deck.Count; i++)
        {
            Debug.Log($"Card {i + 1}: {deck[i]}");
        }
    }

    public void SetDeckSize(int deck){
        deckSize = deck;
        Debug.Log("The deck size is: " + deckSize);
    }

    public int GetDeckSize(){
        return deckSize;
    }

    public static List<string> GenerateDeck(int deck)
    {
        List<string> newDeck = new List<string>();
        for (int i = 0; i < deck; i++)
        {
            foreach (string s in suits)
            {
                foreach (string v in values)
                {
                    newDeck.Add(s + v);
                }
            }   
        }
        
        return newDeck;
    }

    private void Shuffle<T>(List<T> list)
    {
        System.Random random = new System.Random();
        int n = list.Count;
        while (n > 1)
        {
            int k = random.Next(n);
            n--;
            T temp = list[k];
            list[k] = list[n];
            list[n] = temp;
        }
    }

}
