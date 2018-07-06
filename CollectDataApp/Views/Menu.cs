using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CollectDataApp.Queries;
using CollectDataApp.Services;

namespace CollectDataApp.Views
{
    class Menu
    {
        private BlogService _blogService;
        private BlogQueries _blogQueries;

        public Menu()
        {
            
        }

        private async Task InitServices()
        {
            _blogService = new BlogService(new HttpClient());
            _blogQueries = new BlogQueries(await _blogService.GetComplexlyFilledUsers());
        }

        public async Task StartApp()
        {
            await InitServices();

            AppCommands();
        }

        private void AppCommands()
        {
            Console.WriteLine("App commands:\n" +
                              "1. 'numcom' - Get the number of comments under the posts of a particular user (by Id)\n" +
                              "2. 'listcom' - Get a list of comments under the posts of a particular user (by Id), \n\twhere body comment < 50 characters (list of comments)\n" +
                              "3. 'gettodo' - Get the list (id, name) from the list of todos that are executed for \n\ta specific user (by Id)\n" +
                              "4. 'listuser' - Get a list of users in alphabetical order (ascending) with sorted \n\ttodo items by length name (descending)\n" +
                              "5. 'getuser' - Get the structure: User, Last Post, Number of comments for last post, \n\tTasks in todo, most popular post. \n\t(pass User Id to parameters)\n" +
                              "6. 'getpost' - Get the structure: Post, Longest comment of the post, Most liked comment \n\ton the post, Number of comments under the post where or 0 likes or text length <80 \n\t(pass User Id to parameters)\n" +
                              "7. 'exit' - Exit from app\n\n" +
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
                Console.WriteLine("\nEnter '0' to return to the main menu:");

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

            var numberOfCommentByPosts = _blogQueries.GetNumberOfCommentsUnderUserPosts(userId);

            foreach (var numberOfCommentByPost in numberOfCommentByPosts)
            {
                Console.WriteLine($"{numberOfCommentByPost.Post.Title} - {numberOfCommentByPost.Comments}");
            }
        }

        //2. Show a list of comments under the posts of a particular user (by Id), where body comment < 50 characters (list of comments)
        private void ShortCommentsUnderUserPosts()
        {
            Console.WriteLine("Enter User Id: ");
            int userId = int.Parse(Console.ReadLine());

            var shortComments = _blogQueries.GetShortCommentsUnderUserPosts(userId);

            foreach (var comment in shortComments)
            {
                Console.WriteLine($"Comment: {comment.Body} \n Comment length: {comment.Body.Length}\n");
            }
        }

        //3. Show the list (id, name) from the list of todos that are executed for a specific user (by Id)
        private void ExecutedToDoByUser()
        {
            Console.WriteLine("Enter User Id: ");
            int userId = int.Parse(Console.ReadLine());

            var executedToDos = _blogQueries.GetExecutedToDoByUser(userId);

            foreach (var toDo in executedToDos)
            {
                Console.WriteLine($"ToDo: {toDo.Id} - {toDo.Name}");
            }
        }

        //4. Show a list of users in alphabetical order (ascending) with sorted To Do items by length name (descending)
        private void UsersAscWithToDoDesc()
        {
            var usersAscWithToDoDesc = _blogQueries.GetUsersAscWithToDoDesc();

            foreach (var user in usersAscWithToDoDesc)
            {
                Console.WriteLine($"Name: {user.Name} Email: {user.Email}");

                foreach (var toDo in user.ToDos)
                {
                    Console.WriteLine($"ToDo Name: {toDo.Name}");
                }
            }
        }

        //5. Show the structure: User, Last Post, Number of comments for last post, Tasks in To Do, most popular post
        private void UserStructure()
        {
            Console.WriteLine("Enter User Id: ");
            int userId = int.Parse(Console.ReadLine());

            var userData = _blogQueries.GetUserData(userId);
            Console.WriteLine($"User Id: {userId}\n" +
                              $"1. User Name: {userData.User.Name}\n" +
                              $"2. Last post by user (by date): {userData.LastPost.Title}; Post Date: {userData.LastPost.CreatedAt}\n" +
                              $"3. Number of comments under the last post: {userData.LastPostCommentsCount}\n" +
                              $"4. Number of uncompleted tasks for the user: {userData.UncompletedTodosCount}\n" +
                              $"5. The most popular user post by comments: {userData.PostWithMaxComments.Title}\n" +
                              $"6. The most popular user post by likes: {userData.PostWithMaxLikes.Title}");
        }

        //6. Show the structure: Post, Longest comment of the post, Most liked comment on the post, Number of comments under the post where or 0 likes or text length <80 (pass User Id to parameters)
        private void PostStructure()
        {
            Console.WriteLine("Enter Post Id: ");
            int postId = int.Parse(Console.ReadLine());

            var postData = _blogQueries.GetPostData(postId);
            Console.WriteLine($"Post Id: {postId}\n" +
                              $"1. Post Title: {postData.Post.Title}\n" +
                              $"2. The longest comment of the post: {postData.LongestComment.Body}\n" +
                              $"3. The most like comment of the post: {postData.MostLikedComment.Body}\n" +
                              $"4. Number of unpopular comments under the post: {postData.MostUnpopularCommentsCount}");
        }
    }
}
