using System;
using System.Collections.Generic;
using System.Linq;

namespace Day_1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Member> members = new List<Member>();

            members.Add(new Member()
            {
                FirstName = "Tai",
                LastName = "Pham Tien",
                Gender = "Male",
                DateOfBirth = new DateTime(2000, 03, 11),
                PhoneNumber = "0987678888",
                BirthPlace = "Vinh Phuc",
                Graduated = "true"
            });
            members.Add(new Member
            {
                FirstName = "Tien",
                LastName = "Nguyen Van",
                Gender = "Male",
                DateOfBirth = new DateTime(1998, 02, 23),
                PhoneNumber = "0487348375",
                BirthPlace = "Ha Nam",
                Graduated = "true"
            });
            members.Add(new Member
            {
                FirstName = "Lan",
                LastName = "Phan Thi",
                Gender = "Female",
                DateOfBirth = new DateTime(2002, 08, 13),
                PhoneNumber = "0328742341",
                BirthPlace = "Ha Noi",
                Graduated = "alse"
            });
            members.Add(new Member
            {
                FirstName = "Tuyet",
                LastName = "Tran Thi",
                Gender = "Female",
                DateOfBirth = new DateTime(2000, 06, 13),
                PhoneNumber = "0238723836",
                BirthPlace = "Ha Nam",
                Graduated = "true"
            });
            members.Add(new Member
            {
                FirstName = "Quyen",
                LastName = "Tran Thi",
                Gender = "Female",
                DateOfBirth = new DateTime(1999, 10, 27),
                PhoneNumber = "0888335263",
                BirthPlace = "Ha Noi",
                Graduated = "true"
            });
            members.Add(new Member
            {
                FirstName = "Long",
                LastName = "Nguyen Hai",
                Gender = "Male",
                DateOfBirth = new DateTime(2001, 07, 03),
                PhoneNumber = "0987678888",
                BirthPlace = "Quang Ninh",
                Graduated = "alse"
            });
            members.Add(new Member
            {
                FirstName = "Tuan",
                LastName = "Nguyen Van",
                Gender = "Male",
                DateOfBirth = new DateTime(1998, 09, 29),
                PhoneNumber = "0329843271",
                BirthPlace = "Ha Noi",
                Graduated = "true"
            });
            members.Add(new Member
            {
                FirstName = "Minh",
                LastName = "Nguyen Tuan",
                Gender = "Male",
                DateOfBirth = new DateTime(2000, 11, 26),
                PhoneNumber = "0239874231",
                BirthPlace = "Vinh Phuc",
                Graduated = "true"
            });

            while (true)
            {
                Console.WriteLine("---------------");
                Console.WriteLine("Enter your selection: ");
                Console.WriteLine("1 - Return a list of members who is Male");
                Console.WriteLine("2 - Return the oldest one based on 'Age'");
                Console.WriteLine("3 - Return a new list that contains FullName only");
                Console.WriteLine("4 - Return 3 lists difference");
                Console.WriteLine("5 - Return the first person who born in Ha Noi");

                int selected = int.Parse(Console.ReadLine());

                switch (selected)
                {
                    case 1:
                        var selectMale = members.FindAll(member => member.Gender == "Male");

                        foreach (var member in selectMale)
                        {
                            Console.WriteLine(member);
                        }

                        break;
                    case 2:

                        Member oldestUser = members.OrderBy(member => member.DateOfBirth.Year).First();

                        Console.WriteLine(oldestUser.ToString());
                        break;

                    case 3:
                        var selectFullName = from member in members
                                             select member.FullName;

                        foreach (var member in selectFullName)
                        {
                            Console.WriteLine(member);
                        }

                        break;
                    case 4:

                        Console.WriteLine("1 - List of members who has birth year is 2000");
                        Console.WriteLine("2 - List of members who has birth year greater than 2000");
                        Console.WriteLine("3 - List of members who has birth year less than 2000");

                        int choice = int.Parse(Console.ReadLine());

                        switch (choice)
                        {
                            case 1:
                                var selectEqual = members.Where(member => member.DateOfBirth.Year == 2000);

                                foreach (Member member in selectEqual)
                                {
                                    Console.WriteLine(member);
                                }

                                break;
                            case 2:
                                var selectGreater = members.FindAll(member => member.DateOfBirth.Year > 2000);

                                foreach (Member member in selectGreater)
                                {
                                    Console.WriteLine(member);
                                }

                                break;
                            case 3:
                                var selectLess = from member in members
                                                 where member.DateOfBirth.Year < 2000
                                                 select member;

                                foreach (Member member in selectLess)
                                {
                                    Console.WriteLine(member);
                                }

                                break;
                        }
                        break;

                    case 5:
                        var selectFirstPerson = members.FirstOrDefault(member => member.BirthPlace == "Ha Noi");

                        Console.WriteLine(selectFirstPerson);

                        break;
                }
            }
        }
    }
}
