using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


namespace Lab10
{
    [Serializable]
    class Serializationzz
    {
        public List<Address> addresses = new List<Address>();
        public List<Car> cars = new List<Car>();
        public List<Person> people = new List<Person>();

        public Serializationzz(List<Address> addresses, List<Car> cars, List<Person> people)
        {
            this.addresses = addresses;
            this.cars = cars;
            this.people = people;
        }
    }
}
