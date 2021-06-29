using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeDiagram : MonoBehaviour {

    public int interpolationFramesCount = 200; // Number of frames to completely interpolate between the 2 positions
    int elapsedFrames = 0;

    public List<GameObject> objects;
    public List<Vector3> directions;
    public bool openclose;
    [HideInInspector]
    public List<Vector3> StartPos;
   
    // Use this for initialization
    void Start() {

        for (int i = 0; i < objects.Count; i++)
        {
            Vector3 InitPos = objects[i].transform.position; // Records the starting position for each object
            StartPos.Add(InitPos);
        }
    }

    public void openclose2() // Creates a function which can be called in the UI
    {
        if (openclose == false)
            openclose = true;
        else
            openclose = false;
    }

	// Update is called once per frame
	void Update () {

        float interpolationRatio = (float)elapsedFrames / interpolationFramesCount;

        //elapsedFrames = (elapsedFrames + 1) % (interpolationFramesCount + 1);  // reset elapsedFrames to zero after it reached (interpolationFramesCount + 1)
        if(openclose.Equals(true))
            elapsedFrames = Mathf.Min((elapsedFrames + 1),interpolationFramesCount);
        else
            elapsedFrames = Mathf.Max((elapsedFrames - 1), 0);

        for (int i = 0; i < objects.Count; i++)
        {
            Vector3 interpolatedPositionForward = Vector3.Lerp(StartPos[i], StartPos[i]+directions[i], interpolationRatio);
            objects[i].transform.position = interpolatedPositionForward;

        }
    }
}
