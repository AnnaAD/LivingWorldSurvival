using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignModel : MonoBehaviour
{
    public GameObject[] playerModels;
    public Avatar[] playerAvatars;
    public int modelId;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(transform.position);
        GameObject model = Instantiate(playerModels[modelId],transform);

        model.transform.position = transform.position;

        model.transform.GetChild(0).gameObject.AddComponent<RandomColor>();

        GetComponent<Animator>().avatar = playerAvatars[modelId];

    }
}
