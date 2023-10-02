using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    Movements movements;
    public static List<string> Sequence = new List<string>(); // make this static and check this in ui to update the spell ui assets

    public delegate void Spell(string[] array);
    public static event Spell SpellEvent;

    private void Awake()
    {
        movements = new Movements();
    }

    private void OnEnable()
    {
        movements.Enable();
        movements.Land.J.performed += _ => PressedJ();
        movements.Land.I.performed += _ => PressedI();
        movements.Land.L.performed += _ => PressedL();
    }

    private void Update()
    {
        if (Sequence.Count == 3)
        {
            SpellEvent(Sequence.ToArray());
            Sequence.Clear();
        }
    }

    private void OnDisable()
    {
        movements.Disable();
        movements.Land.J.performed -= _ => PressedJ();
        movements.Land.I.performed -= _ => PressedI();
        movements.Land.L.performed -= _ => PressedL();

    }

    //void TriggerDash()
    //{
    //    Debug.Log("started");
    //    if(!PlayerMovement.isMoving) DashSpellEvent();
    //    PlayerMovement.isMoving = true;
    //}



    //void TriggerFireBall()
    //{
    //    if(!PlayerMovement.isMoving)FireSpellEvent();
    //}

    void PressedJ()
    {
        Sequence.Add("j");
    }

    void PressedI()
    {
        Sequence.Add("i");
    }

    void PressedL()
    {
        Sequence.Add("l");
    }
}
