using Archimind.Platform.ServiceModel.Security.Client;
using Archimind.Platform.ServiceModel.Security.Contracts;
using System;

namespace Archimind.Platform.ServiceModel.Tests
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                // Create proxy.

                Console.WriteLine("Creating SecuryStore Client...");

                SecurityStoreClient client = new SecurityStoreClient("wsHttp");

                Console.WriteLine("Getting user data...");

                SecurityStoreGetUserByIdRequest request =
                    new SecurityStoreGetUserByIdRequest("abc", "B105B060-F7F7-E311-BE80-54271E2019B2");

                SecurityStoreGetUserByIdResponse response =
                    client.GetUserById(request);

                UserData user = response.User;

                Console.WriteLine("User data : {0}", user.Id.ToString());                

                Console.WriteLine("Getting users data...");

                SecurityStoreGetUsersRequest requestUsers =
                    new SecurityStoreGetUsersRequest("abc");

                SecurityStoreGetUsersResponse responseUsers =
                    client.GetUsers(requestUsers);

                UserDataCollection users = responseUsers.Users;

                foreach (UserData userDto in users)
                {
                    Console.WriteLine("User data : {0}", userDto.Id.ToString());
                }

                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR : " + ex.Message);
                Console.ReadLine();
            }
        }
    }
}
