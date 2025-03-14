using UnityEngine;

public class CollateTrainTracks : ProceduralComponent
{
	private const float MAX_NODE_DIST = 0.1f;

	private const float MAX_NODE_DIST_SQR = 0.010000001f;

	private const float MAX_NODE_ANGLE = 10f;

	public override bool RunOnCache => true;

	public override void Process(uint seed)
	{
		TrainTrackSpline[] array = Object.FindObjectsOfType<TrainTrackSpline>();
		TrainTrackSpline[] array2;
		for (int num = array.Length - 1; num >= 0; num--)
		{
			TrainTrackSpline ourSpline = array[num];
			if (ourSpline.dataIndex < 0 && ourSpline.points.Length > 3)
			{
				int nodeIndex;
				for (nodeIndex = ourSpline.points.Length - 2; nodeIndex >= 1; nodeIndex--)
				{
					Vector3 ourPos2 = ourSpline.points[nodeIndex];
					Vector3 ourTangent2 = ourSpline.tangents[nodeIndex];
					array2 = array;
					foreach (TrainTrackSpline trainTrackSpline in array2)
					{
						if (!(ourSpline == trainTrackSpline))
						{
							Vector3 startPointWorld = trainTrackSpline.GetStartPointWorld();
							Vector3 endPointWorld = trainTrackSpline.GetEndPointWorld();
							Vector3 startTangentWorld = trainTrackSpline.GetStartTangentWorld();
							Vector3 endTangentWorld = trainTrackSpline.GetEndTangentWorld();
							if (!CompareNodes(startPointWorld, startTangentWorld) && !CompareNodes(endPointWorld, endTangentWorld) && !CompareNodes(startPointWorld, -startTangentWorld))
							{
								CompareNodes(endPointWorld, -endTangentWorld);
							}
						}
					}
					bool CompareNodes(Vector3 theirPos, Vector3 theirTangent)
					{
						if (NodesConnect(ourPos2, theirPos, ourTangent2, theirTangent))
						{
							TrainTrackSpline trainTrackSpline2 = ourSpline.gameObject.AddComponent<TrainTrackSpline>();
							Vector3[] array4 = new Vector3[ourSpline.points.Length - nodeIndex];
							Vector3[] array5 = new Vector3[ourSpline.points.Length - nodeIndex];
							Vector3[] array6 = new Vector3[nodeIndex + 1];
							Vector3[] array7 = new Vector3[nodeIndex + 1];
							for (int num2 = ourSpline.points.Length - 1; num2 >= 0; num2--)
							{
								if (num2 >= nodeIndex)
								{
									array4[num2 - nodeIndex] = ourSpline.points[num2];
									array5[num2 - nodeIndex] = ourSpline.tangents[num2];
								}
								if (num2 <= nodeIndex)
								{
									array6[num2] = ourSpline.points[num2];
									array7[num2] = ourSpline.tangents[num2];
								}
							}
							ourSpline.SetAll(array6, array7, ourSpline);
							trainTrackSpline2.SetAll(array4, array5, ourSpline);
							nodeIndex--;
							return true;
						}
						return false;
					}
				}
			}
		}
		array = Object.FindObjectsOfType<TrainTrackSpline>();
		array2 = array;
		foreach (TrainTrackSpline ourSpline2 in array2)
		{
			Vector3 ourStartPos = ourSpline2.GetStartPointWorld();
			Vector3 ourEndPos = ourSpline2.GetEndPointWorld();
			Vector3 ourStartTangent = ourSpline2.GetStartTangentWorld();
			Vector3 ourEndTangent = ourSpline2.GetEndTangentWorld();
			if (NodesConnect(ourStartPos, ourEndPos, ourStartTangent, ourEndTangent))
			{
				ourSpline2.AddTrackConnection(ourSpline2, TrainTrackSpline.TrackPosition.Next, TrainTrackSpline.TrackOrientation.Same);
				ourSpline2.AddTrackConnection(ourSpline2, TrainTrackSpline.TrackPosition.Prev, TrainTrackSpline.TrackOrientation.Same);
				continue;
			}
			TrainTrackSpline[] array3 = array;
			foreach (TrainTrackSpline otherSpline in array3)
			{
				Vector3 theirStartPos;
				Vector3 theirEndPos;
				Vector3 theirStartTangent;
				Vector3 theirEndTangent;
				if (!(ourSpline2 == otherSpline))
				{
					theirStartPos = otherSpline.GetStartPointWorld();
					theirEndPos = otherSpline.GetEndPointWorld();
					theirStartTangent = otherSpline.GetStartTangentWorld();
					theirEndTangent = otherSpline.GetEndTangentWorld();
					if (!CompareNodes(ourStart: false, theirStart: true) && !CompareNodes(ourStart: false, theirStart: false) && !CompareNodes(ourStart: true, theirStart: true))
					{
						CompareNodes(ourStart: true, theirStart: false);
					}
				}
				bool CompareNodes(bool ourStart, bool theirStart)
				{
					Vector3 ourPos3 = (ourStart ? ourStartPos : ourEndPos);
					Vector3 ourTangent3 = (ourStart ? ourStartTangent : ourEndTangent);
					Vector3 theirPos2 = (theirStart ? theirStartPos : theirEndPos);
					Vector3 theirTangent2 = (theirStart ? theirStartTangent : theirEndTangent);
					if (ourStart == theirStart)
					{
						theirTangent2 *= -1f;
					}
					if (NodesConnect(ourPos3, theirPos2, ourTangent3, theirTangent2))
					{
						if (ourStart)
						{
							ourSpline2.AddTrackConnection(otherSpline, TrainTrackSpline.TrackPosition.Prev, theirStart ? TrainTrackSpline.TrackOrientation.Reverse : TrainTrackSpline.TrackOrientation.Same);
						}
						else
						{
							ourSpline2.AddTrackConnection(otherSpline, TrainTrackSpline.TrackPosition.Next, (!theirStart) ? TrainTrackSpline.TrackOrientation.Reverse : TrainTrackSpline.TrackOrientation.Same);
						}
						if (theirStart)
						{
							otherSpline.AddTrackConnection(ourSpline2, TrainTrackSpline.TrackPosition.Prev, ourStart ? TrainTrackSpline.TrackOrientation.Reverse : TrainTrackSpline.TrackOrientation.Same);
						}
						else
						{
							otherSpline.AddTrackConnection(ourSpline2, TrainTrackSpline.TrackPosition.Next, (!ourStart) ? TrainTrackSpline.TrackOrientation.Reverse : TrainTrackSpline.TrackOrientation.Same);
						}
						return true;
					}
					return false;
				}
			}
		}
		static bool NodesConnect(Vector3 ourPos, Vector3 theirPos, Vector3 ourTangent, Vector3 theirTangent)
		{
			if (Vector3.SqrMagnitude(ourPos - theirPos) < 0.010000001f)
			{
				return Vector3.Angle(ourTangent, theirTangent) < 10f;
			}
			return false;
		}
	}
}
