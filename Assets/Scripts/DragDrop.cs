using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    //OLD SYSTEM USED TO PLAY CARDS. WILL BE REMOVED EVENTUALLY. IS UNUSED AND REPLACED BY CARDPLAY
    //REMEMBER TO REMOVE PHYSICS SYSTEM BEFORE DELETING THIS CLASS

    public GameObject Canvas;
    public GameObject DropZone;
    bool isDragging = false;
    bool isOverDropZone = false;
    bool isDraggable = true;
    bool _isCorrectTurnAndPhase = false;
    GameObject dropZone;
    Vector2 startPosition;
    GameObject startParent;
    GameObject Player = null;
    GameObject Enemy = null;
    ICard card = null;

    public bool ISCORRECTTURNANDPHASE
    {
        get { return _isCorrectTurnAndPhase; }

        set { _isCorrectTurnAndPhase = value; }
    }

    void Start()
    {
        Canvas = GameObject.Find("Main Canvas");
        DropZone = GameObject.Find("PlayerPermanents");
        startParent = transform.parent.gameObject;
        if (startParent.name.Equals("PlayerHand"))
        {
            Player = GameObject.Find("Player");
            Enemy = GameObject.Find("Enemy");
        }
        else
        {
            Player = GameObject.Find("Enemy");
            Enemy = GameObject.Find("Player");
        }
        card = this.gameObject.GetComponent<ICard>();
    }

    void Update()
    {
        if (isDragging)
        {
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            transform.SetParent(Canvas.transform, true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isOverDropZone = true;
        dropZone = collision.gameObject;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isOverDropZone = false;
        dropZone = null;
    }

    public void StartDrag()
    {
        if (TurnUtilities.CheckIfCharHasCosts(Player, card) == false || ISCORRECTTURNANDPHASE == false) isDraggable = false;
        if (isDraggable == false) return;
        startPosition = transform.position;
        isDragging = true;
    }

    public void EndDrag()
    {
        if (!isDraggable) return;
        isDragging = false;

        if (isOverDropZone)
        {
            Player.GetComponent<Character>().SendToDeadPile(this.gameObject);
            isDraggable = false;
            TurnUtilities.PayCardCosts(Player, card);
            if(card.Attack > 0) Battle.InflictBattleDamage(Player, Enemy, card);
        }
        else
        {
            transform.position = startPosition;
            transform.SetParent(startParent.transform, false);
        }
    }
}
