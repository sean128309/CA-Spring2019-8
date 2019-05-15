using UnityEngine;
using System;
using System.Collections;
using TreeSharpPlus;

public class MyBehaviorTree3 : MonoBehaviour
{
    public Transform wander1;
    public Transform wander2;
    public Transform wander3;
    public GameObject participant;
    public GameObject police1, police2;
    public Transform goldsgot;
    public Transform goldsleft;

    private BehaviorAgent behaviorAgent;
    // Use this for initialization
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

   
    protected Node reach()
    {
        return participant.GetComponent<BehaviorMecanim>().ST_PlayHandGesture("CowBoy", 800);
    }

    
    
    protected Node BuildTreeRoot()
    {
        //Val<float> pp = Val.V(() => police.transform.position.z);
        Func<bool> act1 = () => (Vector3.Distance(participant.transform.position, police1.transform.position) >= 10);
        Func<bool> act2 = () => (Vector3.Distance(participant.transform.position, police2.transform.position) >= 10);
        Func<bool> notdropped = () => (goldsgot.childCount + goldsleft.childCount != 5);
        Func<bool> bellrang = () => (!Input.GetKeyDown("space"));
        Func<bool> bellnotrang = () => (Input.GetKeyDown("space"));
        Func<bool> stealend = () => (goldsgot.childCount < 5);
        Func<bool> small = () => (goldsgot.childCount < 1);
        Func<bool> nosteal = () => (goldsgot.childCount >= 5);
        /*Node roaming = new DecoratorLoop(
                        new Sequence(
                        
                        this.ST_ApproachAndPick(this.wander2),
                        this.ST_ApproachAndDrop(this.wander3)));*/
        Node trigger1 = new DecoratorLoop(new LeafAssert(act1));
        Node trigger2 = new DecoratorLoop(new LeafAssert(act2));
        Node notbell = new DecoratorLoop(new LeafAssert(bellnotrang));
        Node bell = new DecoratorLoop(new LeafAssert(bellrang));
        Node gotit = new DecoratorLoop(new LeafAssert(stealend));
        Node gotit1 = new LeafAssert(stealend);


        Node nogotit = new DecoratorLoop(new LeafAssert(nosteal));
        Node WalkWithNothing = new Sequence(this.approach(this.wander2), this.reach());
        Node WalkWithGold = new Sequence(this.approach(this.wander3), this.reach());
        Node StopWhenDanger = new DecoratorLoop(new DecoratorForceStatus(RunStatus.Success, new SequenceParallel(trigger1,trigger2, WalkWithGold)));
        Node endSWD = new DecoratorLoop(new LeafAssert(notdropped)); 
        Node sneak = new DecoratorForceStatus(RunStatus.Success, new SequenceParallel(endSWD, StopWhenDanger));
        Node steal = new DecoratorLoop(new Sequence(WalkWithNothing, sneak));
        Node stealing = new DecoratorForceStatus(RunStatus.Success, new SequenceParallel(steal, gotit, bell));

        Node happy = participant.GetComponent<BehaviorMecanim>().ST_PlayHandGesture("Cheer", 3000);
        Node sad = participant.GetComponent<BehaviorMecanim>().ST_PlayHandGesture("Clap", 5300);
        Node sadornot = new SequenceParallel(sad, gotit1);
        Node shocked = participant.GetComponent<BehaviorMecanim>().ST_PlayHandGesture("Surprised", 3200);
        Node scaredbybell = new DecoratorForceStatus(RunStatus.Success, new SequenceParallel(shocked, gotit1));
        Node happyorsad = new Selector(sadornot, happy);

        Node flee = new Sequence(
                    scaredbybell,
                    this.approach(this.wander3),
                    this.approach(this.wander1),
                    new DecoratorLoop(happyorsad));
        /*Node flee = new Sequence(
                     
                     this.approach(this.wander1),
                     new DecoratorLoop(happyorsad));*/

        Node root = new Sequence(stealing, flee);
        return root;
    }
}
