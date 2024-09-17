using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    [Header("Inscribed")]
    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;

    // Start is called before the first frame update
    void Start()
    {
        basketList = new List<GameObject>();
        for (int i = 0; i < numBaskets; i++)
        {
            GameObject tBasketGo = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGo.transform.position = pos;
            basketList.Add(tBasketGo);
        }//end for (i < numBaskets)
    }

    public void AppleMissed()
    {
        //Destory all the currently falling Apples
        GameObject[] appleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject tempGo in appleArray)
        {
            Destroy(tempGo);
        }//end foreach

        //Destory one of the Basets if apple is missed
        //Get the index of the last Basket in the basketList
        int BasketIndex = basketList.Count - 1;
        //Get reference to the last Basket GameObject
        GameObject basketGo = basketList[BasketIndex];
        //Desotry the Basket from the list
        basketList.RemoveAt(BasketIndex);
        Destroy(basketGo);

        //If there are no baskets left, restart the game
        if (basketList.Count == 0)
        {
            SceneManager.LoadScene("SampleScene");
        }//end if (basketList.Count > 0)  

    }//end AppleMissed()
}
