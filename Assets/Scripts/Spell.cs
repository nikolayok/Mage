using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    private Camera _mainCamera;

    private GameObject _spellBook;
    private Teleport _teleport;
    private ChangeColor _changeColor;
    private CreateCube _createCube;
    private Fireball _fireball;
    private CreateStack _createStack;
    private Resize _resize;
    private SlowTime _slowTime;
    private AddUpForce _addUpForce;

    enum Spells
    {
        Teleport, ChangeColor, CreateCube, Fireball, CreateStack, Resize, SlowTime, AddUpForce
    }

    Spells currentSpell;

    private void Start()
    {
        _spellBook = GameObject.FindGameObjectWithTag("SpellBook");

        _teleport = _spellBook.GetComponent<Teleport>();
        _changeColor = _spellBook.GetComponent<ChangeColor>();
        _createCube = _spellBook.GetComponent<CreateCube>();
        _fireball = _spellBook.GetComponent<Fireball>();
        _createStack = _spellBook.GetComponent<CreateStack>();
        _resize = _spellBook.GetComponent<Resize>();
        _slowTime = _spellBook.GetComponent<SlowTime>();
        _addUpForce = _spellBook.GetComponent<AddUpForce>();


        currentSpell = Spells.Teleport;
        _mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    private void Update()
    {
        CheckForMouseClick();
    }

    private void CheckForMouseClick()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (currentSpell == Spells.Teleport)
                _teleport.Teleportation();
            else if (currentSpell == Spells.ChangeColor)
                _changeColor.DoChangeColor();
            else if (currentSpell == Spells.CreateCube)
                _createCube.DoCreateCube();
            else if (currentSpell == Spells.Fireball)
                _fireball.SpellFireball();
            else if (currentSpell == Spells.CreateStack)
                _createStack.DoCreateStack();
            else if (currentSpell == Spells.Resize)
                _resize.DoResize();
            else if (currentSpell == Spells.SlowTime)
                _slowTime.DoSlowTime();
            else if (currentSpell == Spells.AddUpForce)
                _addUpForce.DoAddUpForce();
        }
    }

    public void SelectTeleport()
    {
        currentSpell = Spells.Teleport;
    }

    public void SelectChangeColor()
    {
        currentSpell = Spells.ChangeColor;
    }

    public void SelectCreateCube()
    {
        currentSpell = Spells.CreateCube;
    }

    public void SelectFireball()
    {
        currentSpell = Spells.Fireball;
    }

    public void SelectCreateStack()
    {
        currentSpell = Spells.CreateStack;
    }

    public void SelectResize()
    {
        currentSpell = Spells.Resize;
    }

    public void SelectSlowTime()
    {
        currentSpell = Spells.SlowTime;
    }

    public void SelectDoAddUpForce()
    {
        currentSpell = Spells.AddUpForce;
    }
}
