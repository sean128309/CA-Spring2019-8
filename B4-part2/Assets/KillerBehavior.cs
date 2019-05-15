using UnityEngine;
using System;
using System.Collections;
using TreeSharpPlus;

public class KillerBehavior : MonoBehaviour
{
    public GameObject participant;
    public Transform bomb1;
    public Transform bomb2;
    public Transform police;
    public Transform exit;
    public Transform stopat;
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
    protected Node plant()
    {
        return participant.GetComponent<BehaviorMecanim>().ST_PlayHandGesture("CowBoy", 800);
    }
    protected Node BuildTreeRoot()
    {
        Func<bool> act = () => (Vector3.Distance(participant.transform.position, police.position) > 1.5);
        
        Node trigger = new DecoratorLoop(new LeafAssert(act));
        //Node kill = new Sequence();
        //Node walktopolice = new DecoratorLoop(new DecoratorForceStatus(RunStatus.Success, new SequenceParallel(trigger, new Sequence(this.approach(police)))));
        //Node walktopolice = new DecoratorLoop(new Sequence(this.approach(police)));
        Node walktopolice = new Sequence(new Selector(new SequenceParallel(trigger, new Sequence(this.approach(police))), this.punch()), this.approach(bomb1),this.plant(),this.approach(bomb2),this.plant(), new DecoratorLoop(this.approach(exit)));
        //Node root = new Sequence(walktopolice, this.punch());
        
        return walktopolice;
    }
}