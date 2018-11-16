using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateSlices : MonoBehaviour {

    public GameObject prefab;
    public Transform parent;
    public Sprite[] whaleParts;
    public List<GameObject> slices;

    public int NumberOfSlices;

    private bool isTransparent = false;
  
	void Start () {

        GameObject oldSlice = null;

        for(int x = 0; x < NumberOfSlices; x++)
        {
            var slice = Instantiate(prefab, parent, false);

            slice.GetComponent<Image>().sprite = whaleParts[(whaleParts.Length - 1) - x ];
            slice.GetComponent<FollowCursor>().moveSpeed = 5f;
            slice.GetComponent<FollowCursor>().isFirst = false;

            if (x != 0)
            {
                oldSlice.GetComponent<FollowCursor>().nextPos = slice.GetComponent<Transform>();
            }

            if (x == NumberOfSlices - 1)
            {
                slice.GetComponent<FollowCursor>().isFirst = true;
                slice.GetComponent<FollowCursor>().moveSpeed = .02f;
            }
            slices.Add(slice);
            oldSlice = slice;
        }
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.G))
        {
            if (!isTransparent)
            {
                for (int x = 0; x < slices.Count; x++)
                {
                    slices[x].GetComponent<Image>().color = new Color(1, 1, 1, .1f);
                }
            }
            else
            {
                for (int x = 0; x < slices.Count; x++)
                {
                    slices[x].GetComponent<Image>().color = new Color(1, 1, 1, 1f);
                }
            }

            isTransparent = !isTransparent;
        }
       
    }
}
