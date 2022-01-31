using DisturbedAppsProject.Context;
using DisturbedAppsProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository2
{
    public class UnitOfWork : IDisposable
    {
       private MusicDbContext context = new MusicDbContext();
    private GenericRepository<User> userRepository;
    private GenericRepository<PlayList> playlistRepository;
        private GenericRepository<Song> songRepository;

        public GenericRepository<User> UserRepository
        {
        get
        {

            if (this.userRepository == null)
            {
                this.userRepository = new GenericRepository<User>(context);
            }
            return userRepository;
        }
    }

    public GenericRepository<PlayList> PlaylistRepository
        {
        get
        {

            if (this.playlistRepository == null)
            {
                this.playlistRepository = new GenericRepository<PlayList>(context);
            }
            return playlistRepository;
        }
    }
        public GenericRepository<Song> SongRepository
        {
            get
            {

                if (this.songRepository == null)
                {
                    this.songRepository = new GenericRepository<Song>(context);
                }
                return songRepository;
            }
        }


        public void Save()
    {
        context.SaveChanges();
    }

    private bool disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                context.Dispose();
            }
        }
        this.disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}
}
