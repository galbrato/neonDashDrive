using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpecialAtack : MonoBehaviour {

    public delegate void SpecialAttackDelegate();
    public SpecialAttackDelegate OnSpecialUse;

    abstract public void StartAtack();

    abstract public bool CanAtack();

    abstract public bool IsAtacking();

    abstract public void EndAtack();
}
