using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ICard : MonoBehaviour
{
    protected string _cardName;
    protected int _attack;
    protected int _buildValue;
    protected int _armorValue;
    protected int _magicBarrierValue;
    protected int _blockValue;
    protected bool _isHero = false;
    protected bool _isLegend = false;
    //This represents the type of damage the card deals. Default is Physical.
    protected string _damageType = "Physical";
    //In order, the indexes are: population, metals, crystals, generators in same order, Hero Armor and Village HP
    protected List<int> _costs = new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 };
    protected bool _hasEffect = false;
    //Some cards will have effect costs, like discarding a card, outside of _costs
    protected bool _effectCostsPaid = false;
    protected bool _isPermanent = false;

    public void Constructor(
        string name = "unknown_card",
        int attack = 0,
        string damageType = "Physical",
        List<int> costs = null,
        bool permanent = false,
        int buildAmount = 0,
        int armor = 0,
        int magicBarrier = 0,
        int block = 0,
        bool hero = false,
        bool legend = false
    )
    {
        CardName = name;
        DamageType = damageType;
        Attack = attack;
        if (costs != null) Costs = costs;
        IsPermanent = permanent;
        BuildValue = buildAmount;
        ArmorValue = armor;
        MagicBarrierValue = magicBarrier;
        BlockValue = block;
        IsHero = hero;
        IsLegend = legend;
    }

    public virtual void Effect() { }

    //Handles actually paying the cost(s) to use the effect. Returns true if the cost(s) are successfully paid.
    public virtual bool HandleEffectCosts() { return false; }

    public virtual bool IsPermanent
    {
        get { return _isPermanent; }
        set
        {
            _isPermanent = value;
        }
    }

    public virtual bool IsHero
    {
        get { return _isHero; }
        set
        {
            _isHero = value;
        }
    }

    public virtual bool IsLegend
    {
        get { return _isLegend; }
        set
        {
            _isLegend = value;
        }
    }

    public virtual int BlockValue
    {
        get { return _blockValue; }
        set
        {
            _blockValue = value;
        }
    }

    public virtual int ArmorValue
    {
        get { return _armorValue; }
        set
        {
            _armorValue = value;
        }
    }

    public virtual int MagicBarrierValue
    {
        get { return _magicBarrierValue; }
        set
        {
            _magicBarrierValue = value;
        }
    }

    public virtual int BuildValue
    {
        get { return _buildValue; }
        set
        {
            _buildValue = value;
        }
    }

    public virtual bool HasEffect
    {
        get { return _hasEffect; }
        set
        {
            _hasEffect = value;
        }
    }

    public virtual bool EffectCostsPaid
    {
        get { return _effectCostsPaid; }
        set
        {
            _effectCostsPaid = value;
        }
    }

    public virtual string CardName
    {
        get { return _cardName; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))throw new System.ArgumentNullException("New card name is either null or just white space...");
            _cardName = value;
        }
    }
    public virtual int Attack
    {
        get { return _attack; }
        set
        {
            _attack += value;
        }
    }
    public virtual string DamageType
    {
        get { return _damageType; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new System.ArgumentNullException("New damage type is either null or just white space...");
            }
            if (InvalidType(value))
            {
                throw new System.ArgumentException("Invalid damage type...");
            }
            _damageType = value;
        }
    }
    //The setter for this field can either be an array of size 2 or an array of the same ->
    //size as _costs. If it is a size 2; the first index corresponds to the resource ->
    //which needs to be changed, the second, the value to set the resource at.
    //If it as an array of the same size, then it loops, changing all of the indexes in _costs
    public virtual List<int> Costs
    {
        get { return _costs; }
        set
        {
            //Array of 2
            if(value.Count == 2)
            {
                //Check to make sure that the first index is in bounds of _costs
                if (value[0] < 0 || value[0] > _costs.Count) throw new System.ArgumentException("Setter array of size 2 for costs has an incorrect position index...");
                _costs[value[0]] = value[1];
            }
            //Check to make sure the full array is in bounds of _costs
            if(value.Count != _costs.Count) throw new System.ArgumentException("Setter array for costs has an incorrect amount of indexes...");
            //Full array
            for (int i = 0; i < _costs.Count; i++)
            {
                _costs[i] = value[i];
            }
        }
    }

    public virtual void SetPlayableBecauseOtherPlayerTurnOrWrongPhase(bool value)
    {
        this.GetComponent<CardPlay>().ISCORRECTTURNANDPHASE = value;
    }

    public virtual bool CheckIfCardIsPlayable()
    {
        return GetComponent<CardPlay>().ISCORRECTTURNANDPHASE;
    }

    //Called by the setter for DamageType. Checks if the new type is valid.
    protected virtual bool InvalidType(string type)
    {
        if(type.Equals("Physical") == false && type.Equals("Magical") == false && type.Equals("Direct") == false) return true;
        return false;
    }
}
