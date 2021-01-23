using SurviveThisDLL;
using UnityEngine;

public class Entity : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Utils nice = new Utils();
        Debug.Log(nice.AddValues(1, 2));
    }


}
