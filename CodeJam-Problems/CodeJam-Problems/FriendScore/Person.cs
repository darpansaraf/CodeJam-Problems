using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeJam_Problems.FriendScore
{
    class Person
    {
        public int id;
        public List<int> listOfFriends;
        public List<int> listOfStrangers;

        public Person(int personId)
        {
            id = personId;
            listOfFriends = new List<int>();
            listOfStrangers = new List<int>();
        }
    }
}
