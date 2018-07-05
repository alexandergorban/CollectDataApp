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


        }

        private void NumberOfCommentsUnderUserPosts(int userId)
        {

        }

        private void ShortCommentsUnderUserPosts(int userId)
        {

        }

        private void ExecutedToDoByUser(int userId)
        {

        }

        private void UsersAscWithToDoDesc()
        {

        }

        private void UserStructure(int userId)
        {

        }

        private void PostStructure(int postId)
        {

        }
    }
}
