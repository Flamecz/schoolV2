using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestControll : MonoBehaviour
{
    private static QuestControll instance;

    public Quest[] data;
    public MissionDataShower MDS;

    public Quest Selected;
    public GameObject FinnishedQuestTemp;
    public CameraMovement CM;
    public GameObject QuestWindow;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }
    public void OpenQuest()
    {
        QuestWindow.SetActive(true);
    }
    public void ActivateQuest(int whatQuest)
    {
        QuestWindow.SetActive(false);
        if(MDS.whatMission == 0)
        {

        }
        if (MDS.whatMission == 1)
        {
            CM.quest = data[1];
        }
        if (MDS.whatMission == 2)
        {

        }
    }
    public void FinnishedQuest()
    {
        FinnishedQuestTemp.SetActive(true);
    }
}
