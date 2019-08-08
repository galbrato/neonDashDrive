using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpacialAtack : MonoBehaviour {
    abstract public bool StartAtack();

    abstract public bool CanAtack();

    abstract public bool IsAtacking();

    abstract public bool EndAtack();
}
