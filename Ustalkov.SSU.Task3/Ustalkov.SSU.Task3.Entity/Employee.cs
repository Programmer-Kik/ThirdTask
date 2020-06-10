using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ustalkov.SSU.Task3.Entity
{
    public class Employee
    {
        private int id;
        private string name;
        private DateTime dateOfBirth;
        private int age;
        private List<Award> awards = new List<Award>();
        public int Id { get => id; }
        public string Name { get => name; }
        public DateTime DateOfBirth { get => dateOfBirth; }
        public int Age { get => age; }
        public List<Award> Awards { get => awards; }

        public Employee(int id, string name, DateTime dateOfBirth, int age, Award award)
        {
            this.id = id;
            this.name = name;
            this.dateOfBirth = dateOfBirth;
            this.age = age;
            awards.Add(award);
        }

        public void AddToAwards(Award award)
        {
            awards.Add(award);
        }
    }
}
