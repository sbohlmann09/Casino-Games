using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Blackjack : MonoBehaviour
{
    public int deckSize;
    public Sprite[] cardFaces;
    public GameObject cardPrefab;
    public List<string> deck;
    public static string[] suits = new string[] { "C", "D", "H", "S" };
    public static string[] values = new string[] { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };

    public GameObject[] allSpots;
    public GameObject DealerSpot;
    public List<string>[] playedHands;
    private List<string> spot1 = new List<string>();
    private List<string> spot2 = new List<string>();
    private List<string> spot3 = new List<string>();
    private List<string> spot4 = new List<string>();
    private List<string> spot5 = new List<string>();
    private List<string> spot6 = new List<string>();
    private List<string> spot7 = new List<string>();
    public List<string> dealer = new List<string>();
    
    public List<string> discardPile = new List<string>();

    private int round = 0;
    private int activeHands = 2;

    void Start()
    {   
        if(activeHands == 1)
            playedHands = new List<string>[]{spot1,dealer};
        else if(activeHands == 2)
            playedHands = new List<string>[]{spot1,spot2,dealer};
        else if(activeHands == 3)
            playedHands = new List<string>[]{spot1,spot2,spot3,dealer};
        else if(activeHands == 4)
            playedHands = new List<string>[]{spot1,spot2,spot3,spot4,dealer};
        else if(activeHands == 5)
            playedHands = new List<string>[]{spot1,spot2,spot3,spot4,spot5,dealer};
        else if(activeHands == 6)
            playedHands = new List<string>[]{spot1,spot2,spot3,spot4,spot5,spot6,dealer};
        else if(activeHands == 7)    
            playedHands = new List<string>[]{spot1,spot2,spot3,spot4,spot5,spot6,spot7,dealer};
        
        
        StartGame();
    }

    public void StartGame()
    {
        deck = GenerateDeck(deckSize);
        Shuffle(deck);
        // foreach (string card in deck)
        // {
        //     print(card);
        // }
        BJDeal();
        Deal();
        
        
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
        for (int round = 0; round < 2; round++) // Loop twice to deal two rounds of cards
        {  
            for (int i = 0; i < playedHands.Length; i++)
            {
                float xOffset = 0.3f * round;
                float zOffset = 0.03f * (round + 1);
                string card = playedHands[i][round]; // Access the specific card from the array
                
                GameObject newCard = Instantiate(cardPrefab, new Vector3
                (allSpots[i].transform.position.x + xOffset - 0.15f, allSpots[i].transform.position.y, allSpots[i].transform.position.z - zOffset), 
                Quaternion.Euler(0, 0, allSpots[i].transform.rotation.eulerAngles.z), allSpots[i].transform);

                newCard.name = card;
                newCard.GetComponent<Selectable>().faceUp = true;
                print(newCard.name + " At position: " + i);
            }
        }
        


        //This works
        // if (round== 0){//At the beginning of the shoe, the dealer will discard the first card
        //     Debug.Log("Dealing the first round");
        //     Debug.Log("Discarding first card: " + deck[0]);
        //     string discardedCard = deck[0];
        //     deck.RemoveAt(0);
        //     discardPile.Add(discardedCard);
        //     Debug.Log("Checking the discard pile: " + discardPile[0]);
        //     Debug.Log("Checking the deck: " + deck[0]);

        // }
        
        
    }

    void BJDeal(){
        for(int i = 0; i < 2; i++){
            // foreach (int bjc in playedHands.Count)
            for (int j = 0; j < playedHands.Length; j++)
            {
                playedHands[j].Add(deck.First<string>()); 
                deck.RemoveAt(0);
            }
        }
    }
}
