using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellCall : MonoBehaviour
{
    private int mana = 20;
    public SaveDataObject SDO;
    public ChangeCursor CC;
    public GameObject SpellBook;
    public GameObject ButtonOpen, ButtonClose;
    public GameObject WhatSpell, WhatSpell1;
    public Spell[] WhatPlayer;
    private Image spellImage;
    private Text spellName;
    private int whatSpell;
    public FieldMovement[] Enemys;

    private void Awake()
    {
        spellImage = WhatSpell.transform.Find("Image").GetComponent<Image>();
        spellName = WhatSpell1.GetComponentInChildren<Text>();
        if (SDO.CityType == SaveDataObject.type.Castel)
        {
            spellImage.sprite = WhatPlayer[0].image;
            spellName.text = WhatPlayer[0].callout;
            whatSpell = 0;
            WhatSpell.GetComponent<Button>().onClick.AddListener(CreateSpell);
            WhatSpell1.GetComponent<Button>().onClick.AddListener(CreateSpell);
        }
        else if (SDO.CityType == SaveDataObject.type.Rampart)
        { 
            spellImage.sprite = WhatPlayer[1].image;
            spellName.text = WhatPlayer[1].callout;
            whatSpell = 1;
            WhatSpell.GetComponent<Button>().onClick.AddListener(CreateSpell);
            WhatSpell1.GetComponent<Button>().onClick.AddListener(CreateSpell);
        }
        else if (SDO.CityType == SaveDataObject.type.Necropolis)
        {
            spellImage.sprite = WhatPlayer[2].image;
            spellName.text = WhatPlayer[2].callout;
            whatSpell = 2;
            WhatSpell.GetComponent<Button>().onClick.AddListener(CreateSpell);
            WhatSpell1.GetComponent<Button>().onClick.AddListener(CreateSpell);
        }
    }
    public void CreateSpell()
    {
        if (whatSpell == 0)
        {
            CloseSpellBook();
            CastSpell(WhatPlayer[0].Damage);
            FindObjectOfType<AudioManager>().Play("Hit");
            mana -= 10;
        }
        else if (whatSpell == 1)
        {
            FindObjectOfType<BattleFieldPlate>().pathfinding.settedValue += 20;
            CloseSpellBook();
            mana -= 4;
        }
        else if (whatSpell == 2)
        {
            FindObjectOfType<BattleManager>().CreateNewAliedUnit(WhatPlayer[2].unitToResurect);
            CloseSpellBook();
            mana -= 20;
        }
    }
    public void OpenSpellBook()
    {
        SpellBook.SetActive(true);
        ButtonOpen.SetActive(false);
    }
    public void CloseSpellBook()
    {
        SpellBook.SetActive(false);
        ButtonOpen.SetActive(true);
    }

    public static Vector3 GetMouseWorldPosition()
    {
        Vector3 vec = GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
        vec.z = 0f;
        return vec;
    }
    public void CastSpell( int spellDamage)
    {
        for(int i = 0; i< Enemys.Length; i++)
        {
            Enemys[i].health -= spellDamage;
            Enemys[i].howManyAlive();
        }
    }
    public static Vector3 GetMouseWorldPositionWithZ()
    {
        return GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
    }
    public static Vector3 GetMouseWorldPositionWithZ(Camera worldCamera)
    {
        return GetMouseWorldPositionWithZ(Input.mousePosition, worldCamera);
    }
    public static Vector3 GetMouseWorldPositionWithZ(Vector3 screenPosition, Camera worldCamera)
    {
        Vector3 worldPosition = worldCamera.ScreenToWorldPoint(screenPosition);
        return worldPosition;
    }
}
