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

    public GameObject[] allSpots;
    public List<string> spot1 = new List<string>();
    public List<string> spot2 = new List<string>();
    public List<string> spot3 = new List<string>();
    public List<string> spot4 = new List<string>();
    public List<string> spot5 = new List<string>();
    public List<string> spot6 = new List<string>();
    public List<string> spot7 = new List<string>();
    public List<string> dealer = new List<string>();
    
    public List<string> discardPile = new List<string>();

    private int round = 0;
    public void StartGame()
    {
        deck = GenerateDeck(deckSize);
        Shuffle(deck);
        Deal();
        // for (int i = 0; i < deck.Count; i++)
        // {
        //     Debug.Log($"Card {i + 1}: {deck[i]}");
        // }
        
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


    public void Deal()
    {
        if (round== 0){//At the beginning of the shoe, the dealer will discard the first card
            Debug.Log("Dealing the first round");
            Debug.Log("Discarding first card: " + deck[0]);
            string discardedCard = deck[0];
            deck.RemoveAt(0);
            discardPile.Add(discardedCard);
            Debug.Log("Checking the discard pile: " + discardPile[0]);
            Debug.Log("Checking the deck: " + deck[0]);

        }
        foreach (var spot in allSpots)
        {
            for (int i = 0; i < 2; i++)
            {
            // Deal to spot
            string card = deck[0];
            spot.GetComponent<Spot>().AddCard(card);
            deck.RemoveAt(0);
            GameObject newCard = Instantiate(cardPrefab, spot.transform);
            newCard.GetComponent<SpriteRenderer>().sprite = GetCardSprite(card);
            }
        }

        // // Deal to dealer
        // for (int i = 0; i < 2; i++)
        // {
        //     string card = deck[0];
        //     dealer.Add(card);
        //     deck.RemoveAt(0);
        //     GameObject newCard = Instantiate(cardPrefab, allSpots[0].transform);
        //     newCard.GetComponent<SpriteRenderer>().sprite = GetCardSprite(card);
        // }
    }

}
