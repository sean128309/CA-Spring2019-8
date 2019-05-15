using UnityEngine;
using System;
using System.Collections;
using TreeSharpPlus;

public class StudentBehavior : MonoBehaviour
{
    public GameObject participant;
    private BehaviorAgent behaviorAgent;
    public GameObject explosion;
    public GameObject alarm;
    public Transform exit;
    public Transform exit1;
    // Start is called before the first frame update
    void Start()
    {
        behaviorAgent = new BehaviorAgent(this.BuildTreeRoot());
        BehaviorManager.Instance.Register(behaviorAgent);
        behaviorAgent.StartBehavior();
        
    }
    protected Node approach(Transform target)
    {
        Val<Vector3> position = Val.V(() => target.position);
        return participant.GetComponent<BehaviorMecanim>().Node_GoTo(position);
    }
    // Update is called once per frame
    protected Node punch()
    {
        return participant.GetComponent<BehaviorMecanim>().ST_PlayHandGesture("Bash", 800);
    }
    protected Node dying()
    {

        return participant.GetComponent<BehaviorMecanim>().ST_PlayBodyGesture("Dying", 800);
    }

    protected Node awe()
    {
        return participant.GetComponent<BehaviorMecanim>().ST_PlayHandGesture("Wonderful", 1792);
    }

    protected Node yawn()
    {
        return participant.GetComponent<BehaviorMecanim>().ST_PlayHandGesture("Yawn", 8333);
    }
    protected Node think()
    {
        return participant.GetComponent<BehaviorMecanim>().ST_PlayHandGesture("Think", 4233);
    }
    protected Node BuildTreeRoot()
    {
        Func<bool> act1 = () => (!explosion.activeSelf || participant.transform.position.x > 0);
        Func<bool> act2 = () => (alarm.activeSelf);
        Func<bool> act3 = () => (!alarm.activeSelf);
        Node triggerdie = new DecoratorLoop(new LeafAssert(act1));
        Node triggerrun = new DecoratorLoop(new LeafAssert(act2));
        Node triggeridle = new DecoratorLoop(new LeafAssert(act3));

        Node dietoexplosion = new Selector(triggerdie, new DecoratorLoop(this.dying()));
        //Node flee = new Selector(triggerrun,this.approach(exit));
        Node flee = new DecoratorLoop(new DecoratorForceStatus(RunStatus.Success, new SequenceParallel(triggerrun, new SelectorShuffle(this.approach(exit), this.approach(exit1)))));
        Node idle = new SequenceParallel(new DecoratorLoop(new SelectorShuffle(this.awe(), this.yawn(), this.think())), triggeridle);
        Node root = new Selector(new DecoratorLoop(idle), new SequenceParallel(flee, dietoexplosion));
        
        return root;
    }
}
