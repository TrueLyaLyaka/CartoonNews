﻿using UnityEngine;
using System.Collections;
// This GM drive game and everones episods
// cunting the score
public class GM : MonoBehaviour {
    #region Episode Start, Drive
    /* 1) load location
     * 2) set DirectPerson (DP) on position
     * 3) take DP for the player to drive 
     * */

    void StartEpisode()
    {
        
    }

    void DriveEpisode()
    {

    }
    #endregion



    // Use this for initialization
	void Start () {
        StartEpisode(); 

	}
	
	// Update is called once per frame
	void Update () {
	
	}
    #region описание и концепт игры
/* общий концепт игры
 
Игра состоит из томов. 
В каждом томе есть главы состоящих из 1-4 локаций. По тому можно перемещатся свободно с любым рейтингом. 
В следующий том можно попасть набрав необходимое количество рейтинга. 
В кадой локации игрок должен стремится набрать максимальный рейтинг. Локация олицетворят реальное событие. Описание которого можно сразу прочитать для того чтобы понять логику прохождения.
Каждая глава может быть переиграна (для набора максимального рейтинга от нее).
В каждой локации можно набрать определенное количество рейтинга.
Максимальный рейтинг можно набрать только максимально правильно пройдя главу.
Одновременно у игрока может быть только 3 скила (3 кнопки действия + перемещение лево право),
но игрок может их менять.
Дерево скилов направления (некультурство (плеваться, семки жрать, показать фак), пыль в глаза (целовать в пупок, умолять на коленях, показать бицепсы), атаки (дать щелбана, дать пинка, показать козу))

*/
#endregion

#region меню
/*
меню:
1) стартовое меню (начать игру, опции, выход)
2) начать игру (список глав, дерево скилов, бестиарий )
3) дерево скилов (меню в которых есть описание скилов и рейтинг который они дают сколько стоят)
4) у каждой главы: играть сначала, старт, и статистика рейтинга (максимальный диапазон красный, желтый диапазон слабо, зеленый - нормально, самый максимальный - фак красного цвета)
5) бестиарий (знания об окружающем мире - который расширяется в зависимости от прохождения)
 * можно открывать за игровые деньги юнитов из бестиария
*/

#endregion

#region HUD
/*
1. жизнь героя
2. рейтинг героя 
3. 
*/


#endregion

#region главы
/*

*/

#endregion

#region Unit
/*
 Юниты





*/


#endregion
}
