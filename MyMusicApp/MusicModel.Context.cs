﻿

namespace MyMusicPlayer
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class MusicPlayerDBEntities : DbContext
    {
        public MusicPlayerDBEntities()
            : base("name=MusicPlayerDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AlbumMaster> AlbumMasters { get; set; }
        public virtual DbSet<MusicPlayerMaster> MusicPlayerMasters { get; set; }
    
        public virtual ObjectResult<string> USP_Album_Insert(string albumName, string imageName)
        {
            var albumNameParameter = albumName != null ?
                new ObjectParameter("AlbumName", albumName) :
                new ObjectParameter("AlbumName", typeof(string));
    
            var imageNameParameter = imageName != null ?
                new ObjectParameter("ImageName", imageName) :
                new ObjectParameter("ImageName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("USP_Album_Insert", albumNameParameter, imageNameParameter);
        }
    
        public virtual ObjectResult<USP_AlbumMaster_Select_Result> USP_AlbumMaster_Select(string albumName)
        {
            var albumNameParameter = albumName != null ?
                new ObjectParameter("AlbumName", albumName) :
                new ObjectParameter("AlbumName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<USP_AlbumMaster_Select_Result>("USP_AlbumMaster_Select", albumNameParameter);
        }
    
        public virtual ObjectResult<string> USP_MusicAlbum_Delete(string musicID)
        {
            var musicIDParameter = musicID != null ?
                new ObjectParameter("musicID", musicID) :
                new ObjectParameter("musicID", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("USP_MusicAlbum_Delete", musicIDParameter);
        }
    
        public virtual ObjectResult<string> USP_MusicAlbum_Insert(string singerName, string albumName, string musicFileName, string description)
        {
            var singerNameParameter = singerName != null ?
                new ObjectParameter("SingerName", singerName) :
                new ObjectParameter("SingerName", typeof(string));
    
            var albumNameParameter = albumName != null ?
                new ObjectParameter("AlbumName", albumName) :
                new ObjectParameter("AlbumName", typeof(string));
    
            var musicFileNameParameter = musicFileName != null ?
                new ObjectParameter("MusicFileName", musicFileName) :
                new ObjectParameter("MusicFileName", typeof(string));
    
            var descriptionParameter = description != null ?
                new ObjectParameter("Description", description) :
                new ObjectParameter("Description", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("USP_MusicAlbum_Insert", singerNameParameter, albumNameParameter, musicFileNameParameter, descriptionParameter);
        }
    
        public virtual ObjectResult<USP_MusicAlbum_SelectALL_Result> USP_MusicAlbum_SelectALL(string albumName)
        {
            var albumNameParameter = albumName != null ?
                new ObjectParameter("AlbumName", albumName) :
                new ObjectParameter("AlbumName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<USP_MusicAlbum_SelectALL_Result>("USP_MusicAlbum_SelectALL", albumNameParameter);
        }
    
        public virtual ObjectResult<string> USP_MusicAlbum_Update(string musicID, string singerName, string albumName, string musicFileName, string description)
        {
            var musicIDParameter = musicID != null ?
                new ObjectParameter("musicID", musicID) :
                new ObjectParameter("musicID", typeof(string));
    
            var singerNameParameter = singerName != null ?
                new ObjectParameter("SingerName", singerName) :
                new ObjectParameter("SingerName", typeof(string));
    
            var albumNameParameter = albumName != null ?
                new ObjectParameter("AlbumName", albumName) :
                new ObjectParameter("AlbumName", typeof(string));
    
            var musicFileNameParameter = musicFileName != null ?
                new ObjectParameter("MusicFileName", musicFileName) :
                new ObjectParameter("MusicFileName", typeof(string));
    
            var descriptionParameter = description != null ?
                new ObjectParameter("Description", description) :
                new ObjectParameter("Description", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("USP_MusicAlbum_Update", musicIDParameter, singerNameParameter, albumNameParameter, musicFileNameParameter, descriptionParameter);
        }
    }
}
