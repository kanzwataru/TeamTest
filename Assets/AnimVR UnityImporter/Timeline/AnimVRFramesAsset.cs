﻿using AnimVR;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace ANIMVR
{
    public class AnimVRFramesAsset : PlayableAsset, ITimelineClipAsset
    {
        Transform parent;

        public float FPS = 1;
        public List<int> FrameIndices = new List<int>();
        public FrameFadeMode FadeIn, FadeOut;

        public ClipCaps clipCaps { get { return ClipCaps.All;  } }

        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
        {
            var playable = ScriptPlayable<AnimVRFramesPlayable>.Create(graph);
            var behaviour = playable.GetBehaviour();
            parent = GetGameObjectBinding(owner.GetComponent<PlayableDirector>()).transform;
            behaviour.Parent = parent;
            behaviour.FPS = FPS;
            behaviour.FrameIndices = FrameIndices;
            behaviour.FadeIn = FadeIn;
            behaviour.FadeOut = FadeOut;
            return playable;
        }

        GameObject GetGameObjectBinding(PlayableDirector director)
        {
            if ((UnityEngine.Object)director == (UnityEngine.Object)null)
                return (GameObject)null;

            GameObject genericBinding1 = director.GetGenericBinding((UnityEngine.Object)this) as GameObject;
            if ((UnityEngine.Object)genericBinding1 != (UnityEngine.Object)null)
                return genericBinding1;

            Component genericBinding2 = director.GetGenericBinding((UnityEngine.Object)this) as Component;
            if ((UnityEngine.Object)genericBinding2 != (UnityEngine.Object)null)
                return genericBinding2.gameObject;
            return (GameObject)null;
        }

        public override IEnumerable<PlayableBinding> outputs
        {
            get
            {
                var binding = AnimationPlayableBinding.Create(this.name + " Parent", this);
                return new PlayableBinding[] { binding };
            }
        }
    }
}