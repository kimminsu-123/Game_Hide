using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine.Editor;
using Com.Hide.UI;
using UnityEditor;
using UnityEditor.Rendering;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

[CustomEditor(typeof(SoundButton)), CanEditMultipleObjects]
public class SoundButtonInspector : Editor
{
    // origin properties
    private SerializedProperty _interactable;
    private SerializedProperty _transition;
    private SerializedProperty _navigation;
    private SerializedProperty _onClick;
    
    private SerializedProperty _targetGraphic;

    // transition - color tint properties
    private SerializedProperty _colors;
    
    // transition - sprite swap properties
    private SerializedProperty _spriteState;

    // transition - animation triggers properties
    private SerializedProperty _animationTriggers;
    
    // sound button properties
    private SerializedProperty _clickSound;
    private SerializedProperty _hoverSound;
    private SerializedProperty _unHoverSound;
    private SerializedProperty _audioSource;

    public override void OnInspectorGUI()
    {
        FindProperties();

        DrawProperties();

        if (GUI.changed)
            EditorUtility.SetDirty(target);
    }

    private void FindProperties()
    {
        _interactable = serializedObject.FindProperty("m_Interactable");
        _transition = serializedObject.FindProperty("m_Transition");
        _navigation = serializedObject.FindProperty("m_Navigation");
        
        _targetGraphic = serializedObject.FindProperty("m_TargetGraphic");
        
        _colors = serializedObject.FindProperty("m_Colors");
        
        _spriteState = serializedObject.FindProperty("m_SpriteState");

        _animationTriggers = serializedObject.FindProperty("m_AnimationTriggers");

        _onClick = serializedObject.FindProperty("m_OnClick");
        
        _clickSound = serializedObject.FindProperty("clickSound");
        _hoverSound = serializedObject.FindProperty("hoverSound");
        _unHoverSound = serializedObject.FindProperty("unHoverSound");
        _audioSource = serializedObject.FindProperty("audioSource");
    }

    private void DrawProperties()
    {
        serializedObject.Update();
        
        EditorGUILayout.BeginVertical();
        
        EditorGUILayout.PropertyField(_interactable);
        EditorGUILayout.PropertyField(_transition);

        EditorGUI.indentLevel = 1;
        switch ((Selectable.Transition)_transition.intValue)
        {
            case Selectable.Transition.None:
                DrawTransitionProperties_None();
                break;
            case Selectable.Transition.ColorTint:
                DrawTransitionProperties_ColorTint();
                break;
            case Selectable.Transition.SpriteSwap:
                DrawTransitionProperties_SpriteSwap();
                break;
            case Selectable.Transition.Animation:
                DrawTransitionProperties_Animation();
                break;
            default:
                DrawTransitionProperties_None();
                break;
        }
        EditorGUI.indentLevel = 0;
        
        EditorGUILayout.PropertyField(_navigation);
        
        DrawSoundButtonProperties();
        
        EditorGUILayout.EndVertical();
        
        serializedObject.ApplyModifiedProperties();
    }

    private void DrawTransitionProperties_None() { }
    
    private void DrawTransitionProperties_ColorTint()
    {
        EditorGUILayout.PropertyField(_targetGraphic);
        EditorGUILayout.PropertyField(_colors);
    }
    
    private void DrawTransitionProperties_SpriteSwap()
    {
        EditorGUILayout.PropertyField(_targetGraphic);
        EditorGUILayout.PropertyField(_spriteState);
    }
    
    private void DrawTransitionProperties_Animation()
    {
        EditorGUILayout.PropertyField(_animationTriggers);
    }
    
    private void DrawSoundButtonProperties()
    {
        EditorGUILayout.PropertyField(_clickSound);
        EditorGUILayout.PropertyField(_hoverSound);
        EditorGUILayout.PropertyField(_unHoverSound);
        EditorGUILayout.PropertyField(_audioSource);
        EditorGUILayout.PropertyField(_onClick);
    }
}