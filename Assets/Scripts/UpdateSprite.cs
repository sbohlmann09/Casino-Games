using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class UpdateSprite : MonoBehaviour
{
    public Sprite cardFace;
    public Sprite cardBack;
    private SpriteRenderer spriteRenderer;
    private Selectable selectable;
    private Blackjack blackjack;



    // Start is called before the first frame update
    void Start()
    {
        blackjack = FindObjectOfType<Blackjack>();
        List<string> deck = Blackjack.GenerateDeck(blackjack.GetDeckSize());
        
        
        int i = 0;
        foreach (string card in deck)
        {
            if (this.name == card){
                cardFace = blackjack.cardFaces[i];
                break;
            }
            i++;
        }

        spriteRenderer = GetComponent<SpriteRenderer>();
        selectable = GetComponent<Selectable>();
    }

    // Update is called once per frame
    void Update()
    {
        if(selectable.faceUp == true){
            spriteRenderer.sprite = cardFace;
        }
        else{
            spriteRenderer.sprite = cardBack;
        }

    }
}
