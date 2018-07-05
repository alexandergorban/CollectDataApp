using System;
using System.Collections.Generic;
using System.Text;

namespace CollectDataApp.Presentations
{
    class Menu
    {
        public void StartApp()
        {
            AppCommands();
        }

        private void AppCommands()
        {
            Console.WriteLine("App commands:\n" +
                              "1. 'numcom' - Get the number of comments under the posts of a particular user (by Id)\n" +
                              "2. 'listcom' - Get a list of comments under the posts of a particular user (by Id), where body comment < 50 characters (list of comments)\n" +
                              "3. 'gettodo' - Get the list (id, name) from the list of todos that are executed for a specific user (by Id)\n" +
                              "4. 'listuser' - Get a list of users in alphabetical order (ascending) with sorted todo items by length name (descending)\n" +
                              "5. 'getuser' - Get the structure: User, Last Post, Number of comments for last post, Tasks in todo, most popular post. (pass User Id to parameters)\n" +
                              "6. 'getpost' - Get the structure: Post, Longest comment of the post, Most liked comment on the post, Number of comments under the post where or 0 likes or text length <80 (pass User Id to parameters)\n" +
                              "7. 'exit' - Exit from app\n" +
                              "Enter command:");

            string command = Console.ReadLine();

            Console.Clear();

            switch (command)
            {
                case "1":
                    NumberOfCommentsUnderUserPosts();
                    break;
                case "numcom":
                    NumberOfCommentsUnderUserPosts();
                    break;
                case "2":
                    ShortCommentsUnderUserPosts();
                    break;
                case "listcom":
                    ShortCommentsUnderUserPosts();
                    break;
                case "3":
                    ExecutedToDoByUser();
                    break;
                case "gettodo":
                    ExecutedToDoByUser();
                    break;
                case "4":
                    UsersAscWithToDoDesc();
                    break;
                case "listuser":
                    UsersAscWithToDoDesc();
                    break;
                case "5":
                    UserStructure();
                    break;
                case "getuser":
                    UserStructure();
                    break;
                case "6":
                    PostStructure();
                    break;
                case "getpost":
                    PostStructure();
                    break;
                case "7":
                    return;
                case "exit":
                    return;
                default:
                    throw new Exception();
            }

            BackToMenu();
        }

        private void BackToMenu()
        {
            int command = -1;
            while (command != 0)
            {
                Console.WriteLine("Enter '0' to return to the main menu:");

                try
                {
                    string input = Console.ReadLine();

                    if (input.Length != 1)
                    {
                        throw new Exception("Incorrent entered command");
                    }

                    command = Int32.Parse(input);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }

            Console.Clear();
            AppCommands();
        }

        //1. Show the number of comments under the posts of a particular user(by Id)
        private void NumberOfCommentsUnderUserPosts()
        {
            Console.WriteLine("Enter User Id: ");
            int userId = int.Parse(Console.ReadLine());

        }

        //2. Show a list of comments under the posts of a particular user (by Id), where body comment < 50 characters (list of comments)
        private void ShortCommentsUnderUserPosts()
        {
            Console.WriteLine("Enter User Id: ");
            int userId = int.Parse(Console.ReadLine());
        }

        //3. Show the list (id, name) from the list of todos that are executed for a specific user (by Id)
        private void ExecutedToDoByUser()
        {
            Console.WriteLine("Enter User Id: ");
            int userId = int.Parse(Console.ReadLine());
        }

        //4. Show a list of users in alphabetical order (ascending) with sorted To Do items by length name (descending)
        private void UsersAscWithToDoDesc()
        {

        }

        //5. Show the structure: User, Last Post, Number of comments for last post, Tasks in To Do, most popular post
        private void UserStructure()
        {
            Console.WriteLine("Enter User Id: ");
            int userId = int.Parse(Console.ReadLine());
        }

        //6. Show the structure: Post, Longest comment of the post, Most liked comment on the post, Number of comments under the post where or 0 likes or text length <80 (pass User Id to parameters)
        private void PostStructure()
        {
            Console.WriteLine("Enter Post Id: ");
            int userId = int.Parse(Console.ReadLine());
        }
    }
}
