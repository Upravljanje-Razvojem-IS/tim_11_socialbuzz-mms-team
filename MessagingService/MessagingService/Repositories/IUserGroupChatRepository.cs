using MessagingService.DTOs.UserDTOs;
using MessagingService.DTOs.UserGroupChat;
using System.Collections.Generic;

namespace MessagingService.Repositories
{
    public interface IUserGroupChatRepository
    {
        List<UserReadDTO> GetUsersByGroupChat(int uId,int gcID);
        List<UserReadDTO> GetGroupUsers(int gcID);

        //add user to group
        UserGroupChatCreate AddUserToGroup(UserGroupChatCreate ugcDTO);
        //Remove user from group
        void DeleteUserFromGroupChat(UserGroupChatCreate ugcDTO);
    }
}
