using UnityEngine;
using System;
using System.Collections;
using TreeSharpPlus;

public class MyBehaviorTree : MonoBehaviour
{
	public Transform wander1;
	public Transform wander2;
	public Transform wander3;
    public Transform wander4;
    public GameObject participant;

	private BehaviorAgent behaviorAgent;
	// Use this for initialization
	void Start ()
	{
		behaviorAgent = new BehaviorAgent (this.BuildTreeRoot ());
		BehaviorManager.Instance.Register (behaviorAgent);
		behaviorAgent.StartBehavior ();
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	protected Node ST_ApproachAndWait(Transform target)
	{
		Val<Vector3> position = Val.V (() => target.position);
		return new Sequence( participant.GetComponent<BehaviorMecanim>().Node_GoTo(position));
	}

	protected Node BuildTreeRoot()
	{

        Func<bool> bellrang = () => (!Input.GetKeyDown("space"));

        Node bell = new DecoratorLoop(new LeafAssert(bellrang));
        Node roaming = new DecoratorLoop (
						new SequenceShuffle(
						this.ST_ApproachAndWait(this.wander1),
						this.ST_ApproachAndWait(this.wander2),
                        this.ST_ApproachAndWait(this.wander4)));
        Node patrol = new DecoratorForceStatus(RunStatus.Success, new SequenceParallel(roaming, bell));
        Node runandfind = new Sequence(this.ST_ApproachAndWait(this.wander3), new DecoratorLoop(participant.GetComponent<BehaviorMecanim>().ST_PlayHandGesture("Think", 4000)));
        Node root = new Sequence(patrol, runandfind);
		return root;
	}
}
