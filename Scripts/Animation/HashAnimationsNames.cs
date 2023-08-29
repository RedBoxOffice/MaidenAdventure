using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HashAnimationsNames : MonoBehaviour
{    
    public int TorchRun { get; } = Animator.StringToHash("TorchRun");
    public int TorchIdle { get; } = Animator.StringToHash("TorchIdle");
    public int SceneSwitchAnim { get; } = Animator.StringToHash("SceneSwitchAnim");
    public int Running { get; } = Animator.StringToHash("Running");
    public int RightTurn { get; } = Animator.StringToHash("RightTurn");    
    public int Idle { get; } = Animator.StringToHash("Idle");
}
