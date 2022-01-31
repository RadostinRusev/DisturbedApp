using AppsService.DTOs;
using AppsService.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfSOAP2
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {

        private UserManagmentService userManagmentService = new UserManagmentService();
        private PlayListManagmentService playListManagmentService = new PlayListManagmentService();
        private SongManagmentService songManagmentService = new SongManagmentService();
        public string DeletePlayList(int id)
        {
            if (playListManagmentService.Delete(id))
            {
                return "the playlist is deleted";
            }
            else
            {
                return "not deleted";
            }
        }

        public string DeleteSong(int id)
        {
           if(songManagmentService.Delete(id))
            {
                return "the playlist is deleted";
            }
            else
            {
                return "not deleted";
            }
        }

        public string DeleteUser(int id)
        {
            if (userManagmentService.Delete(id))
            {
                return "the playlist is deleted";
            }
            else
            {
                return "not deleted";
            }
        }

        public string Edit(int id, UserDTO userDTO)
        {
            if (userManagmentService.Edit(id, userDTO))
            {
                return "good job";
            }
            else return "failed";
        }

        public string EditPlaylist(int id, PlayListDTO playListDTO)
        {
            if (playListManagmentService.Edit(id, playListDTO))
            {
                return "good job";
            }
            else return "failed";
        }

        public string EditSong(int id, SongDTO songDTO)
        {
            if (songManagmentService.Edit(id, songDTO))
            {
                return "good job";
            }
            else return "failed";
        }

        public string EditUser(int id, UserDTO userDTO)
        {
            throw new NotImplementedException();
        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public PlayListDTO GetPlaylistById(int id)
        {
            return playListManagmentService.GetById(id);
        }

        public SongDTO GetSongById(int id)
        {
            return songManagmentService.GetById(id);
        }

        public List<PlayListDTO> GetSPlayList()
        {
            return playListManagmentService.Get();
        }

        public List<SongDTO> GetSSongist()
        {
            return songManagmentService.Get();
        }

        public List<UserDTO> GetUser()
        {
            return userManagmentService.Get();
        }

        public UserDTO GetUsertById(int id)
        {
            return userManagmentService.GetById(id);
        }

        public string PostPlayList(PlayListDTO playListDTO)
        {
            if (playListManagmentService.Save(playListDTO))
            {
                return "the playlist is saved";
            }
            else
            {
                return "playlist not saved";
            }
        }

        public string PostSong(SongDTO songDTO)
        {
            if (songManagmentService.Save(songDTO))
            {
                return "the song is saved";
            }
            else
            {
                return "song not saved";
            }
        }

        public string PostUser(UserDTO userDTO)
        {
            if (userManagmentService.Save(userDTO))
            {
                return "the user is saved";
            }
            else
            {
                return "user not saved";
            }
        }
    }
}
