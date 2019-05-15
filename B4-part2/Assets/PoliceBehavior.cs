using UnityEngine;
using System;
using System.Collections;
using TreeSharpPlus;

public class PoliceBehavior : MonoBehaviour
{
    public GameObject participant;
    public Transform killer;
    public Transform wander1;
    public Transform wander2, alarm;
    private BehaviorAgent behaviorAgent;
    // Start is called before the first frame update
    void Start()
    {
        behaviorAgent = new BehaviorAgent(this.BuildTreeRoot());
        BehaviorManager.Instance.Register(behaviorAgent);
        behaviorAgent.StartBehavior();
    }

    // Update is called once per frame
    void Update()
    {

    }
    protected Node approach(Transform target)
    {
        Val<Vector3> position = Val.V(() => target.position);
        return participant.GetComponent<BehaviorMecanim>().Node_GoTo(position);
    }
    protected Node punch()
    {
        return participant.GetComponent<BehaviorMecanim>().ST_PlayHandGesture("Bash", 800);
    }

    protected Node dying()
    {
        return participant.GetComponent<BehaviorMecanim>().ST_PlayBodyGesture("Dying", 800);
    }


    protected Node BuildTreeRoot()
    {
        Func<bool> act = () => (Vector3.Distance(participant.transform.position, killer.position) > 1.5);
        Node roam = new DecoratorLoop(new Sequence(this.approach(wander1), this.approach(wander2)));
        Node findalarm = new DecoratorLoop(this.approach(alarm));
        Func<bool> act2 = () => (killer.position.x > 0);
       
        //Node roam = new Sequence(this.approach(wander1), this.approach(wander2));
        Node trigger = new DecoratorLoop(new SequenceParallel(new LeafAssert(act), new LeafAssert(act2)));
        Node trigger2 = new DecoratorLoop(new LeafAssert(act));
        
        //Node root = new Sequence(new Selector(new SequenceParallel(trigger, roam), new DecoratorLoop(this.dying())));
        Node root = new Sequence(new Selector(new SequenceParallel(trigger, roam), new SequenceParallel(trigger2, findalarm), new DecoratorLoop(this.dying())));

        //Node attacked = new Selector(new SequenceParallel(DecoratorLoop(roam), trigger), this.die()); 


        return root;
    }
}