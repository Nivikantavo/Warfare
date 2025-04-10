using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using System.Collections.Generic;

[CustomEditor(typeof(UnitDataConfig))]
public class UnitDataConfigEditor : Editor
{
    private ReorderableList _stateList;
    private SerializedProperty _statesProperty;

    private void OnEnable()
    {
        _statesProperty = serializedObject.FindProperty("States");

        _stateList = new ReorderableList(serializedObject, _statesProperty, true, true, true, true);

        _stateList.drawHeaderCallback = (Rect rect) =>
        {
            EditorGUI.LabelField(rect, "Список состояний (StateConfigSO)");
        };

        _stateList.drawElementCallback = (Rect rect, int index, bool isActive, bool isFocused) =>
        {
            SerializedProperty element = _stateList.serializedProperty.GetArrayElementAtIndex(index);
            rect.y += 2;
            EditorGUI.PropertyField(
                new Rect(rect.x, rect.y, rect.width, EditorGUIUtility.singleLineHeight),
                element, GUIContent.none);
        };

        _stateList.onAddCallback = (ReorderableList list) =>
        {
            list.serializedProperty.arraySize++;
            list.index = list.serializedProperty.arraySize - 1;
        };
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        // Рисуем все поля, кроме States
        DrawPropertiesExcluding(serializedObject, "States");

        // Рисуем список состояний
        EditorGUILayout.Space(10);
        _stateList.DoLayoutList();

        serializedObject.ApplyModifiedProperties();

        // Кнопка добавления дефолтных состояний
        EditorGUILayout.Space(10);
        if (GUILayout.Button("Добавить дефолтные состояния"))
        {
            UnitDataConfig config = (UnitDataConfig)target;

            Undo.RecordObject(config, "Добавление дефолтных состояний");

            var newStates = new List<StateConfigSO>
            {
                CreateInstance<StartIdleStateConfig>(),
                CreateInstance<AttackStateConfig>(),
                CreateInstance<DieStateConfig>()
            };

            config.SetStates(newStates);

            EditorUtility.SetDirty(config);

            // Обновляем SerializedObject после прямого изменения
            serializedObject.Update();
        }
    }
}
