using Aircompany.Models;
using Aircompany.Planes;
using System.Collections.Generic;
using System.Linq;
// удалил лишнию директиву

namespace Aircompany
{
    public class Airport
    {
        private readonly List<Plane> _planes;   // изменил модификатор доступа на private readonly

        public Airport(IEnumerable<Plane> planes) => _planes = planes.ToList(); // переписал конструктор на стрелочный

        public List<Plane> Planes => _planes;   

        public List<PassengerPlane> GetPassengerPlanes()
        {
            var passengerPlanes = new List<PassengerPlane>();   // List<PassengerPlane> заменил на var
            foreach (var plane in _planes)                      // при работе с коллекцией вместо for использовал foreach
                if (plane is PassengerPlane)                    // удалил лишние скобки, так как одно выражение в теле
                    passengerPlanes.Add(plane as PassengerPlane);
            return passengerPlanes;
        }

        public List<MilitaryPlane> GetMilitaryPlanes()
        {
            var militaryPlanes = new List<MilitaryPlane>();     // то же что и в GetPassengerPlanes() 
            foreach (var plane in _planes)
                if (plane is MilitaryPlane)
                    militaryPlanes.Add(plane as MilitaryPlane);
            return militaryPlanes;
        }

        public List<MilitaryPlane> GetMilitaryPlanesWithType(MilitaryType militaryPlaneType)    // для тестов
        {
            var militaryPlanesWithType = new List<MilitaryPlane>();
            var militaryPlanes = GetMilitaryPlanes();

            foreach (var plane in militaryPlanes)
                if (plane.Type == militaryPlaneType)
                    militaryPlanesWithType.Add(plane);

            return militaryPlanesWithType;
        }

        // переписал на стрелочную функцию и удалил лишнюю строку
        public PassengerPlane GetPassengerPlaneWithMaxPassengersCapacity() =>
           GetPassengerPlanes().Aggregate((m, c) => m.PassengersCapacity > c.PassengersCapacity ? m : c);

        // стрелочные
        public Airport SortByMaxDistance() => new Airport(_planes.OrderBy(p => p.MaxFlightDistance));

        public Airport SortByMaxSpeed() => new Airport(_planes.OrderBy(p => p.MaxSpeed));

        public Airport SortByMaxLoadCapacity() => new Airport(_planes.OrderBy(p => p.MaxLoadCapacity));

        public override string ToString() => $"Airport: planes = {string.Join(", ", _planes.Select(x => x.Model))}\n";
    }
}
