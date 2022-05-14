using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : MonoBehaviour
{
    enum STATE { GO_NEXT_POINT, EAT}
    STATE m_state;
    Transform m_nextPoint;
    Vector3 m_direction;
    [SerializeField] Transform[] m_eatPoints;
    [SerializeField] float m_speed;
    int m_walkHash;
    int m_runHash;
    int m_jumpHash;
    int m_eatHash;
    Animator m_animator;
    [SerializeField] float m_minTimeToEat = 1.0f;
    [SerializeField] float m_maxTimeToEat  = 4.0f;

    Timer m_eventTimer;
    float m_eventDuration;

    private void Awake() {

        m_animator = GetComponent<Animator>();
        m_eventTimer = gameObject.AddComponent<Timer>();

        m_walkHash = Animator.StringToHash("Walk");
        m_runHash = Animator.StringToHash("Run");
        m_jumpHash = Animator.StringToHash("Jump");
        m_eatHash = Animator.StringToHash("Eat");
    }

    private void Start() {
        m_nextPoint = m_eatPoints[0];
        InitializeGoToNextPoint();
    }

    private void Update() {
        switch(m_state){
            case STATE.GO_NEXT_POINT:{
                HandleGoToNextPoint();
            }
            break;
            case STATE.EAT:{
                HandleEating();
            }
            break;
        }
    }

    void InitializeGoToNextPoint(){
        int nextPointIndex;

        do{
            nextPointIndex = Random.Range(0, m_eatPoints.Length);
            
        }while(m_nextPoint.position == m_eatPoints[nextPointIndex].position);

        float randomDirection  = Random.Range(0,2*Mathf.PI);
        Vector3 test = new Vector3(Mathf.Cos(randomDirection), 0 , Mathf.Sin(randomDirection));

        m_nextPoint = m_eatPoints[nextPointIndex];
        m_nextPoint.position += 0.5f * test;

        m_direction = m_nextPoint.position - transform.position;
        m_direction = new Vector3(m_direction.x, 0, m_direction.z);
        m_animator.SetBool(m_walkHash, true);
        m_animator.SetBool(m_eatHash, false);
        transform.LookAt(new Vector3(m_nextPoint.position.x, transform.position.y, m_nextPoint.position.z));
        m_state = STATE.GO_NEXT_POINT;
    }

    void HandleGoToNextPoint(){

        

        float distanceToPoint = (new Vector2(transform.position.x, transform.position.z) - new Vector2(m_nextPoint.position.x, m_nextPoint.position.z)).magnitude;
        if(distanceToPoint > 1){
            transform.Translate(Vector3.forward * m_speed * Time.deltaTime);
        }
        else{
            InitializeEating();
        }
    }

    void InitializeEating(){
        m_animator.SetBool(m_walkHash, false);
        m_animator.SetBool(m_eatHash, true);
        m_eventTimer.Duration = Random.Range(m_minTimeToEat, m_maxTimeToEat);
        m_eventTimer.Restart();
        m_state = STATE.EAT;
    }

    void HandleEating(){
        if(m_eventTimer.IsFinished){
            InitializeGoToNextPoint();
        }
    }

}
