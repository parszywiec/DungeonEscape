using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// klasa abstrakcyjna przez dodanie nazwy w naglowku
public abstract class Enemy : MonoBehaviour {

    // protected wiadomo, moga uzywac dzieci
    [SerializeField] protected int health;
    // ciekawostka - public - pojawiaja sie w unity jak SerializeF..., priv/prot nie, ale jesli dodamy im Sera..., to pojawia sie ponwnie
    [SerializeField]
    protected int speed;
    [SerializeField] protected int gems;
    [SerializeField] protected Transform pointA, pointB;

    // vritual attack moze implementowany przez dzieci, badz zmieniony przez zmienienie u nich virtual na override
    public virtual void Attack()
    {

    }

    // MUSI! byc zaimplementowana, ale cialo tworza dzieci, z wlasnymi wlasnosciami
    public abstract void Update();

}
