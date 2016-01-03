using System;
using System.Reflection;

namespace Plotter
{
    /// <summary>
    ///     Класс для выполнения операций над группой объектов.
    /// </summary>
    public class ObjectGroup
    {
        /// <summary>
        ///     Массив объектов группы.
        /// </summary>
        public readonly object[] Objs;

        /// <summary>
        ///     Сохраняет группу объектов.
        /// </summary>
        /// <param name="objs">Объекты, входящие в группу.</param>
        public ObjectGroup(params object[] objs)
        {
            Objs = objs;
        }

        /// <summary>
        ///     Устанавливает свойство группе объектов.
        /// </summary>
        /// <param name="property">Название свойства.</param>
        /// <param name="value">Значение свойства.</param>
        public void SetProperty(string property, object value)
        {
            foreach (var obj in Objs)
            {
                var prop = obj.GetType().GetProperty(property, BindingFlags.Public | BindingFlags.Instance);
                if (prop != null) prop.SetValue(obj, value, null);
            }
        }

        /// <summary>
        ///     Добавляет обработчик события группе объектов.
        /// </summary>
        /// <param name="eventName">Название события.</param>
        /// <param name="handler">Обработчик события.</param>
        public void AddEventHandler(string eventName, Delegate handler)
        {
            foreach (var obj in Objs)
            {
                var ev = obj.GetType().GetEvent(eventName, BindingFlags.Public | BindingFlags.Instance);
                if (ev != null) ev.AddEventHandler(obj, handler);
            }
        }
    }
}