using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingLibrary
{
    /// <summary>
    /// Элемент данных хеш таблицы.
    /// </summary>
    public class Item
    {
        /// <summary>
        /// Ключ.
        /// </summary>
        public string Key { get; private set; }

        /// <summary>
        /// Хранимые данные.
        /// </summary>
        public Building Value { get; private set; }

        /// <summary>
        /// Создать новый экземпляр хранимых данных Item.
        /// </summary>
        /// <param name="key"> Ключ. </param>
        /// <param name="value"> Значение. </param>
        public Item(string key, Building value)
        {
            // Проверяем входные данные на корректность.
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (value is null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            // Устанавливаем значения.
            Key = key;
            Value = value;
        }

        /// <summary>
        /// Приведение объекта к строке.
        /// </summary>
        /// <returns> Ключ объекта. </returns>
        public override string ToString()
        {
            return Key;
        }
    }
}
