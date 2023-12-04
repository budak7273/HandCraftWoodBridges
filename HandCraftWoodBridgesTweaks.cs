using CoreLib.Submodules.ModEntity.Atributes;
using HandCraftWoodBridges;
using PugMod;
using System.Runtime.Serialization;
using Unity.Entities;
using UnityEngine;

[EntityModification]
public static class HandCraftWoodBridgesTweaks
{
    [EntityModification(ObjectID.Player)]
    private static void EditPlayer(Entity entity, GameObject authoring, EntityManager entityManager)
    {
        var canCraftBuffer = entityManager.GetBuffer<CanCraftObjectsBuffer>(entity);

        addBufferEntry(canCraftBuffer, ObjectID.WoodBridge);
    }

    private static void addBufferEntry(DynamicBuffer<CanCraftObjectsBuffer> canCraftBuffer, ObjectID itemId)
    {
        Debug.Log($"[{HandCraftWoodBridgesMod.NAME}]: Adding itemId {itemId} to crafter");
        canCraftBuffer.Add(new CanCraftObjectsBuffer
        {
            objectID = itemId,
            amount = 1,
            entityAmountToConsume = 0
        });
    }
}
