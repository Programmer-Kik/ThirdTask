using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ustalkov.SSU.Task3.Entity
{
    public class Award
    {
        private int id;
        private string title;
        public int Id { get => id; }
        public string Title { get => title; }

        public Award(int id, string title)
        {
            this.id = id;
            this.title = title;
        }
    }
}
