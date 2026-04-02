using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimalWeight
{
    public class WeightCalculator
    {
        /// <summary>
        /// Выполняет расчёт нормального веса и определяет отклонение от нормы
        /// </summary>
        /// <param name="Height">Рост пользователя в виде строки (см)</param>
        /// <param name="Weight">Вес пользователя в виде строки (кг)</param>
        /// <param name="isMale">Пол пользователя: true — мужчина, false — женщина</param>
        /// <returns>
        /// Кортеж:
        /// success — успешность выполнения (true/false)
        /// message — результат расчёта или текст ошибки
        /// </returns>
        public (bool success, string message) Calculate(string Height, string Weight, bool isMale)
        {
            if (!double.TryParse(Height, out double height) ||
                !double.TryParse(Weight, out double weight))
                return (false, "Введите значения.");

            if (height < 130 || height > 220)
                return (false, "Рост должен быть от 130 до 220 см.");

            if (weight < 40 || weight > 170)
                return (false, "Вес должен быть от 40 до 170 кг.");

            double normalWeight = isMale 
                ? (height - 100) * 1.13 
                : (height - 100) * 0.9;

            string result;
            if (weight < normalWeight - 3)
                result = "Ниже нормы";
            else if (weight > normalWeight + 3)
                result = "Выше нормы";
            else
                result = "Норма";

            return (true, $"Нормальный вес: {normalWeight:F1} кг. Оценка: {result}");
        }

    }
}
