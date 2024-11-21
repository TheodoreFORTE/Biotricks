using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    private GameObject mainCanvas;

    [SerializeField]
    private GameObject SceneChampionController;

    [SerializeField]
    private GameObject LifeBarUI;

   


    void Awake()
    {
        mainCanvas = GameObject.FindGameObjectWithTag("MainCanvas");
    }


   
    public void SpawnSceneChampions()
    {

        GameObject[] UIchampionController = GameObject.FindGameObjectsWithTag("ChampionUI"); //Line to optimize
        
        foreach(GameObject championUI in UIchampionController)
        {
            ChampionWrapperUI currentChampionWrapper = championUI.GetComponent<ChampionWrapperUI>();
            Vector3 spawnPosition = championUI.transform.position;

            GameObject newSceneChampionController = Instantiate(SceneChampionController, spawnPosition, Quaternion.identity);            
            ChampionWrapperScene newChampionWrapper = newSceneChampionController.GetComponent<ChampionWrapperScene>();
            newChampionWrapper.LoadChampionData(currentChampionWrapper);

            GameObject lifeBarUI = Instantiate(LifeBarUI);
            lifeBarUI.GetComponent<ChampionHealthUI>().LinkChampionData(newSceneChampionController);

            Destroy(championUI);

            
        }   

    }





}
