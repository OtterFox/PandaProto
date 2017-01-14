using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class ObjectFallProto : MonoBehaviour {
    //instantiate & make object fall break up later
    
    [SerializeField] GameObject[] pieces;
    [SerializeField] Transform _fall;
    private Rigidbody _pieces;

    public Text missText;
    public Text CountText;
    public Text PerfectText;
    public int fallpieces;
    float fallSpd = .10f;
   public bool canFall;
    
	void Start ()
    {
        canFall = true;
        ObjectFall();
        missText.enabled = false;
    }
	
	
	void Update ()
    {
        ObjectSpawn();

    }

    public void ObjectFall()
    {
        if (canFall)
        {
            _pieces = Instantiate(pieces[Random.Range(0, pieces.Length)], transform.position, Quaternion.identity) as Rigidbody;
            //StartCoroutine("ObjectSpawn");
            ++fallpieces;
            canFall = false;
        }
    }

    IEnumerator ObjectSpawn()
    {
       //
       // print(fallpieces);
        //fallSpd -= .05f;
        yield return new WaitForSeconds(2f);
        ObjectFall();
    }
}
