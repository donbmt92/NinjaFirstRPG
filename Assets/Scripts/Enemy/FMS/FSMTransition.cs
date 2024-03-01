using System;
using UnityEngine;

[Serializable]
public class FSMTransition
{
    public FSMDecision Decision; //PlayerInRangeAttack -> True or False
    public string TrueState; //CurrentState -> AttackState
    public string FalseState;//CurrentState -> PatrolState

}
