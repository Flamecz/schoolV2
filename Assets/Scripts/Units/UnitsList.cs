using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitsList : MonoBehaviour
{
    public Unit unit;


    List<Unit> UnitsCastel = new List<Unit>();
    List<Unit> UnitsRampart = new List<Unit>();
    List<Unit> UnitsInferno = new List<Unit>();

    private void Start()
    {
        //                        unit name     city    level
        //Castel
        UnitsCastel.Add(new Unit("Pikeman"   , "Castel", 1   , 4, 5, 1, 3 , 10, 4, 14, 80, 60, Unit.Movementtype.ground, Unit.attackType.melee));
        UnitsCastel.Add(new Unit("Halberdier", "Castel", 1.5f, 6, 5, 2, 3 , 10, 5, 14, 115, 75, Unit.Movementtype.ground, Unit.attackType.melee));

        UnitsCastel.Add(new Unit("Archer"    , "Castel", 2   , 6, 3, 2, 3 , 10, 4 , 9, 126, 100, Unit.Movementtype.ground, Unit.attackType.ranger, 12));
        UnitsCastel.Add(new Unit("Marksman"  , "Castel", 2.5f, 6, 3, 2, 3 , 10, 6 , 9, 184, 150, Unit.Movementtype.ground, Unit.attackType.ranger, 24));

        UnitsCastel.Add(new Unit("Griffin"      , "Castel", 3    , 8, 8, 3, 6, 25, 6, 7, 351, 200, Unit.Movementtype.air, Unit.attackType.melee));
        UnitsCastel.Add(new Unit("Royal Griffin", "Castel", 3.5f , 9, 9, 3, 6, 25, 9, 7, 448, 240, Unit.Movementtype.air, Unit.attackType.melee));

        UnitsCastel.Add(new Unit("Swordman", "Castel", 4   , 10, 12, 6, 9, 35, 5, 4, 445, 300, Unit.Movementtype.ground, Unit.attackType.melee));
        UnitsCastel.Add(new Unit("Crusader", "Castel", 4.5f, 12, 12, 7, 10, 35, 6, 4, 588, 400, Unit.Movementtype.ground, Unit.attackType.melee));

        UnitsCastel.Add(new Unit("Monk"  , "Castel", 5   , 12, 7 , 10, 12, 30, 5, 3, 485,400, Unit.Movementtype.ground, Unit.attackType.ranger,12));
        UnitsCastel.Add(new Unit("Zealot", "Castel", 5.5f, 12, 10, 10, 12, 30, 7, 3, 750, 450, Unit.Movementtype.ground, Unit.attackType.ranger, 24));

        UnitsCastel.Add(new Unit("Cavalier", "Castel", 6   , 15, 15, 15, 25, 100, 7, 2, 1946, 1000, Unit.Movementtype.ground, Unit.attackType.melee));
        UnitsCastel.Add(new Unit("Champion", "Castel", 6.5f, 16, 16, 20, 25, 100, 9, 2, 2100, 1200, Unit.Movementtype.ground, Unit.attackType.melee));

        UnitsCastel.Add(new Unit("Angel"    , "Castel", 7   , 20, 20, 50, 50, 200, 12, 1, 5019, 3000, Unit.Movementtype.air, Unit.attackType.melee));
        UnitsCastel.Add(new Unit("Archangle", "Castel", 7.5f, 30, 30, 50, 50, 250, 18, 1, 8876, 5000, Unit.Movementtype.air, Unit.attackType.melee));

        //Rampart
        UnitsRampart.Add(new Unit("Centaur"        , "Rampart", 1   , 5, 3, 2, 3 , 8, 6, 14, 100, 70, Unit.Movementtype.ground, Unit.attackType.melee));
        UnitsRampart.Add(new Unit("Centaur Captain", "Rampart", 1.5f, 6, 3, 2, 3 ,10, 8, 14, 138, 90, Unit.Movementtype.ground, Unit.attackType.melee));

        UnitsRampart.Add(new Unit("Dwarf"       , "Rampart", 2   , 6, 7, 2, 4, 20, 3, 8, 138, 120, Unit.Movementtype.ground, Unit.attackType.melee));
        UnitsRampart.Add(new Unit("Battle Dwarf", "Rampart", 2.5f, 7, 7, 2, 4, 20, 5, 8, 209, 150, Unit.Movementtype.ground, Unit.attackType.melee));

        UnitsRampart.Add(new Unit("Wood Elf", "Rampart", 3, 9, 5, 3, 5, 15, 6, 7, 234, 200, Unit.Movementtype.ground, Unit.attackType.ranger));
        UnitsRampart.Add(new Unit("Grand Elf", "Rampart", 3.5f, 9, 5, 3, 5, 15, 7, 7, 331, 225, Unit.Movementtype.ground, Unit.attackType.ranger));

        UnitsRampart.Add(new Unit("Pegasus", "Rampart", 4, 9, 8, 5, 9, 30, 8, 5, 518, 250, Unit.Movementtype.air, Unit.attackType.melee));
        UnitsRampart.Add(new Unit("Silver Pegasus", "Rampart", 4.5f, 9, 10, 5, 9, 30, 12, 5, 532, 275, Unit.Movementtype.air, Unit.attackType.melee));

        UnitsRampart.Add(new Unit("Dendroid Guard", "Rampart", 5, 9, 12, 10, 14, 55, 3, 3, 517, 350, Unit.Movementtype.ground, Unit.attackType.melee));
        UnitsRampart.Add(new Unit("Dendroid Soldier", "Rampart", 5.5f, 9, 12, 10, 14, 65, 4, 3, 803, 425, Unit.Movementtype.ground, Unit.attackType.melee));

        UnitsRampart.Add(new Unit("Unicorn", "Rampart", 6, 15, 14, 18, 22, 90, 7, 2, 1806, 850, Unit.Movementtype.ground, Unit.attackType.melee));
        UnitsRampart.Add(new Unit("War Unicorn", "Rampart", 6.5f, 15, 14, 18, 22, 110, 9, 2, 2030, 950, Unit.Movementtype.ground, Unit.attackType.melee));

        UnitsRampart.Add(new Unit("Green Dragon", "Rampart", 7, 18, 18, 40, 50, 180, 10, 1, 4872, 2400, Unit.Movementtype.air, Unit.attackType.melee));
        UnitsRampart.Add(new Unit("Gold Dragon", "Rampart", 7.5f, 27, 27, 40, 50, 250, 16, 1, 8613, 4000, Unit.Movementtype.ground, Unit.attackType.melee));

        //Inferno
        UnitsInferno.Add(new Unit("Imp"     , "Inferno", 1   , 2, 3, 1, 2, 4, 5, 15, 50, 50, Unit.Movementtype.ground, Unit.attackType.melee));
        UnitsInferno.Add(new Unit("Familiar", "Inferno", 1.5f, 4, 4, 1, 2, 4, 7, 15, 60, 60, Unit.Movementtype.ground, Unit.attackType.melee));

        UnitsInferno.Add(new Unit("Gog"  , "Inferno", 2   , 6, 4, 2, 4, 13, 4, 8, 159, 125, Unit.Movementtype.ground, Unit.attackType.ranger,12));
        UnitsInferno.Add(new Unit("Magog", "Inferno", 2.5f, 7, 4, 2, 4, 13, 6, 8, 240, 175, Unit.Movementtype.ground, Unit.attackType.ranger,24));

        UnitsInferno.Add(new Unit("Hell Hound", "Inferno", 3   , 10, 6, 2, 7, 25, 7, 5, 357, 200, Unit.Movementtype.ground, Unit.attackType.melee));
        UnitsInferno.Add(new Unit("Cerberus"  , "Inferno", 3.5f, 10, 8, 2, 7, 25, 8, 5, 392, 250, Unit.Movementtype.ground, Unit.attackType.melee));

        UnitsInferno.Add(new Unit("Demon"       , "Inferno", 4   , 10, 10, 7, 9, 35, 5, 4, 445, 250, Unit.Movementtype.ground, Unit.attackType.melee));
        UnitsInferno.Add(new Unit("Horned Demon", "Inferno", 4.5f, 10, 8 , 7, 9, 40, 6, 4, 480, 270, Unit.Movementtype.ground, Unit.attackType.melee));

        UnitsInferno.Add(new Unit("Pit Fiend", "Inferno", 5   , 13, 13, 13, 17, 45, 6, 3, 765, 500, Unit.Movementtype.ground, Unit.attackType.melee));
        UnitsInferno.Add(new Unit("Pit Lord" , "Inferno", 5.5f, 13, 13, 13, 17, 45, 7, 3, 1224, 700, Unit.Movementtype.ground, Unit.attackType.melee));

        UnitsInferno.Add(new Unit("Efreeti"      , "Inferno", 6   , 16, 12, 16, 24, 90, 9 , 2, 1670, 900, Unit.Movementtype.air, Unit.attackType.melee));
        UnitsInferno.Add(new Unit("Efreet Sultan", "Inferno", 6.5f, 16, 14, 16, 24, 90, 13, 2, 1848, 1100, Unit.Movementtype.air, Unit.attackType.melee));

        UnitsInferno.Add(new Unit("Devil"     , "Inferno", 7   , 19, 21, 30, 40, 160, 11, 1, 5101, 2700, Unit.Movementtype.air, Unit.attackType.melee));
        UnitsInferno.Add(new Unit("Arch Devil", "Inferno", 7.5f, 26, 28, 30, 40, 200, 17, 1, 7115, 4500, Unit.Movementtype.air, Unit.attackType.melee));


    }
}
