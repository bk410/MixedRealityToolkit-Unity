﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using Microsoft.MixedReality.Toolkit.Physics;
using UnityEngine;

namespace Microsoft.MixedReality.Toolkit.Input
{
    /// <summary>
    /// The default implementation of IMixedRealityRaycastProvider.
    /// </summary>
    public class DefaultRaycastProvider : BaseCoreSystem, IMixedRealityRaycastProvider
    {
        public DefaultRaycastProvider(
            IMixedRealityServiceRegistrar registrar,
            MixedRealityInputSystemProfile profile) : base(registrar, profile)
        { }

        /// <inheritdoc />
        public bool Raycast(RayStep step, LayerMask[] prioritizedLayerMasks, out MixedRealityRaycastHit hitInfo)
        {
            bool result = MixedRealityRaycaster.RaycastSimplePhysicsStep(step, step.Length, prioritizedLayerMasks, out RaycastHit physicsHit);
            hitInfo = new MixedRealityRaycastHit(result, physicsHit);
            return result;
        }

        /// <inheritdoc />
        public bool SphereCast(RayStep step, float radius, LayerMask[] prioritizedLayerMasks, out MixedRealityRaycastHit hitInfo)
        {
            var result = MixedRealityRaycaster.RaycastSpherePhysicsStep(step, radius, step.Length, prioritizedLayerMasks, out RaycastHit physicsHit);
            hitInfo = new MixedRealityRaycastHit(result, physicsHit);
            return result;
        }
    }
}
