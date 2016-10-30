using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeJam_Problems.FriendScore
{
    public class FriendScore
    {
        public static void main(string[] args)
        {
            var friends = File.ReadAllLines(@"C:\Users\Darpan\Documents\Visual Studio 2012\Projects\SantaDaDhaba\SantaDaDhaba\FriendScore\FriendScoreInput.txt").ToList();
            int highestScore = HighestScore(friends);
            Console.WriteLine("The number of 2-friends of the most popular person in this social network:" + highestScore);
            Console.ReadLine();
        }

        public static int HighestScore(List<string> friends)
        {
            var friendsScore = InitializeFriendScore(friends.Count);

            var persons = new List<Person>();
            for (int index = 0; index < friends.Count; index++)
            {
                var person = new Person(index);

                var relationshipString = friends[index];
                int i = 0;
                foreach (var status in relationshipString)
                {
                    if (i == index)
                        break;

                    if (status == 'Y')
                    {
                        friendsScore[i]++;
                        friendsScore[index]++;
                        person.listOfFriends.Add(i);
                        persons[i].listOfFriends.Add(index);
                    }
                    else
                    {
                        person.listOfStrangers.Add(i);
                        persons[i].listOfStrangers.Add(index);
                    }
                    i++;
                }
                persons.Add(person);
            }
            //DisplayPersonsList(persons);
            FindMutualFriendsAndUpdateFriendScore(persons, friendsScore);
            return friendsScore.Max();
            
        }

        private static void FindMutualFriendsAndUpdateFriendScore(List<Person> persons, List<int> friendsScore)
        {
            foreach (var person in persons)
            {
                foreach (var stranger in person.listOfStrangers)
                {
                    var friendsOfStranger = persons[stranger].listOfFriends;
                    foreach (var friendOfStranger in friendsOfStranger)
                    {
                        if (person.listOfFriends.Contains(friendOfStranger))
                        {
                            friendsScore[person.id]++;
                            friendsScore[stranger]++;
                            persons[stranger].listOfStrangers.Remove(person.id);
                        }
                    }
                }
            }
        }

        private static void DisplayPersonsList(List<Person> persons)
        {

            foreach (var person in persons)
            {
                Console.WriteLine("Person ID: " + person.id);

                Console.WriteLine("List of Friends:");
                foreach (var friendId in person.listOfFriends)
                    Console.Write(" " + friendId);

                Console.WriteLine("\n List of Strangers:");
                foreach (var strangerId in person.listOfStrangers)
                    Console.Write(" " + strangerId);

                Console.WriteLine("\n ----------------------------------------");
            }
            Console.ReadLine();
        }

        private static List<int> InitializeFriendScore(int count)
        {
            int[] friendsScore = new int[count];
            for (int index = 0; index < count; index++)
            {
                friendsScore[index] = 0;
            }
            return friendsScore.ToList();
        }
    }
}
