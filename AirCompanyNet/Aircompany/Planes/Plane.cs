using System.Collections.Generic;

namespace Aircompany.Planes
{
    public abstract class Plane
    {
        // заменил модификаторы доступа на private
        private string _model;
        private int _maxSpeed;
        private int _maxFlightDistance;
        private int _maxLoadCapacity;

        public Plane() { }  // добавил пустой конструктор

        public Plane(string model, int maxSpeed, int maxFlightDistance, int maxLoadCapacity)
        {
            _model = model;
            _maxSpeed = maxSpeed;
            _maxFlightDistance = maxFlightDistance;
            _maxLoadCapacity = maxLoadCapacity;
        }

        // видоизменил get функции на стрелочные и в их названиях убрал сокращения
        public string Model => _model;
        public int MaxSpeed => _maxSpeed;
        public int MaxFlightDistance => _maxFlightDistance;
        public int MaxLoadCapacity => _maxLoadCapacity;

        public override bool Equals(object obj)
        {
            var plane = obj as Plane;
            return plane != null &&
                   _model == plane._model &&
                   _maxSpeed == plane._maxSpeed &&
                   _maxLoadCapacity == plane._maxLoadCapacity &&
                   _maxFlightDistance == plane._maxFlightDistance;
        }

        public override int GetHashCode()
        {
            var hashCode = -1043886837;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_model);
            hashCode = hashCode * -1521134295 + _maxSpeed.GetHashCode();
            hashCode = hashCode * -1521134295 + _maxFlightDistance.GetHashCode();
            hashCode = hashCode * -1521134295 + _maxLoadCapacity.GetHashCode();
            return hashCode;
        }

        // переписал метод ToString на стрелочный
        public override string ToString() => $"plane: model = \'{_model}\', maxSpeed = {_maxSpeed}" +
                $", maxFlightDistance = {_maxFlightDistance}, maxLoadCapacity = {_maxLoadCapacity}";
    }
}
