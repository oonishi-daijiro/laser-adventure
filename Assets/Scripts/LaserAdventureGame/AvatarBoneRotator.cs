// this source code downloaded from https://gist.github.com/mhama/e094590f7316fc7ba59c11a405636f1d

using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Avatarのボーンを、モデルによらず同様に回転させる
/// </summary>
public class AvatarBoneRotator : MonoBehaviour
{
    [SerializeField]
    private Animator avatarAnimator;

    public Animator AvatarAnimator => avatarAnimator;

    [SerializeField]
    private Transform skeletonRoot;

    public Transform SkeletonRoot => skeletonRoot;

    private readonly Dictionary<string, Quaternion> skeletonBoneToBasePoseTable = new Dictionary<string, Quaternion>();

    private void Start()
    {
        // 180度回転を与えているのは、根本を180度回転させておかないと後ろを向いてしまうため
        StoreBasePoseRecursive(skeletonRoot, Quaternion.Euler(0f, 180f, 0f));
    }

    /// <summary>
    /// 指定ボーン配下の各ボーンのBasePose（モデルルート座標系）を保存する。
    /// </summary>
    /// <param name="trans"></param>
    /// <param name="parentRotation"></param>
    private void StoreBasePoseRecursive(Transform trans, Quaternion parentRotation)
    {
        var rotation = StoreBasePoseForABone(trans, parentRotation);
        foreach(Transform child in trans)
        {
            StoreBasePoseRecursive(child, rotation);
        }
    }
    
    /// <summary>
    /// 指定ボーンのBasePose（モデルルート座標系）を保存する
    /// 親ボーンまでのBasePoseがわかっている場合に利用できる
    /// </summary>
    /// <param name="trans"></param>
    /// <param name="parentRotation">親ボーンまでのBasePose</param>
    /// <returns></returns>
    private Quaternion StoreBasePoseForABone(Transform trans, Quaternion parentRotation)
    {
        Debug.Log($"checking bone: {trans.name}");
        var targetBoneInfo = FindSkeletonBone(trans.name);
        if (!targetBoneInfo.HasValue)
        {
            return parentRotation;
        }
        Quaternion rotation = parentRotation * targetBoneInfo.Value.rotation;
        skeletonBoneToBasePoseTable[trans.name] = rotation;
        return rotation;
    }

    /// <summary>
    /// avatar.humanDescription.skeleton内から、指定名称のボーンの情報をとりだす
    /// </summary>
    /// <param name="skeletonBoneName"></param>
    /// <returns></returns>
    private SkeletonBone? FindSkeletonBone(string skeletonBoneName)
    {
        foreach (var skeletonBone in avatarAnimator.avatar.humanDescription.skeleton)
        {
            if (skeletonBone.name == skeletonBoneName)
            {
                return skeletonBone;
            }
        }
        return null;
    }

    /// <summary>
    /// スケルトンの指定ボーンを回転させる
    /// Translation指定はHipの場合のみ適用される
    /// </summary>
    /// <param name="trans"></param>
    /// <param name="targetRotation"></param>
    /// <param name="targetTranslation"></param>
    /// <returns></returns>
    public bool RotateBone(Transform trans, Quaternion targetRotation, Vector3? targetTranslation = null)
    {
        SkeletonBone? skeletonBone = FindSkeletonBone(trans.name);
        if (skeletonBone == null)
        {
            Debug.LogWarning($"Not a skeleton bone : {trans.name}");
            return false;
        }
        var localBaseRotation = skeletonBone.Value.rotation;
        var rootRotationCorrection = (trans == skeletonRoot) ? Quaternion.Euler(0f, 180f, 0f) : Quaternion.identity;

        if (skeletonBoneToBasePoseTable.TryGetValue(trans.name, out Quaternion basePose))
        {
            // targetRotationをモデルルートの座標系でのTポーズ状態での回転として扱い、これをローカルボーン座標系の回転に変換する
            var rotationInLocalBone = Quaternion.Inverse(basePose) * targetRotation * basePose;
            
            // Tポーズへの回転と、Tポーズから目的の状態への回転を適用する
            trans.localRotation = rootRotationCorrection * localBaseRotation * rotationInLocalBone;
            
            // positionはHipsだけを受け入れることにする（ややこしくなるので）
            if (targetTranslation.HasValue && (trans == skeletonRoot) )
            {
                trans.localPosition = targetTranslation.Value;
            }
            return true;
        }
        return false;
    }

    /// <summary>
    /// HumanBodyBonesに対応するボーンを回転させる
    /// Translation指定はHipの場合のみ適用される
    /// </summary>
    /// <param name="bone"></param>
    /// <param name="targetRotation"></param>
    /// <param name="targetTranslation"></param>
    /// <returns></returns>
    public bool RotateBone(HumanBodyBones bone, Quaternion targetRotation, Vector3? targetTranslation = null)
    {
        Transform trans = avatarAnimator.GetBoneTransform(bone);
        if (trans == null)
        {
            return false;
        }
        return RotateBone(trans, targetRotation, targetTranslation);
    }
}
