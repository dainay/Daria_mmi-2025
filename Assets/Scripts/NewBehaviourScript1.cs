using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript1 : MonoBehaviour // class de base. to be able attach it to the component
{
    // Start is called before the first frame update
    //void - this method does t return anything
    //private - par default/ public - everyone has acess, other classes. private - accessible only from inside of this class.
    //protected - this class and cass child has access
    //works for variables and propriete

    [SerializeField] private string m_MyMessage; // attribut to make unity to have access to private variables // variable private with prefix

    
    //--------------------------------------------------------
    [SerializeField] private float m_Threshold; // float - not object. it is
    [SerializeField] private CharacterController  m_Player; //transform class exist. Type reference. so when we have acces to this - the same object.


    Vector3 m_Origin;

    //----------------------------------------------------------
    private void Awake()
    {
        Debug.Log(m_MyMessage);
        m_Origin = m_Player.transform.position;
    }

    string MyMessage
    {
        get { return m_MyMessage ; } //this will let you to accept changing only on yours conditions.
         set { m_MyMessage = value; } //put private at the beginning - can write only me, but read everywhere

    }


    void Start()
    {
        Debug.Log("Start"); 
    }

    private void Respawn() {
        m_Player.enabled = false; 
        m_Player.transform.position = m_Origin;
        m_Player.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update" + Time.deltaTime); //time between 2 frames 
        Debug.Log(m_Player.transform.position);

        if (m_Player.transform.position.y < m_Threshold)
        {
            Debug.Log("FAIL");
            Respawn();
         
        }  


    }

    private void FixedUpdate() //executed always at the same moment of the frame. always executes at the same time of the frame.
    { 
        Debug.Log("Fixed update" + Time.deltaTime);
    }
}
